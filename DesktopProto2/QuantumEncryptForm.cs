using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuantumEncryptLib;

namespace DesktopProto2
{
    public partial class QuantumEncryptForm : Form
    {
        byte[] encryptedBytes;
        string cipher;
        string serialNo;
        public QuantumEncryptForm()
        {
            InitializeComponent();
            btnLoadandEncrypt.Enabled = false;
            btnSave.Enabled = false;
            rbAutoGenerateCipher.Checked = true;

            openFileDialog1.FileName = "Select a text file";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.Title = "Open text file";

            saveFileDialog1.Filter = "QuantumLock Files (*.qlock)|*.qlock";
            saveFileDialog1.Title = "Save a QuantumLock File";

            openCipherDialog.FileName = "Select a cipher file";
            openCipherDialog.Filter = "Cipher files (*.cipher)|*.cipher";
            openCipherDialog.Title = "Open cipher file";
        }

        private void SetText(string text)
        {
            txtCipherSerialNo.Text = text;
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //C:\Users\issis\Downloads\prj-directives-final\prj-directives-final
                try
                {
                    //var sr = new StreamReader(openFileDialog1.FileName);
                    var unEncryptedBytes = File.ReadAllBytes(openFileDialog1.FileName);
                    var fileToEncryptFilename = Path.GetFileName(openFileDialog1.FileName);

                    var cipherLen = QuantumEncrypt.GetCipherLen(unEncryptedBytes.Length);
                    cipher = QuantumEncrypt.GenerateRandomCryptographicKey(cipherLen);
                    serialNo = QuantumEncrypt.GenerateRandomSerialNumber();
                    
                    // About to Encrypt, start a timer
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    encryptedBytes = QuantumEncrypt.Encrypt(openFileDialog1.FileName, unEncryptedBytes, cipher, serialNo);
                    watch.Stop();
                    txtEncryptionTimeTicks.Text = watch.ElapsedTicks.ToString();
                    // Encryption Completed.

                    txtOutputWindow.Text = QuantumEncrypt.HexDump(encryptedBytes);
                    txtEncryptedFilename.Text = fileToEncryptFilename;
                    txtCipherSerialNo.Text = serialNo;
                    txtCipherFileSize.Text = cipherLen.ToString();
                    txtInputFileSize.Text = unEncryptedBytes.Length.ToString();
                    txtEncryptedFileSize.Text = encryptedBytes.Length.ToString();
                    btnSave.Enabled = true;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }


        private void loadCipher_Click(object sender, EventArgs e)
        {
            // use a filter to load .cipher file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var arr = File.ReadAllBytes(openFileDialog1.FileName);
                btnLoadandEncrypt.Enabled = false;
                btnSave.Enabled = false;
            }

        }

        private void generateCipher_Click(object sender, EventArgs e)
        {
            if (saveCipherDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveCipherDialog.FileName != "")
                {
                    // default extension for saved encrypted files to be .qlock
                    FileStream fs = (System.IO.FileStream)saveCipherDialog.OpenFile();
                    fs.Write(Encoding.ASCII.GetBytes(cipher), 0, cipher.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
        }

        private void rbUseExistingCipher_CheckedChanged(object sender, EventArgs e)
        {
            btnGenerateCipher.Visible = false;
            btnLoadCipher.Visible = true;
            btnLoadandEncrypt.Enabled = false;
            btnSave.Enabled = false;
        }

        private void rbGenerateNewCipher_CheckedChanged(object sender, EventArgs e)
        {
            btnGenerateCipher.Visible = true;
            btnLoadCipher.Visible = false;
            btnLoadandEncrypt.Enabled = false;
            btnSave.Enabled = false;
        }

        private void rbAutoGenerateCipher_CheckedChanged(object sender, EventArgs e)
        {
            btnGenerateCipher.Visible = false;
            btnLoadCipher.Visible = false;
            btnLoadandEncrypt.Enabled = true;
            btnSave.Enabled = false;
        }

        private void btnRandomizeSerialNo_Click(object sender, EventArgs e)
        {
            txtCipherSerialNo.Text = QuantumEncrypt.GenerateRandomSerialNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    // default extension for saved encrypted files to be .qlock
                    FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                    fs.Write(encryptedBytes,0,encryptedBytes.Length);
                    fs.Flush();
                    fs.Close();
                } 
            }
        }

        private void cipherFileName_Enter(object sender, EventArgs e)
        {
            if (openCipherDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            // About to Encrypt, start a timer
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var decryptedBytes = QuantumEncrypt.Decrypt(encryptedBytes, cipher);
            watch.Stop();
            txtEncryptionTimeTicks.Text = watch.ElapsedTicks.ToString();
            // Encryption Completed.

            txtOutputWindow.Text = QuantumEncrypt.HexDump(decryptedBytes);
            //txtEncryptedFilename.Text = fileToEncryptFilename;
            //txtCipherSerialNo.Text = serialNo;
            //txtCipherFileSize.Text = cipherLen.ToString();
            //txtInputFileSize.Text = unEncryptedBytes.Length.ToString();
            txtEncryptedFileSize.Text = decryptedBytes.Length.ToString();
            btnSave.Enabled = true;
        }
    }
}

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
using QuantumEncryptPoCDesktop;

namespace DesktopProto2
{
    public partial class QuantumEncryptForm : Form
    {
        byte[] _encryptedBytes;
        byte[] _unEncryptedBytes;
        string _cipher;
        string _serialNo;
        string _cipherVersion = "10";
        public QuantumEncryptForm()
        {
            InitializeComponent();
            btnLoadandEncrypt.Enabled = false;
            btnSave.Enabled = false;
            rbAutoGenerateCipher.Checked = true;

            openFileDialog1.FileName = "Select a file to encrypt";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.Title = "Open file to encrypt";

            saveFileDialog1.Filter = "QuantumLock Files (*.qlock)|*.qlock";
            saveFileDialog1.Title = "Save a QuantumLock File";

            openCipherDialog.FileName = "Select a cipher file";
            openCipherDialog.Filter = "Cipher files (*.cipher)|*.cipher";
            openCipherDialog.Title = "Open cipher file";

            saveCipherDialog.Filter = "Cipher files (*.cipher)|*.cipher";
            saveCipherDialog.Title = "Save cipher file";
        }

        private void SetText(string text)
        {
            txtCipherSerialNo.Text = text;
        }

        private async void SelectButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var progress = new Progress<int>(value =>
                    {
                        progressBarECDC.Value = value;

                    }); 
                    _unEncryptedBytes = File.ReadAllBytes(openFileDialog1.FileName);
                    var fileToEncryptFilename = Path.GetFileName(openFileDialog1.FileName);

                    var cipherLen = QuantumEncrypt.GetCipherLen(_unEncryptedBytes.Length);
                    _serialNo = QuantumEncrypt.GenerateRandomSerialNumber();
                    var newCipher = QuantumEncrypt.GenerateRandomCryptographicKey(cipherLen);
                    _cipher = _cipherVersion + _serialNo + newCipher;

                    // About to Encrypt, start a timer
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    await Task.Run(() => _encryptedBytes = QuantumEncrypt.Encrypt(fileToEncryptFilename, _unEncryptedBytes, _cipher, _serialNo, progress));
                    watch.Stop();
                    txtEncryptionTimeTicks.Text = watch.ElapsedTicks.ToString();
                    // Encryption Completed.

                    txtOutputWindow.Text = QuantumEncrypt.HexDump(_encryptedBytes);
                    txtEncryptedFilename.Text = fileToEncryptFilename;
                    txtCipherSerialNo.Text = _serialNo;
                    txtCipherFileSize.Text = cipherLen.ToString();
                    txtInputFileSize.Text = _unEncryptedBytes.Length.ToString();
                    txtEncryptedFileSize.Text = _encryptedBytes.Length.ToString();
                    btnSave.Enabled = true;

                    var dialog = new EncryptionCompleteDialog();
                    dialog.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private async void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                var progress = new Progress<int>(value =>
                {
                    progressBarECDC.Value = value;

                });
                // About to Encrypt, start a timer
                var watch = System.Diagnostics.Stopwatch.StartNew();
                await Task.Run( () => _encryptedBytes = QuantumEncrypt.Encrypt(openFileDialog1.FileName, _unEncryptedBytes, _cipher, _serialNo, progress));
                watch.Stop();
                txtEncryptionTimeTicks.Text = watch.ElapsedTicks.ToString();
                // Encryption Completed.

                txtOutputWindow.Text = QuantumEncrypt.HexDump(_encryptedBytes);
                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"btnEncrypt_Click() Exception.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }

        private async void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                var progress = new Progress<int>(value =>
                {
                    progressBarECDC.Value = value;

                });                // About to Encrypt, start a timer
                var watch = System.Diagnostics.Stopwatch.StartNew();
                if (!QuantumEncrypt.IsMatchForDecryption(_encryptedBytes, _cipher))
                {
                    MessageBox.Show($"Serial Numbers do not match. " +
                        $"\nCipher: {QuantumEncrypt.GetSerialNumberFromCipher(_cipher)} +" +
                        $"\nFile: {QuantumEncrypt.GetSerialNumberFromEncryptedBytes(_encryptedBytes)}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                byte[] decryptedBytes = null;
                await Task.Run(() => decryptedBytes = QuantumEncrypt.Decrypt(_encryptedBytes, _cipher, progress));
                watch.Stop();
                txtEncryptionTimeTicks.Text = watch.ElapsedTicks.ToString();
                // Encryption Completed.

                txtOutputWindow.Text = QuantumEncrypt.HexDump(decryptedBytes);
                txtEncryptedFileSize.Text = decryptedBytes.Length.ToString();
                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"btnDecrypt_Click() Exception.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
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
                    fs.Write(Encoding.ASCII.GetBytes(_cipher), 0, _cipher.Length);
                    fs.Flush();
                    fs.Close();
                    txtCipherFileName.Text = Path.GetFileName(saveCipherDialog.FileName);
                }
            }
        }

        private void rbUseExistingCipher_CheckedChanged(object sender, EventArgs e)
        {
            btnGenerateCipher.Visible = false;
            btnLoadandEncrypt.Enabled = false;
            btnSave.Enabled = false;
            txtCipherFileName.Enabled = true;
            txtCipherSerialNo.Enabled = false;
            txtInputFileSize.Enabled = false;
            txtEncryptedFilename.Enabled = true;
        }

        private void rbGenerateNewCipher_CheckedChanged(object sender, EventArgs e)
        {
            btnGenerateCipher.Visible = true;
            btnLoadandEncrypt.Enabled = false;
            btnSave.Enabled = false;
            txtCipherFileName.Enabled = false;
            txtCipherSerialNo.Enabled = true;
            txtInputFileSize.Enabled = true;
            txtEncryptedFilename.Enabled = true;
        }

        private void rbAutoGenerateCipher_CheckedChanged(object sender, EventArgs e)
        {
            btnGenerateCipher.Visible = false;
            btnLoadandEncrypt.Enabled = true;
            btnSave.Enabled = false;
            txtCipherFileName.Enabled = false;
            txtCipherSerialNo.Enabled = false;
            txtInputFileSize.Enabled = true;
            txtEncryptedFilename.Enabled = false;
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
                    fs.Write(_encryptedBytes, 0, _encryptedBytes.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
        }

        private void cipherFileName_Enter(object sender, EventArgs e)
        {
            if (openCipherDialog.ShowDialog() == DialogResult.OK)
            {
                var arr = File.ReadAllBytes(openCipherDialog.FileName);
                btnLoadandEncrypt.Enabled = false;
                btnSave.Enabled = false;
                _cipher = QuantumEncrypt.CopyBytesToString(arr, 0, arr.Length);
                _serialNo = QuantumEncrypt.GetSerialNumberFromCipher(_cipher);
                txtCipherFileName.Text = Path.GetFileName(openCipherDialog.FileName);
                maxEncryptFileSize.Text = QuantumEncrypt.GetMaxFileSizeForEncryption(_cipher).ToString();
                txtCipherSerialNo.Text = QuantumEncrypt.GetSerialNumberFromCipher(_cipher);
            }

        }



        private void btnSaveCipher_Click(object sender, EventArgs e)
        {
            if (saveCipherDialog.ShowDialog() == DialogResult.OK)
            {
                var cipherBytes = new byte[_cipher.Length];
                var idx = 0;
                QuantumEncrypt.CopyStringToByteArray(_cipher, ref cipherBytes, ref idx);
                if (saveCipherDialog.FileName != "")
                {
                    // default extension for saved encrypted files to be .qlock
                    FileStream fs = (System.IO.FileStream)saveCipherDialog.OpenFile();
                    fs.Write(cipherBytes, 0, _cipher.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
        }

        private void cipherFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEncryptedFilename_Enter(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //var sr = new StreamReader(openFileDialog1.FileName);
                    _unEncryptedBytes = File.ReadAllBytes(openFileDialog1.FileName);
                    var fileToEncryptFilename = Path.GetFileName(openFileDialog1.FileName);
                    txtEncryptedFilename.Text = fileToEncryptFilename;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }


    }
}

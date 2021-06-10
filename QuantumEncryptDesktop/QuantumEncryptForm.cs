using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuantumEncryptLib;
using QuantumEncryptPoCDesktop;

namespace DesktopProto2
{
    public partial class QuantumEncryptForm : Form
    {
        const string SELECT_A_FILE_TO_ENCRYPT = "Select a file to encrypt";
        byte[] _encryptedBytes;
        byte[] _unEncryptedBytes;
        string _cipher;
        string _serialNo;
        readonly string _cipherVersion = "10";
        string _fileToEncryptFilename = string.Empty;
        public QuantumEncryptForm()
        {
            InitializeComponent();
            btnSave.Enabled = false;
            rbAutoGenerateCipher.Checked = true;

            openFileDialog1.FileName = SELECT_A_FILE_TO_ENCRYPT;
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

        //private async void LoadAndEncrypt_Click(object sender, EventArgs e)
        //{
        //    openFileDialog1.FileName = SELECT_A_FILE_TO_ENCRYPT;

        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            var progress = new Progress<int>(value =>
        //            {
        //                progressBarECDC.Value = value;

        //            }); 
        //            _unEncryptedBytes = File.ReadAllBytes(openFileDialog1.FileName);
        //            var fileToEncryptFilename = Path.GetFileName(openFileDialog1.FileName);

        //            _cipher = GetRandomCipher();

        //            var reason = string.Empty;
        //            // --------- About to Encrypt, start a timer ---------------
        //            var watch = System.Diagnostics.Stopwatch.StartNew();
        //            await Task.Run(() => _encryptedBytes = QuantumEncrypt.Encrypt(fileToEncryptFilename, _unEncryptedBytes, _cipher, _serialNo, progress, ref reason));
        //            watch.Stop();
        //            txtEncryptionTimeTicks.Text = watch.ElapsedTicks.ToString();
        //            txtEncryptedFilename.Text = fileToEncryptFilename;
        //            // Encryption Completed.
        //            if (_encryptedBytes == null)
        //                MessageBox.Show($"Encryption failed.\n\nReason: {reason}\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //            btnSave.Enabled = true;
        //            UpdateFormFields();

        //            var dialog = new EncryptionCompleteDialog(_encryptedBytes, fileToEncryptFilename);
        //            Thread.Sleep(1000);
        //            dialog.ShowDialog();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Exception.\n\nError message: {ex.Message}\n\n" +
        //            $"Details:\n\n{ex.StackTrace}");
        //        }
        //    }
        //}

        private async void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (_unEncryptedBytes == null)
                {
                    txtEncryptedFilename.BackColor = Color.Red;
                    MessageBox.Show($"File to encrypt is not loaded.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (rbAutoGenerateCipher.Checked == true)
                {
                    txtCipherFileName.Text = string.Empty;
                    _cipher = GetRandomCipher();
                }

                var progress = new Progress<int>(value =>
                {
                    progressBarECDC.Value = value;

                });
                _fileToEncryptFilename = Path.GetFileName(openFileDialog1.FileName);

                // About to Encrypt, start a timer
                var reason = string.Empty;
                var watch = System.Diagnostics.Stopwatch.StartNew();
                await Task.Run( () => _encryptedBytes = QuantumEncrypt.Encrypt(_fileToEncryptFilename, _unEncryptedBytes, _cipher, _serialNo, progress, ref reason));
                watch.Stop();
                txtEncryptionTimeTicks.Text = watch.ElapsedTicks.ToString();
                // Encryption Completed.

                if (_encryptedBytes == null)
                {
                    MessageBox.Show($"Encryption failed.\n\nReason: {reason}\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                btnSave.Enabled = true;
                UpdateFormFields();

                var dialog = new EncryptionCompleteDialog(true, _encryptedBytes, _fileToEncryptFilename);

                //Thread.Sleep(1000);
                dialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"btnEncrypt_Click() Exception.\n\nError message: {ex.Message}\n\nDetails:\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (_encryptedBytes == null)
                {
                    MessageBox.Show($"File to decrypt is not loaded.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var progress = new Progress<int>(value =>
                {
                    progressBarECDC.Value = value;

                });                // About to Encrypt, start a timer
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var cipherSerial = string.Empty;
                var encryptedSerial = string.Empty;
                if (!QuantumEncrypt.IsSerialNoMatchForDecryption(_encryptedBytes, _cipher, ref cipherSerial, ref encryptedSerial))
                {
                    MessageBox.Show($"Serial Numbers do not match. " +
                        $"\nCipher: {cipherSerial} " +
                        $"\nFile: {encryptedSerial}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                byte[] decryptedBytes = null;
                var reason = string.Empty;
                await Task.Run(() => decryptedBytes = QuantumEncrypt.Decrypt(_encryptedBytes, _cipher, progress, ref reason));
                watch.Stop();
                txtEncryptionTimeTicks.Text = watch.ElapsedTicks.ToString();
                // Encryption Completed.
                if (decryptedBytes == null)
                {
                    MessageBox.Show($"Decryption failed. Reason: {reason}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtOutputWindow.Text = QuantumEncrypt.HexDump(decryptedBytes);
                txtEncryptedFileSize.Text = decryptedBytes.Length.ToString();
                btnSave.Enabled = true;

                var dialog = new EncryptionCompleteDialog(false, decryptedBytes, _fileToEncryptFilename);

                //Thread.Sleep(1000);
                dialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"btnDecrypt_Click() Exception.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UpdateFormFields()
        {
            txtOutputWindow.Text = QuantumEncrypt.HexDump(_encryptedBytes);
            txtCipherSerialNo.Text = _serialNo;
            txtCipherFileSize.Text = _cipher.Length.ToString();
            txtInputFileSize.Text = (_unEncryptedBytes == null) ? string.Empty : _unEncryptedBytes.Length.ToString();
            txtEncryptedFileSize.Text = (_encryptedBytes == null) ? string.Empty : _encryptedBytes.Length.ToString();
        }
        private void maxEncryptedFileSize_Enter(object sender, EventArgs e)
        {
            maxEncryptFileSize.BackColor = Color.Empty;
        }
        private string GetRandomCipher()
        {
            var cipherLen = QuantumEncrypt.GetCipherLen(_unEncryptedBytes.Length);
            return GetRandomCipher(cipherLen);
        }
        private string GetRandomCipher(int cipherLen)
        {
            _serialNo = QuantumEncrypt.GenerateRandomSerialNumber();
            var newCipher = QuantumEncrypt.GenerateRandomCryptographicKey(cipherLen);
            return _cipherVersion + _serialNo + newCipher;
        }

        private void generateCipher_Click(object sender, EventArgs e)
        {
            if (maxEncryptFileSize.Text.Length == 0)
            {
                maxEncryptFileSize.BackColor = Color.Red;
                MessageBox.Show($"A max encrypt file size is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtCipherFileName.Text = string.Empty;
            int cipherLen;
            if (!int.TryParse(maxEncryptFileSize.Text, out cipherLen))
            {
                maxEncryptFileSize.BackColor = Color.Red;
                MessageBox.Show($"The max encrypt file size is value is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _cipher = GetRandomCipher(cipherLen);
            txtCipherFileSize.Text = _cipher.Length.ToString();
            var cipherArr = new byte[_cipher.Length];
            var idx = 0;
            QuantumEncrypt.CopyStringToByteArray(_cipher, ref cipherArr, ref idx);
            txtOutputWindow.Text = QuantumEncrypt.HexDump(cipherArr);
        }

        private void rbUseExistingCipher_CheckedChanged(object sender, EventArgs e)
        {
            btnGenerateCipher.Visible = false;
            btnSave.Enabled = false;
            maxEncryptFileSize.Enabled = false;
            txtCipherFileName.Enabled = true;
            txtCipherSerialNo.Enabled = false;
            txtInputFileSize.Enabled = false;
            txtEncryptedFilename.Enabled = true;
        }

        private void rbGenerateNewCipher_CheckedChanged(object sender, EventArgs e)
        {
            btnGenerateCipher.Visible = true;
            btnSave.Enabled = false;
            maxEncryptFileSize.Enabled = true;
            txtCipherFileName.Enabled = false;
            txtCipherSerialNo.Enabled = true;
            txtInputFileSize.Enabled = false;
            txtEncryptedFilename.Enabled = true;
        }

        private void rbAutoGenerateCipher_CheckedChanged(object sender, EventArgs e)
        {
            maxEncryptFileSize.Enabled = true;
            btnGenerateCipher.Visible = false;
            btnSave.Enabled = false;
            maxEncryptFileSize.Enabled = false;
            txtCipherFileName.Enabled = false;
            txtCipherSerialNo.Enabled = false;
            txtInputFileSize.Enabled = false;
            txtEncryptedFilename.Enabled = true;
        }

        private void btnRandomizeSerialNo_Click(object sender, EventArgs e)
        {
            txtCipherSerialNo.Text = QuantumEncrypt.GenerateRandomSerialNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_encryptedBytes == null)
            {
                MessageBox.Show($"File is not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            if (string.IsNullOrEmpty(_cipher))
            {
                MessageBox.Show($"Cipher is not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

        private async void txtEncryptedFilename_Enter(object sender, EventArgs e)
        {
            txtEncryptedFilename.BackColor = Color.Empty;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtInputFileSize.Text = string.Empty;
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    _unEncryptedBytes = File.ReadAllBytes(openFileDialog1.FileName);
                    watch.Stop();
                    txtEncryptionTimeTicks.Text = watch.ElapsedTicks.ToString();

                    if (_unEncryptedBytes == null)
                        return;
                    var fileToEncryptFilename = Path.GetFileName(openFileDialog1.FileName);
                    txtEncryptedFilename.Text = fileToEncryptFilename;
                    txtInputFileSize.Text = _unEncryptedBytes.Length.ToString();
                    var hexDump = string.Empty;
                    await Task.Run(() => hexDump = QuantumEncrypt.HexDump(_unEncryptedBytes));
                    txtOutputWindow.Text = hexDump;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception loading file.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

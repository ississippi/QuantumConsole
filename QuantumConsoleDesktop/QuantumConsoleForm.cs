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
using QuantumConsoleDesktop;
using QuantumConsoleDesktop.Models;
using QuantumConsoleDesktop.Providers;

namespace DesktopProto2
{
    public partial class QuantumConsoleForm : Form
    {
        int _userId = 1;
        const string SELECT_A_FILE_TO_ENCRYPT = "Select a file to encrypt";
        byte[] _encryptedBytes;
        byte[] _unEncryptedBytes;
        string _cipher;
        string _serialNo;
        Cipher _cipherObj;
        CipherList _cipherList = null;
        readonly string _cipherVersion = "10";
        string _fileToEncryptFilename = string.Empty;
        public QuantumConsoleForm()
        {
            InitializeComponent();
            btnSave.Enabled = true;

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

            txtCipherEncryptStartLocation.Enabled = true;
            txtCipherEncryptStartLocation.Text = "0";
        }

        private void SetText(string text)
        {
            txtCipherSerialNo.Text = text;
        }
        private async void btnEncrypt_Click(object sender, EventArgs e)
        {
            int cipherStartLocation;
            try
            {
                if (_unEncryptedBytes == null)
                {
                    txtEncryptedFilename.BackColor = Color.Red;
                    MessageBox.Show($"File to encrypt is not loaded.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(_cipher))
                {
                    txtCipherFileName.BackColor = Color.Red;
                    btnLoadSelectedCipher.BackColor = Color.Red;
                    MessageBox.Show($"No cipher loaded. \n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtCipherEncryptStartLocation.Text.Length < 1)
                {
                    txtCipherEncryptStartLocation.BackColor = Color.Red;
                    MessageBox.Show($"Must specify a value for \"Cipher Start Location After Reserved Bytes\".\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Int32.TryParse(txtCipherEncryptStartLocation.Text, out cipherStartLocation))
                {
                    txtCipherEncryptStartLocation.BackColor = Color.Red;
                    MessageBox.Show($"Cipher Start Location After Reserved Bytes value is invalid.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var progress = new Progress<int>(value =>
                {
                    progressBarECDC.Value = value;

                });
                _fileToEncryptFilename = Path.GetFileName(openFileDialog1.FileName);
                txtCipherEncryptStartLocation.Enabled = true;

                // About to Encrypt, start a timer
                var reason = string.Empty;
                var watch = System.Diagnostics.Stopwatch.StartNew();
                await Task.Run( () => _encryptedBytes = QuantumEncrypt.Encrypt(_fileToEncryptFilename, _unEncryptedBytes, _cipher, cipherStartLocation, _serialNo, progress, ref reason));
                watch.Stop();
                txtEncryptionTimeTicks.Text = watch.ElapsedTicks.ToString();
                // Encryption Completed.

                if (_encryptedBytes == null)
                {
                    MessageBox.Show($"Encryption failed.\n\nReason: {reason}\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtCipherEncryptStartLocation.Enabled = false;
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

                });

                var cipherStartLocation = QuantumEncrypt.GetCipherStartLocation(_encryptedBytes);
                if (cipherStartLocation < 0 || cipherStartLocation > _cipher.Length)
                {
                    MessageBox.Show($"Cipher Start Location from the encrypted file is not valid.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // About to Encrypt, start a timer
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
                // Passed all validations, proceed to decryption
                txtCipherEncryptStartLocation.Enabled = true;
                byte[] decryptedBytes = null;
                var reason = string.Empty;
                await Task.Run(() => decryptedBytes = QuantumEncrypt.Decrypt(_encryptedBytes, _cipher, cipherStartLocation, progress, ref reason));
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


        private async void btnGetNewCipher_Click(object sender, EventArgs e)
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
            //_cipher = GetRandomCipher(cipherLen);
            _cipherObj = await QuantumHubProvider.GetNewCipher(1, cipherLen);
            _cipher = _cipherObj.cipherString;
            SaveCipher();
            txtCipherFileSize.Text = _cipher.Length.ToString();
            txtCipherSerialNo.Text = QuantumEncrypt.GetSerialNumberFromCipher(_cipher);
            var cipherArr = new byte[_cipher.Length];
            var idx = 0;
            QuantumEncrypt.CopyStringToByteArray(_cipher, ref cipherArr, ref idx);
            txtOutputWindow.Text = QuantumEncrypt.HexDump(cipherArr);
        }
        //private void rbUseExistingCipher_CheckedChanged(object sender, EventArgs e)
        //{
        //    btnGetNewCipher.Visible = false;
        //    btnSave.Enabled = false;
        //    maxEncryptFileSize.Enabled = false;
        //    txtCipherFileName.Enabled = true;
        //    txtCipherSerialNo.Enabled = false;
        //    txtInputFileSize.Enabled = false;
        //    txtEncryptedFilename.Enabled = true;
        //    txtCipherEncryptStartLocation.Enabled = true;
        //    txtCipherEncryptStartLocation.Text = "0";
        //}

        //private void rbGenerateNewCipher_CheckedChanged(object sender, EventArgs e)
        //{
        //    btnGetNewCipher.Visible = true;
        //    btnSave.Enabled = false;
        //    maxEncryptFileSize.Enabled = true;
        //    txtCipherFileName.Enabled = false;
        //    txtCipherSerialNo.Enabled = true;
        //    txtInputFileSize.Enabled = false;
        //    txtEncryptedFilename.Enabled = true;
        //    txtCipherEncryptStartLocation.Enabled = false;
        //    txtCipherEncryptStartLocation.Text = "0";
        //}

        //private void rbAutoGenerateCipher_CheckedChanged(object sender, EventArgs e)
        //{
        //    maxEncryptFileSize.Enabled = true;
        //    btnGetNewCipher.Visible = false;
        //    btnSave.Enabled = false;
        //    maxEncryptFileSize.Enabled = false;
        //    txtCipherFileName.Enabled = false;
        //    txtCipherSerialNo.Enabled = false;
        //    txtInputFileSize.Enabled = false;
        //    txtEncryptedFilename.Enabled = true;
        //    txtCipherEncryptStartLocation.Enabled = true;
        //    txtCipherEncryptStartLocation.Text = "0";
        //}

        private void txtCipherEncryptStartLocation_Enter(object sender, EventArgs e)
        {
            txtCipherEncryptStartLocation.BackColor = Color.Empty;
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

        private void btnSaveCipher_Click(object sender, EventArgs e)
        {
            SaveCipher();
        }

        private void cipherFileName_Enter(object sender, EventArgs e)
        {
            LoadCipherFile();
        }

        private async void txtEncryptedFilename_Enter(object sender, EventArgs e)
        {
            LoadFileToEncrypt();
        }

        private void btnOpenFileToEncrypt_Click(object sender, EventArgs e)
        {
            LoadFileToEncrypt();
        }

        private void btnOpenCipherFile_Click(object sender, EventArgs e)
        {
            txtCipherFileName.BackColor = Color.Empty;
            btnLoadSelectedCipher.BackColor = Color.Empty;
            LoadCipherFile();
        }

        private async void LoadFileToEncrypt()
        {
            txtCipherEncryptStartLocation.Enabled = true;
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

        private async void LoadCipherFile()
        {
            if (openCipherDialog.ShowDialog() == DialogResult.OK)
            {
                var arr = File.ReadAllBytes(openCipherDialog.FileName);
                //btnSave.Enabled = false;
                _cipher = QuantumEncrypt.CopyBytesToString(arr, 0, arr.Length);
                _serialNo = QuantumEncrypt.GetSerialNumberFromCipher(_cipher);
                txtCipherFileName.Text = Path.GetFileName(openCipherDialog.FileName);
                maxEncryptFileSize.Text = QuantumEncrypt.GetMaxFileSizeForEncryption(_cipher).ToString();
                txtCipherSerialNo.Text = QuantumEncrypt.GetSerialNumberFromCipher(_cipher);
            }
        }

        private async void SaveCipher()
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

        private async void btnTestAPI_Click(object sender, EventArgs e)
        {
            //var c = await QuantumHubProvider.GetNewCipher(_userId, 200);
            //var c = await QuantumHubProvider.GetCipherList(_userId);
            //for(int i = 5; i < 10; i++)
            //{
            //    var cipherSend = new CipherSend
            //    {
            //        CipherId = i,
            //        SenderUserId = 3,
            //        RecipientUserId = _userId,
            //        StartingPoint = 0
            //    };
            //    var c = await QuantumHubProvider.SendCipher(cipherSend);
            //}

            //var acceptDeny = new CipherAcceptDeny
            //{
            //    CipherSendRequestId = 3,
            //    AcceptDeny = "Accepted"
            //};
            //var c = await QuantumHubProvider.AcceptDeny(acceptDeny);

            //var cipherRequest = new CipherRequest
            //{
            //    UserId = _userId,
            //    CipherId = 4
            //};
            //var c = await QuantumHubProvider.GetCipher(cipherRequest);

            //var c = await QuantumHubProvider.GetNotifications(3);

            return;
        }

        private async void btnLoadSelectedCipher_Click(object sender, EventArgs e)
        {
            if (lvCipherList.SelectedItems == null || lvCipherList.SelectedItems.Count < 1)
            {
                MessageBox.Show($"Please click to select a cipher above.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var it = lvCipherList.SelectedItems;
            var createdDTStr = it[0].SubItems[0].Text;
            var serialNo = it[0].SubItems[1].Text;

            await LoadCipherFromCipherList(_cipherList, serialNo);

            return;
        }

        private async void btnRefreshCipherList_Click(object sender, EventArgs e)
        {
            _cipherList = await QuantumHubProvider.GetCipherList(1);
            lvCipherList.Items.Clear();
            var it = 0;
            foreach (Cipher c in _cipherList.Ciphers)
            {
                lvCipherList.Items.Add(c.createdDateTime.ToString());
                lvCipherList.Items[it].SubItems.Add(c.serialNumber);
                it++;
            }
        }

        private async Task LoadCipherFromCipherList(CipherList cList, string serialNumber)
        {
            foreach(Cipher c in cList.Ciphers)
            {
                if (c.serialNumber == serialNumber)
                {
                    _cipherObj = c;
                    _cipher = c.cipherString;
                    _serialNo = c.serialNumber;
                    txtCipherFileName.Text = string.Empty;
                    txtCipherSerialNo.Text = c.serialNumber;
                    maxEncryptFileSize.Text = QuantumEncrypt.GetMaxFileSizeForEncryption(_cipher).ToString();
                    var hexDump = string.Empty;
                    await Task.Run(() => hexDump = QuantumEncrypt.HexDump(_cipher));
                    txtOutputWindow.Text = hexDump; 
                    
                    return;
                }
            }
            MessageBox.Show($"The selected Cipher was not found. SerialNumber:  {serialNumber}.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnRefreshCipherRequests_Click(object sender, EventArgs e)
        {
            var sendList = await QuantumHubProvider.GetNotifications(_userId);
            if (sendList.SendRequests.Count == 0)
            {
                MessageBox.Show($"There are no pending requests.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lvCipherRequestList.Items.Clear();
            var it = 0;
            foreach (CipherSend s in sendList.SendRequests)
            {
                lvCipherRequestList.Items.Add(s.SenderUserId.ToString());
                lvCipherRequestList.Items[it].SubItems.Add(s.CreateDate.ToString());
                lvCipherRequestList.Items[it].SubItems.Add(s.CipherSendId.ToString());
                it++;
            }
        }

        private async void lvCipherRequestList_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = lvCipherRequestList.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStripAcceptDeny.Show(Cursor.Position);
                }
            }
        }
        private async void contextMenuStripAcceptDeny_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var focusedItem = lvCipherRequestList.FocusedItem;
            var sendUserId = focusedItem.SubItems[0].Text;
            var createDate = focusedItem.SubItems[1].Text;
            var cipherSendId = focusedItem.SubItems[2].Text;
            var cipherSendIdInt = 0;
            Int32.TryParse(cipherSendId, out cipherSendIdInt);

            var acceptDenyChoice = e.ClickedItem.Text;

            var acceptDeny = new CipherAcceptDeny
            {
                UserId = _userId,
                CipherSendRequestId = cipherSendIdInt,
                AcceptDeny = acceptDenyChoice
            };
            var c = await QuantumHubProvider.AcceptDeny(acceptDeny);

            return;
        }

        private async void btnSendCipher_Click(object sender, EventArgs e)
        {
            if (_cipherObj == null || _cipherObj.cipherId < 1)
            {
                MessageBox.Show($"Cipher cannot be uploaded. There is no cipher loaded. Please load a cipher before sending.\n\nNote: Ciphers loaded from a file cannot be uploaded.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var dialog = new SendCipherDialog();
            dialog.ShowDialog();


            var cipherSend = new CipherSend
            {
                CipherId = _cipherObj.cipherId,
                SenderUserId = _userId,
                RecipientUserId = 3,
                StartingPoint = _cipherObj.startingPoint
            };
            await QuantumHubProvider.SendCipher(cipherSend);
        }
    }
}

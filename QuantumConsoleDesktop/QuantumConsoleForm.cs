using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuantumEncryptLib;
//using QuantumEncryptPoCDesktop;
using QuantumConsoleDesktop;
using QuantumConsoleDesktop.Common;
using QuantumConsoleDesktop.Models;
using QuantumConsoleDesktop.Providers;
using QuantumEncryptModels;

namespace QuantumConsoleDesktop
{
    public partial class QuantumConsoleForm : Form
    {
        int _selectedUserId = 0;
        const string SELECT_A_FILE_TO_ENCRYPT = "Select a file to encrypt";
        byte[] _encryptedBytes;
        byte[] _unEncryptedBytes;
        byte[] _loadedFileBytes;
        Cipher _cipherObj;
        CipherList _cipherList = null;
        string _fileToEncryptFilename = string.Empty;
        Dictionary<string, int> _userList;
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

            _userList = new Dictionary<string, int>();
            _userList.Add("Archer Conrad", 1);
            _userList.Add("Arvel Alma", 2);
            _userList.Add("Lavinia Esther", 3);
            _userList.Add("Milburn Carla", 4);
            _userList.Add("Kleopatros Lydos", 5);
            _userList.Add("Terence Garey", 6);
            _userList.Add("Pamillia Rilla", 7);
            _userList.Add("Marcianus Delia", 8);
            _userList.Add("Hermolaos Lance", 9);
            _userList.Add("Valerius Zenais", 10);
        }

        private void QuantumConsoleForm_Load()
        {
            //this.Text = GetQuantumConsoleVersion();
        }

        private string GetQuantumConsoleVersion()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            return version.ToString();
        }

        private void SetText(string text)
        {
            txtCipherSerialNo.Text = text;
        }
        private async void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                var spm = SetPointManager.Instance;
                if (_unEncryptedBytes == null)
                {
                    txtEncryptedFilename.BackColor = Color.Red;
                    MessageBox.Show($"File to encrypt is not loaded.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_cipherObj == null || string.IsNullOrEmpty(_cipherObj.cipherString))
                {
                    txtCipherFileName.BackColor = Color.Red;
                    btnLoadSelectedCipher.BackColor = Color.Red;
                    MessageBox.Show($"No cipher loaded. \n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var userCipherSetPoint = await spm.GetSetPoint(_selectedUserId, _cipherObj.serialNumber);
                if (userCipherSetPoint < 0)
                {
                    MessageBox.Show($"Cipher set point is not found for user for cipher serial number:{_cipherObj.serialNumber}\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var progress = new Progress<int>(value =>
                {
                    progressBarECDC.Value = value;

                });
                _fileToEncryptFilename = Path.GetFileName(openFileDialog1.FileName);

                // About to Encrypt, start a timer
                var reason = string.Empty;
                var watch = System.Diagnostics.Stopwatch.StartNew();
                await Task.Run( () => _encryptedBytes = QuantumEncrypt.Encrypt(_fileToEncryptFilename, _unEncryptedBytes, _cipherObj.cipherString, userCipherSetPoint, _cipherObj.serialNumber, progress, ref reason));
                watch.Stop();
                txtEncryptionTimeTicks.Text = watch.ElapsedTicks.ToString();
                // Encryption Completed.

                if (_encryptedBytes == null)
                {
                    MessageBox.Show($"Encryption failed.\n\nReason: {reason}\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Save current start point for a cipher segment file later if requested.
                var oldSetPoint = _cipherObj.startingPoint;
                // Set Points are incremented by the length of the last encrypted file + the length of the filename + 1 byte for the colon delimiter.
                var amountEncrypted = QuantumEncrypt.GetEncryptionLength(_unEncryptedBytes.Length, _fileToEncryptFilename.Length);
                var newSetPoint = await spm.IncrementSetPoint(_selectedUserId, _cipherObj.serialNumber, amountEncrypted);
                txtSetPoint.Text = newSetPoint.ToString();
                btnSave.Enabled = true;
                maxEncryptFileSize.Text = QuantumEncrypt.GetMaxFileSizeForEncryption(_cipherObj, newSetPoint).ToString();
                UpdateFormFields();

                var dialog = new EncryptionCompleteDialog(true, _encryptedBytes, _fileToEncryptFilename);

                //Thread.Sleep(1000);
                dialog.ShowDialog();
                dialog.Dispose();

                if (chkSpawnSegment.Checked == true)
                {
                    var segmentSerial = await CipherSegmentManager.GetNewSegmentSerialNumber(_selectedUserId);
                    var newSegmentCipher = QuantumEncrypt.SpawnCipherFromSegment(_selectedUserId, _cipherObj, segmentSerial, oldSetPoint, amountEncrypted);
                    var cipherSegmentDialog = new SaveCipherForm(newSegmentCipher);
                    cipherSegmentDialog.ShowDialog();
                    await QuantumHubProvider.UploadCipher(newSegmentCipher);
                    cipherSegmentDialog.Dispose();
                }
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
                if (_cipherObj == null)
                {
                    MessageBox.Show($"No cipher is loaded.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_encryptedBytes == null)
                {
                    MessageBox.Show($"File to decrypt is not loaded.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var progress = new Progress<int>(value =>
                {
                    progressBarECDC.Value = value;

                });

                // About to Encrypt, start a timer
                var watch = System.Diagnostics.Stopwatch.StartNew();
                // Passed all validations, proceed to decryption
                byte[] decryptedBytes = null;
                var reason = string.Empty;
                await Task.Run(() => decryptedBytes = QuantumEncrypt.Decrypt(_encryptedBytes, _cipherObj, progress, ref reason));
                watch.Stop();
                txtEncryptionTimeTicks.Text = watch.ElapsedTicks.ToString();
                // Encryption Completed.
                if (decryptedBytes == null)
                {
                    MessageBox.Show($"Decryption failed. Reason: {reason}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _unEncryptedBytes = decryptedBytes;

                txtOutputWindow.Text = QuantumEncrypt.HexDump(_unEncryptedBytes);
                txtEncryptedFileSize.Text = _unEncryptedBytes.Length.ToString();
                btnSave.Enabled = true;

                var dialog = new EncryptionCompleteDialog(false, _unEncryptedBytes, _fileToEncryptFilename);

                //Thread.Sleep(1000);
                dialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"btnDecrypt_Click() Exception.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task SwitchLoggedInUser()
        {
            _encryptedBytes = null;
            _unEncryptedBytes = null;
            _loadedFileBytes = null;
            _cipherObj = null;
            _cipherList = null;
            _fileToEncryptFilename = string.Empty;

            ResetFormFieldBackColor();
            maxEncryptFileSize.Text = string.Empty;
            txtCipherFileSize.Text = string.Empty;
            txtCipherFileName.Text = string.Empty;
            txtCipherSerialNo.Text = string.Empty;
            txtEncryptedFilename.Text = string.Empty;
            txtEncryptedFileSize.Text = string.Empty;
            txtEncryptionTimeTicks.Text = string.Empty;
            txtOutputWindow.Text = string.Empty;
            txtInputFileSize.Text = string.Empty;
            txtSetPoint.Text = string.Empty;

            await RefreshCipherRequests(true);
            await RefreshCipherList(true);

        }

        private void ResetFormFieldBackColor()
        {
            maxEncryptFileSize.BackColor = Color.Empty;
            txtCipherFileSize.BackColor = Color.Empty;
            txtCipherFileName.BackColor = Color.Empty;
            txtCipherSerialNo.BackColor = Color.Empty;
            txtEncryptedFilename.BackColor = Color.Empty;
            txtEncryptedFileSize.BackColor = Color.Empty;
            txtEncryptionTimeTicks.BackColor = Color.Empty;
            txtOutputWindow.BackColor = Color.Empty;
            txtInputFileSize.BackColor = Color.Empty;
            txtSetPoint.BackColor = Color.Empty;
        }
        private void UpdateFormFields()
        {
            txtOutputWindow.Text = QuantumEncrypt.HexDump(_encryptedBytes);
            txtCipherSerialNo.Text = (_cipherObj != null) ? _cipherObj.serialNumber : string.Empty;
            txtCipherFileSize.Text = (_cipherObj != null) ? _cipherObj.cipherString.Length.ToString() : "0";
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
            _cipherObj = await QuantumHubProvider.GetNewCipher(_selectedUserId, cipherLen);
            SaveCipher();
            var spm = SetPointManager.Instance;
            await spm.AddNewCipher(_selectedUserId, _cipherObj.serialNumber);
            txtCipherFileSize.Text = _cipherObj.cipherString.Length.ToString();
            txtCipherSerialNo.Text = QuantumEncrypt.GetSerialNumberFromCipher(_cipherObj.cipherString);
            txtSetPoint.Text = _cipherObj.startingPoint.ToString();
            var cipherArr = new byte[_cipherObj.cipherString.Length];
            var idx = 0;
            QuantumEncrypt.CopyStringToByteArray(_cipherObj.cipherString, ref cipherArr, ref idx);
            txtOutputWindow.Text = QuantumEncrypt.HexDump(cipherArr);
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
            LoadFileToEncryptOrDecrypt();
        }

        private void btnOpenFileToEncrypt_Click(object sender, EventArgs e)
        {
            LoadFileToEncryptOrDecrypt();
        }

        private void btnOpenCipherFile_Click(object sender, EventArgs e)
        {
            txtCipherFileName.BackColor = Color.Empty;
            btnLoadSelectedCipher.BackColor = Color.Empty;
            LoadCipherFile();
        }

        private async void LoadFileToEncryptOrDecrypt()
        {
            ResetFormFieldBackColor();
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtInputFileSize.Text = string.Empty;
                    _loadedFileBytes = File.ReadAllBytes(openFileDialog1.FileName);
                    if (_loadedFileBytes == null)
                    {
                        MessageBox.Show($"File is empty or unable to load.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var fileType = Path.GetExtension(openFileDialog1.FileName);
                    if (fileType.ToLower() == ".qlock")
                    {
                        _encryptedBytes = _loadedFileBytes;
                        var fileToDecryptFilename = Path.GetFileName(openFileDialog1.FileName);
                        txtEncryptedFilename.Text = fileToDecryptFilename;
                        var serialNumber = QuantumEncrypt.GetSerialNumberFromEncryptedBytes(_encryptedBytes);
                        if (_cipherList != null)
                            await LoadCipherFromCipherList(_cipherList, serialNumber);
                    }
                    else
                    {
                        _unEncryptedBytes = _loadedFileBytes;
                        var fileToEncryptFilename = Path.GetFileName(openFileDialog1.FileName);
                        txtEncryptedFilename.Text = fileToEncryptFilename;
                    }

                    txtInputFileSize.Text = _loadedFileBytes.Length.ToString();
                    var hexDump = string.Empty;
                    await Task.Run(() => hexDump = QuantumEncrypt.HexDump(_loadedFileBytes));
                    txtOutputWindow.Text = hexDump;

                    if ((_unEncryptedBytes != null && _unEncryptedBytes.Length > 1) && (_cipherObj != null && _cipherObj.cipherString.Length > 1))
                    {
                        var usableCipherLen = -1;
                        if (!QuantumEncrypt.IsCipherLargeEnough(_unEncryptedBytes.Length, _cipherObj.cipherString, _cipherObj.startingPoint, ref usableCipherLen))
                        {
                            maxEncryptFileSize.BackColor = Color.Red;
                        }
                    }

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
            ResetFormFieldBackColor();
            if (openCipherDialog.ShowDialog() == DialogResult.OK)
            {
                var arr = File.ReadAllBytes(openCipherDialog.FileName);
                //btnSave.Enabled = false;
                if (_cipherObj == null)
                    _cipherObj = new Cipher();
                _cipherObj.cipherString = QuantumEncrypt.CopyBytesToString(arr, 0, arr.Length);
                _cipherObj.serialNumber = QuantumEncrypt.GetSerialNumberFromCipher(_cipherObj.cipherString);
                txtCipherSerialNo.Text = _cipherObj.serialNumber;
                txtCipherFileName.Text = Path.GetFileName(openCipherDialog.FileName);
                var spm = SetPointManager.Instance;
                await spm.AddNewCipher(_selectedUserId, _cipherObj.serialNumber);
                var setPoint = await LoadSetPoint();
                txtSetPoint.Text = _cipherObj.startingPoint.ToString();
                maxEncryptFileSize.Text = QuantumEncrypt.GetMaxFileSizeForEncryption(_cipherObj, setPoint).ToString();
            }
        }
        private async void SaveCipher(Cipher cipherObj)
        {
            if (saveCipherDialog.ShowDialog() == DialogResult.OK)
            {
                var cipherBytes = new byte[cipherObj.cipherString.Length];
                var idx = 0;
                QuantumEncrypt.CopyStringToByteArray(_cipherObj.cipherString, ref cipherBytes, ref idx);
                if (saveCipherDialog.FileName != "")
                {
                    // default extension for saved encrypted files to be .qlock
                    FileStream fs = (System.IO.FileStream)saveCipherDialog.OpenFile();
                    fs.Write(cipherBytes, 0, cipherObj.cipherString.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
        }

        private async void SaveCipher()
        {
            if (_cipherObj == null || string.IsNullOrEmpty(_cipherObj.cipherString))
            {
                MessageBox.Show($"Cipher is not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (saveCipherDialog.ShowDialog() == DialogResult.OK)
            {
                var cipherBytes = new byte[_cipherObj.cipherString.Length];
                var idx = 0;
                QuantumEncrypt.CopyStringToByteArray(_cipherObj.cipherString, ref cipherBytes, ref idx);
                if (saveCipherDialog.FileName != "")
                {
                    // default extension for saved encrypted files to be .qlock
                    FileStream fs = (System.IO.FileStream)saveCipherDialog.OpenFile();
                    fs.Write(cipherBytes, 0, _cipherObj.cipherString.Length);
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
            var maxEncryptionLength = it[0].SubItems[1].Text;
            var serialNo = it[0].SubItems[2].Text;

            await LoadCipherFromCipherList(_cipherList, serialNo);

            return;
        }

        private async void btnRefreshCipherList_Click(object sender, EventArgs e)
        {
            await RefreshCipherListFromHub();
        }

        private async Task RefreshCipherListFromHub()
        {
            await RefreshCipherList();
            if (_cipherList == null || _cipherList.Ciphers == null || _cipherList.Ciphers.Count == 0)
                return;
        }

        private async Task RefreshCipherList(bool supressNoRequests = false)
        {
            var progress = new Progress<int>(value =>
            {
                progressBarECDC.Value = value;

            });
            var reportProgress = (IProgress<int>)progress;
            reportProgress.Report(5);

            if (_selectedUserId == 0)
            {
                cbLoginUsername.BackColor = Color.Red;
                MessageBox.Show($"Please select a user.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reportProgress.Report(100);
                return;
            }
            reportProgress.Report(10);
            _cipherList = await QuantumHubProvider.GetCipherList(_selectedUserId);
            reportProgress.Report(75);
            lvCipherList.Items.Clear();
            if (_cipherList == null || _cipherList.Ciphers.Count == 0)
            {
                if (!supressNoRequests)
                    MessageBox.Show($"The current user has no ciphers.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reportProgress.Report(100);
                return;
            }
            var it = 0;
            foreach (Cipher c in _cipherList.Ciphers)
            {
                lvCipherList.Items.Add(c.createdDateTime.ToString());
                lvCipherList.Items[it].SubItems.Add(c.maxEncryptionLength.ToString());
                lvCipherList.Items[it].SubItems.Add(c.serialNumber);
                it++;
            }
            reportProgress.Report(85);

            var spManager = SetPointManager.Instance;
            var isInSync = await spManager.IsSetPointListInSync(_selectedUserId, _cipherList);
            if (!isInSync && _cipherList != null && _cipherList.Ciphers.Count > 0)
            {
                await spManager.SyncSetPointList(_selectedUserId, _cipherList);
            }
            reportProgress.Report(100);

        }

        private async Task LoadCipherFromCipherList(CipherList cList, string serialNumber)
        {
            ResetFormFieldBackColor();
            foreach (Cipher c in cList.Ciphers)
            {
                if (c.serialNumber == serialNumber)
                {
                    _cipherObj = c;
                    txtCipherFileName.Text = string.Empty;
                    txtCipherSerialNo.Text = c.serialNumber;
                    var setPoint = await LoadSetPoint();
                    maxEncryptFileSize.Text = QuantumEncrypt.GetMaxFileSizeForEncryption(_cipherObj, setPoint).ToString();
                    txtSetPoint.Text = setPoint.ToString();
                    _cipherObj.startingPoint = setPoint;
                    var hexDump = string.Empty;
                    await Task.Run(() => hexDump = QuantumEncrypt.HexDump(_cipherObj.cipherString));
                    txtOutputWindow.Text = hexDump;
                    if (_unEncryptedBytes != null && _unEncryptedBytes.Length > 1)
                    {
                        var usableCipherLen = -1;
                        if (!QuantumEncrypt.IsCipherLargeEnough(_unEncryptedBytes.Length, _cipherObj.cipherString, setPoint, ref usableCipherLen))
                        {
                            maxEncryptFileSize.BackColor = Color.Red;
                        }
                    }
                    return;
                }
            }
            MessageBox.Show($"There is no cipher with a matching Serial Number. SerialNumber:  {serialNumber}.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnRefreshCipherRequests_Click(object sender, EventArgs e)
        {
            await RefreshCipherRequests();
        }

        private async Task RefreshCipherRequests(bool supressNoRequests = false)
        {
            var progress = new Progress<int>(value =>
            {
                progressBarECDC.Value = value;

            });
            var reportProgress = (IProgress<int>)progress;
            reportProgress.Report(5);

            lvCipherRequestList.Items.Clear();
            if (_selectedUserId == 0)
            {
                cbLoginUsername.BackColor = Color.Red;
                MessageBox.Show($"Please select a user.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reportProgress.Report(100);

                return;
            }
            reportProgress.Report(10);
            var sendList = await QuantumHubProvider.GetNotifications(_selectedUserId, "pending");
            if (sendList == null || sendList.SendRequests == null || sendList.SendRequests.Count == 0)
            {
                if (!supressNoRequests)
                    MessageBox.Show($"There are no pending requests.\n\n", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reportProgress.Report(100);
                return;
            }
            reportProgress.Report(80);

            var it = 0;
            foreach (CipherSend s in sendList.SendRequests)
            {
                lvCipherRequestList.Items.Add(GetUserNameFromId(s.SenderUserId));
                lvCipherRequestList.Items[it].SubItems.Add(s.CreateDate.ToString());
                lvCipherRequestList.Items[it].SubItems.Add(s.MaxEncryptionLength.ToString());
                lvCipherRequestList.Items[it].SubItems.Add(s.CipherSendId.ToString());
                it++;
            }
            reportProgress.Report(100);
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
            var maxEncryptionLength = focusedItem.SubItems[2].Text;
            var cipherSendId = focusedItem.SubItems[3].Text;
            var cipherSendIdInt = 0;
            Int32.TryParse(cipherSendId, out cipherSendIdInt);

            var acceptDenyChoice = e.ClickedItem.Text;

            var acceptDeny = new CipherAcceptDeny
            {
                UserId = _selectedUserId,
                CipherSendRequestId = cipherSendIdInt,
                AcceptDeny = acceptDenyChoice
            };
            var c = await QuantumHubProvider.AcceptDeny(acceptDeny);
            await RefreshCipherRequests(true);
            await RefreshCipherList(true);

            return;
        }


        private async void lvCipherList_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = lvCipherList.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuCipherList.Show(Cursor.Position);
                }
            }
        }
        private async void lvCipherList_DoubleClick(object sender, MouseEventArgs e)
        {
            var focusedItem = lvCipherList.FocusedItem;
            var createDate = focusedItem.SubItems[0].Text;
            var maxEncryptionLength = focusedItem.SubItems[1].Text;
            var serialNumber = focusedItem.SubItems[2].Text;

            await LoadCipherFromCipherList(_cipherList, serialNumber);
        }
        private async void contextMenuCipherList_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var focusedItem = lvCipherList.FocusedItem;
            var createDate = focusedItem.SubItems[0].Text;
            var maxEncryptionLength = focusedItem.SubItems[1].Text;
            var serialNumber = focusedItem.SubItems[2].Text;
            var cipherSendIdInt = 0;

            var menuChoice = e.ClickedItem.Text;

            if (menuChoice == "Send")
            {
                await LoadCipherFromCipherList(_cipherList, serialNumber);
                await SendCipher();
            }
            else if (menuChoice == "Load")
            {
                await LoadCipherFromCipherList(_cipherList, serialNumber);
            }

            await RefreshCipherRequests(true);
            await RefreshCipherList(true);

            return;
        }

        private async void btnSendCipher_Click(object sender, EventArgs e)
        {
            if (_cipherObj == null || _cipherObj.cipherId < 1)
            {
                MessageBox.Show($"Cipher cannot be uploaded. There is no cipher loaded. Please load a cipher before sending.\n\nNote: Ciphers loaded from a file cannot be uploaded.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await SendCipher();

        }

        private async Task SendCipher()
        {
            var dialogSend = new SendCipherDialog(_userList);
            dialogSend.ShowDialog();
            if (dialogSend.RecipientUserId == 0)
            {
                MessageBox.Show($"No Recipient user selected.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cipherSend = new CipherSend
            {
                CipherId = _cipherObj.cipherId,
                SenderUserId = _selectedUserId,
                RecipientUserId = dialogSend.RecipientUserId,
                StartingPoint = _cipherObj.startingPoint
            };
            await QuantumHubProvider.SendCipher(cipherSend);
        }

        private async void cbLoginUsername_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbLoginUsername.BackColor = Color.Empty;
            _userList.TryGetValue(cbLoginUsername.SelectedItem.ToString(), out _selectedUserId);
            SwitchLoggedInUser();
        }

        private void cbLoginUsername_Click(object sender, EventArgs e)
        {
            cbLoginUsername.BackColor = Color.Empty;
        }

        private void cbLoginUsername_DropDown(object sender, EventArgs e)
        {
            cbLoginUsername.BackColor = Color.Empty;
        }

        private string GetUserNameFromId(int userId)
        {
            foreach(var name in _userList.Keys)
            {
                if (userId == _userList[name])
                    return name;
            }
            return string.Empty;
        }

        private async Task<int> LoadSetPoint()
        {
            var spm = SetPointManager.Instance;
            var setPoint = await spm.GetSetPoint(_selectedUserId, _cipherObj.serialNumber);
            txtSetPoint.Text = setPoint.ToString();
            return setPoint;
        }
    }
}

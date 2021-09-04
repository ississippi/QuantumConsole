
namespace DesktopProto2
{
    partial class QuantumConsoleForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuantumConsoleForm));
            this.txtCipherSerialNo = new System.Windows.Forms.TextBox();
            this.txtOutputWindow = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetNewCipher = new System.Windows.Forms.Button();
            this.maxEncryptFileSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCipherFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEncryptedFilename = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEncryptedFileSize = new System.Windows.Forms.TextBox();
            this.txtEncryptionTimeTicks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInputFileSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCipherFileSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.saveCipherDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveCipher = new System.Windows.Forms.Button();
            this.labelApplicationTitle = new System.Windows.Forms.Label();
            this.openCipherDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.progressBarECDC = new System.Windows.Forms.ProgressBar();
            this.btnOpenFileToEncrypt = new System.Windows.Forms.Button();
            this.btnOpenCipherFile = new System.Windows.Forms.Button();
            this.txtCipherEncryptStartLocation = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLoadSelectedCipher = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnUploadCipher = new System.Windows.Forms.Button();
            this.btnRefreshCipherList = new System.Windows.Forms.Button();
            this.lvCipherList = new System.Windows.Forms.ListView();
            this.colCreated = new System.Windows.Forms.ColumnHeader();
            this.colMaxEncrypt = new System.Windows.Forms.ColumnHeader();
            this.colSerialNumber = new System.Windows.Forms.ColumnHeader();
            this.lvCipherRequestList = new System.Windows.Forms.ListView();
            this.colRequestFrom = new System.Windows.Forms.ColumnHeader();
            this.colRequestDateTIme = new System.Windows.Forms.ColumnHeader();
            this.colRequestCipherLen = new System.Windows.Forms.ColumnHeader();
            this.colSendId = new System.Windows.Forms.ColumnHeader();
            this.label12 = new System.Windows.Forms.Label();
            this.btnRefreshCipherRequests = new System.Windows.Forms.Button();
            this.contextMenuStripAcceptDeny = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.acceptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.denyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSendCipher = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cbLoginUsername = new System.Windows.Forms.ComboBox();
            this.contextMenuCipherList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSetPoint = new System.Windows.Forms.TextBox();
            this.contextMenuStripAcceptDeny.SuspendLayout();
            this.contextMenuCipherList.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCipherSerialNo
            // 
            this.txtCipherSerialNo.Location = new System.Drawing.Point(67, 332);
            this.txtCipherSerialNo.Name = "txtCipherSerialNo";
            this.txtCipherSerialNo.Size = new System.Drawing.Size(230, 23);
            this.txtCipherSerialNo.TabIndex = 1;
            // 
            // txtOutputWindow
            // 
            this.txtOutputWindow.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOutputWindow.Location = new System.Drawing.Point(309, 92);
            this.txtOutputWindow.Multiline = true;
            this.txtOutputWindow.Name = "txtOutputWindow";
            this.txtOutputWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutputWindow.Size = new System.Drawing.Size(585, 466);
            this.txtOutputWindow.TabIndex = 2;
            this.txtOutputWindow.Enter += new System.EventHandler(this.txtCipherEncryptStartLocation_Enter);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Loaded Cipher Serial Number";
            // 
            // btnGetNewCipher
            // 
            this.btnGetNewCipher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGetNewCipher.Location = new System.Drawing.Point(67, 128);
            this.btnGetNewCipher.Name = "btnGetNewCipher";
            this.btnGetNewCipher.Size = new System.Drawing.Size(230, 42);
            this.btnGetNewCipher.TabIndex = 7;
            this.btnGetNewCipher.Text = "Get a New Cipher From Hub";
            this.btnGetNewCipher.UseVisualStyleBackColor = true;
            this.btnGetNewCipher.Click += new System.EventHandler(this.btnGetNewCipher_Click);
            // 
            // maxEncryptFileSize
            // 
            this.maxEncryptFileSize.Location = new System.Drawing.Point(188, 379);
            this.maxEncryptFileSize.Name = "maxEncryptFileSize";
            this.maxEncryptFileSize.Size = new System.Drawing.Size(109, 23);
            this.maxEncryptFileSize.TabIndex = 8;
            this.maxEncryptFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maxEncryptFileSize.Click += new System.EventHandler(this.maxEncryptedFileSize_Enter);
            this.maxEncryptFileSize.Enter += new System.EventHandler(this.maxEncryptedFileSize_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Max Encrypt Size";
            // 
            // txtCipherFileName
            // 
            this.txtCipherFileName.Location = new System.Drawing.Point(67, 238);
            this.txtCipherFileName.Name = "txtCipherFileName";
            this.txtCipherFileName.Size = new System.Drawing.Size(199, 23);
            this.txtCipherFileName.TabIndex = 10;
            this.txtCipherFileName.Enter += new System.EventHandler(this.cipherFileName_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Load a Cipher File";
            // 
            // txtEncryptedFilename
            // 
            this.txtEncryptedFilename.Location = new System.Drawing.Point(67, 191);
            this.txtEncryptedFilename.Name = "txtEncryptedFilename";
            this.txtEncryptedFilename.Size = new System.Drawing.Size(199, 23);
            this.txtEncryptedFilename.TabIndex = 12;
            this.txtEncryptedFilename.Enter += new System.EventHandler(this.txtEncryptedFilename_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Load a File to Encrypt or Decrypt";
            // 
            // txtEncryptedFileSize
            // 
            this.txtEncryptedFileSize.Enabled = false;
            this.txtEncryptedFileSize.Location = new System.Drawing.Point(458, 67);
            this.txtEncryptedFileSize.Name = "txtEncryptedFileSize";
            this.txtEncryptedFileSize.Size = new System.Drawing.Size(122, 23);
            this.txtEncryptedFileSize.TabIndex = 16;
            this.txtEncryptedFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEncryptionTimeTicks
            // 
            this.txtEncryptionTimeTicks.Enabled = false;
            this.txtEncryptionTimeTicks.Location = new System.Drawing.Point(309, 67);
            this.txtEncryptionTimeTicks.Name = "txtEncryptionTimeTicks";
            this.txtEncryptionTimeTicks.Size = new System.Drawing.Size(122, 23);
            this.txtEncryptionTimeTicks.TabIndex = 17;
            this.txtEncryptionTimeTicks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(458, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Encrypted File Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Encryption Time Ticks";
            // 
            // txtInputFileSize
            // 
            this.txtInputFileSize.Enabled = false;
            this.txtInputFileSize.Location = new System.Drawing.Point(607, 67);
            this.txtInputFileSize.Name = "txtInputFileSize";
            this.txtInputFileSize.Size = new System.Drawing.Size(122, 23);
            this.txtInputFileSize.TabIndex = 20;
            this.txtInputFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(607, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Input File Size";
            // 
            // txtCipherFileSize
            // 
            this.txtCipherFileSize.Enabled = false;
            this.txtCipherFileSize.Location = new System.Drawing.Point(756, 67);
            this.txtCipherFileSize.Name = "txtCipherFileSize";
            this.txtCipherFileSize.Size = new System.Drawing.Size(122, 23);
            this.txtCipherFileSize.TabIndex = 22;
            this.txtCipherFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(756, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 15);
            this.label8.TabIndex = 23;
            this.label8.Text = "Cipher File Size";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(67, 468);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 42);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save Encrypted File";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDecrypt.Location = new System.Drawing.Point(188, 420);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(115, 42);
            this.btnDecrypt.TabIndex = 25;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnSaveCipher
            // 
            this.btnSaveCipher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveCipher.Location = new System.Drawing.Point(188, 468);
            this.btnSaveCipher.Name = "btnSaveCipher";
            this.btnSaveCipher.Size = new System.Drawing.Size(115, 42);
            this.btnSaveCipher.TabIndex = 26;
            this.btnSaveCipher.Text = "Save Cipher";
            this.btnSaveCipher.UseVisualStyleBackColor = true;
            this.btnSaveCipher.Click += new System.EventHandler(this.btnSaveCipher_Click);
            // 
            // labelApplicationTitle
            // 
            this.labelApplicationTitle.AutoSize = true;
            this.labelApplicationTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelApplicationTitle.Location = new System.Drawing.Point(309, 9);
            this.labelApplicationTitle.Name = "labelApplicationTitle";
            this.labelApplicationTitle.Size = new System.Drawing.Size(255, 30);
            this.labelApplicationTitle.TabIndex = 27;
            this.labelApplicationTitle.Text = "QuantumLock Encryption";
            // 
            // openCipherDialog
            // 
            this.openCipherDialog.FileName = "openFileDialog2";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEncrypt.Location = new System.Drawing.Point(67, 420);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(115, 42);
            this.btnEncrypt.TabIndex = 28;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // progressBarECDC
            // 
            this.progressBarECDC.Location = new System.Drawing.Point(309, 559);
            this.progressBarECDC.Name = "progressBarECDC";
            this.progressBarECDC.Size = new System.Drawing.Size(585, 10);
            this.progressBarECDC.TabIndex = 29;
            // 
            // btnOpenFileToEncrypt
            // 
            this.btnOpenFileToEncrypt.Image = global::QuantumConsoleDesktop.Properties.Resources.icons8_folder_16;
            this.btnOpenFileToEncrypt.Location = new System.Drawing.Point(272, 191);
            this.btnOpenFileToEncrypt.Name = "btnOpenFileToEncrypt";
            this.btnOpenFileToEncrypt.Size = new System.Drawing.Size(25, 23);
            this.btnOpenFileToEncrypt.TabIndex = 30;
            this.btnOpenFileToEncrypt.UseVisualStyleBackColor = true;
            this.btnOpenFileToEncrypt.Click += new System.EventHandler(this.btnOpenFileToEncrypt_Click);
            // 
            // btnOpenCipherFile
            // 
            this.btnOpenCipherFile.Image = global::QuantumConsoleDesktop.Properties.Resources.icons8_folder_16;
            this.btnOpenCipherFile.Location = new System.Drawing.Point(272, 237);
            this.btnOpenCipherFile.Name = "btnOpenCipherFile";
            this.btnOpenCipherFile.Size = new System.Drawing.Size(25, 23);
            this.btnOpenCipherFile.TabIndex = 31;
            this.btnOpenCipherFile.UseVisualStyleBackColor = true;
            this.btnOpenCipherFile.Click += new System.EventHandler(this.btnOpenCipherFile_Click);
            // 
            // txtCipherEncryptStartLocation
            // 
            this.txtCipherEncryptStartLocation.Location = new System.Drawing.Point(67, 285);
            this.txtCipherEncryptStartLocation.Name = "txtCipherEncryptStartLocation";
            this.txtCipherEncryptStartLocation.Size = new System.Drawing.Size(230, 23);
            this.txtCipherEncryptStartLocation.TabIndex = 32;
            this.txtCipherEncryptStartLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCipherEncryptStartLocation.Enter += new System.EventHandler(this.txtCipherEncryptStartLocation_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(67, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(228, 15);
            this.label10.TabIndex = 33;
            this.label10.Text = "Cipher Start Location After Reserved Bytes";
            // 
            // btnLoadSelectedCipher
            // 
            this.btnLoadSelectedCipher.Location = new System.Drawing.Point(900, 279);
            this.btnLoadSelectedCipher.Name = "btnLoadSelectedCipher";
            this.btnLoadSelectedCipher.Size = new System.Drawing.Size(136, 34);
            this.btnLoadSelectedCipher.TabIndex = 36;
            this.btnLoadSelectedCipher.Text = "Load Selected Cipher";
            this.btnLoadSelectedCipher.UseVisualStyleBackColor = true;
            this.btnLoadSelectedCipher.Click += new System.EventHandler(this.btnLoadSelectedCipher_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(900, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 15);
            this.label11.TabIndex = 37;
            this.label11.Text = "My Ciphers Saved at the Hub";
            // 
            // btnUploadCipher
            // 
            this.btnUploadCipher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUploadCipher.Location = new System.Drawing.Point(188, 516);
            this.btnUploadCipher.Name = "btnUploadCipher";
            this.btnUploadCipher.Size = new System.Drawing.Size(115, 42);
            this.btnUploadCipher.TabIndex = 39;
            this.btnUploadCipher.Text = "Upload Loaded Cipher to Hub";
            this.btnUploadCipher.UseVisualStyleBackColor = true;
            // 
            // btnRefreshCipherList
            // 
            this.btnRefreshCipherList.Location = new System.Drawing.Point(1042, 279);
            this.btnRefreshCipherList.Name = "btnRefreshCipherList";
            this.btnRefreshCipherList.Size = new System.Drawing.Size(136, 34);
            this.btnRefreshCipherList.TabIndex = 40;
            this.btnRefreshCipherList.Text = "Refresh Cipher List";
            this.btnRefreshCipherList.UseVisualStyleBackColor = true;
            this.btnRefreshCipherList.Click += new System.EventHandler(this.btnRefreshCipherList_Click);
            // 
            // lvCipherList
            // 
            this.lvCipherList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCreated,
            this.colMaxEncrypt,
            this.colSerialNumber});
            this.lvCipherList.FullRowSelect = true;
            this.lvCipherList.GridLines = true;
            this.lvCipherList.HideSelection = false;
            this.lvCipherList.Location = new System.Drawing.Point(900, 92);
            this.lvCipherList.MultiSelect = false;
            this.lvCipherList.Name = "lvCipherList";
            this.lvCipherList.Size = new System.Drawing.Size(370, 180);
            this.lvCipherList.TabIndex = 41;
            this.lvCipherList.UseCompatibleStateImageBehavior = false;
            this.lvCipherList.View = System.Windows.Forms.View.Details;
            this.lvCipherList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvCipherList_Click);
            this.lvCipherList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvCipherList_DoubleClick);
            // 
            // colCreated
            // 
            this.colCreated.Text = "Created";
            this.colCreated.Width = 120;
            // 
            // colMaxEncrypt
            // 
            this.colMaxEncrypt.Text = "MaxEncrypt";
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.Text = "Serial Number";
            this.colSerialNumber.Width = 470;
            // 
            // lvCipherRequestList
            // 
            this.lvCipherRequestList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRequestFrom,
            this.colRequestDateTIme,
            this.colRequestCipherLen,
            this.colSendId});
            this.lvCipherRequestList.FullRowSelect = true;
            this.lvCipherRequestList.GridLines = true;
            this.lvCipherRequestList.HideSelection = false;
            this.lvCipherRequestList.Location = new System.Drawing.Point(900, 338);
            this.lvCipherRequestList.MultiSelect = false;
            this.lvCipherRequestList.Name = "lvCipherRequestList";
            this.lvCipherRequestList.Size = new System.Drawing.Size(370, 180);
            this.lvCipherRequestList.TabIndex = 42;
            this.lvCipherRequestList.UseCompatibleStateImageBehavior = false;
            this.lvCipherRequestList.View = System.Windows.Forms.View.Details;
            this.lvCipherRequestList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvCipherRequestList_Click);
            // 
            // colRequestFrom
            // 
            this.colRequestFrom.Text = "From";
            this.colRequestFrom.Width = 150;
            // 
            // colRequestDateTIme
            // 
            this.colRequestDateTIme.Text = "Sent";
            this.colRequestDateTIme.Width = 130;
            // 
            // colRequestCipherLen
            // 
            this.colRequestCipherLen.Text = "Cipher Length";
            this.colRequestCipherLen.Width = 100;
            // 
            // colSendId
            // 
            this.colSendId.Text = "SendId";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(900, 320);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(146, 15);
            this.label12.TabIndex = 43;
            this.label12.Text = "Incoming Cipher Requests";
            // 
            // btnRefreshCipherRequests
            // 
            this.btnRefreshCipherRequests.Location = new System.Drawing.Point(900, 524);
            this.btnRefreshCipherRequests.Name = "btnRefreshCipherRequests";
            this.btnRefreshCipherRequests.Size = new System.Drawing.Size(160, 34);
            this.btnRefreshCipherRequests.TabIndex = 44;
            this.btnRefreshCipherRequests.Text = "Refresh Cipher Requests";
            this.btnRefreshCipherRequests.UseVisualStyleBackColor = true;
            this.btnRefreshCipherRequests.Click += new System.EventHandler(this.btnRefreshCipherRequests_Click);
            // 
            // contextMenuStripAcceptDeny
            // 
            this.contextMenuStripAcceptDeny.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acceptToolStripMenuItem,
            this.denyToolStripMenuItem});
            this.contextMenuStripAcceptDeny.Name = "contextMenuStrip1";
            this.contextMenuStripAcceptDeny.Size = new System.Drawing.Size(112, 48);
            this.contextMenuStripAcceptDeny.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripAcceptDeny_ItemClicked);
            // 
            // acceptToolStripMenuItem
            // 
            this.acceptToolStripMenuItem.Name = "acceptToolStripMenuItem";
            this.acceptToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.acceptToolStripMenuItem.Text = "Accept";
            // 
            // denyToolStripMenuItem
            // 
            this.denyToolStripMenuItem.Name = "denyToolStripMenuItem";
            this.denyToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.denyToolStripMenuItem.Text = "Deny";
            // 
            // btnSendCipher
            // 
            this.btnSendCipher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSendCipher.Location = new System.Drawing.Point(67, 516);
            this.btnSendCipher.Name = "btnSendCipher";
            this.btnSendCipher.Size = new System.Drawing.Size(115, 42);
            this.btnSendCipher.TabIndex = 45;
            this.btnSendCipher.Text = "Send Cipher";
            this.btnSendCipher.UseVisualStyleBackColor = true;
            this.btnSendCipher.Click += new System.EventHandler(this.btnSendCipher_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(67, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 15);
            this.label13.TabIndex = 48;
            this.label13.Text = "Username";
            // 
            // cbLoginUsername
            // 
            this.cbLoginUsername.FormattingEnabled = true;
            this.cbLoginUsername.Items.AddRange(new object[] {
            "Archer Conrad",
            "Arvel Alma",
            "Lavinia Esther",
            "Milburn Carla",
            "Kleopatros Lydos",
            "Terence Garey",
            "Pamillia Rilla",
            "Marcianus Delia",
            "Hermolaos Lance",
            "Valerius Zenais"});
            this.cbLoginUsername.Location = new System.Drawing.Point(67, 99);
            this.cbLoginUsername.Name = "cbLoginUsername";
            this.cbLoginUsername.Size = new System.Drawing.Size(228, 23);
            this.cbLoginUsername.TabIndex = 46;
            this.cbLoginUsername.DropDown += new System.EventHandler(this.cbLoginUsername_DropDown);
            this.cbLoginUsername.SelectionChangeCommitted += new System.EventHandler(this.cbLoginUsername_SelectionChangeCommitted);
            this.cbLoginUsername.Click += new System.EventHandler(this.cbLoginUsername_Click);
            // 
            // contextMenuCipherList
            // 
            this.contextMenuCipherList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.sendToolStripMenuItem});
            this.contextMenuCipherList.Name = "contextMenuCipherList";
            this.contextMenuCipherList.Size = new System.Drawing.Size(101, 48);
            this.contextMenuCipherList.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuCipherList_ItemClicked);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // sendToolStripMenuItem
            // 
            this.sendToolStripMenuItem.Name = "sendToolStripMenuItem";
            this.sendToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.sendToolStripMenuItem.Text = "Send";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 361);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 15);
            this.label9.TabIndex = 49;
            this.label9.Text = "Cipher Set Point";
            // 
            // txtSetPoint
            // 
            this.txtSetPoint.Location = new System.Drawing.Point(67, 379);
            this.txtSetPoint.Name = "txtSetPoint";
            this.txtSetPoint.ReadOnly = true;
            this.txtSetPoint.Size = new System.Drawing.Size(115, 23);
            this.txtSetPoint.TabIndex = 50;
            this.txtSetPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // QuantumConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 594);
            this.Controls.Add(this.txtSetPoint);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbLoginUsername);
            this.Controls.Add(this.btnSendCipher);
            this.Controls.Add(this.btnRefreshCipherRequests);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lvCipherRequestList);
            this.Controls.Add(this.lvCipherList);
            this.Controls.Add(this.btnRefreshCipherList);
            this.Controls.Add(this.btnUploadCipher);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnLoadSelectedCipher);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCipherEncryptStartLocation);
            this.Controls.Add(this.btnOpenCipherFile);
            this.Controls.Add(this.btnOpenFileToEncrypt);
            this.Controls.Add(this.progressBarECDC);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.labelApplicationTitle);
            this.Controls.Add(this.btnSaveCipher);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCipherFileSize);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInputFileSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEncryptionTimeTicks);
            this.Controls.Add(this.txtEncryptedFileSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEncryptedFilename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCipherFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxEncryptFileSize);
            this.Controls.Add(this.btnGetNewCipher);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOutputWindow);
            this.Controls.Add(this.txtCipherSerialNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuantumConsoleForm";
            this.Text = "QuantumLock Encrypt";
            this.contextMenuStripAcceptDeny.ResumeLayout(false);
            this.contextMenuCipherList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCipherSerialNo;
        private System.Windows.Forms.TextBox txtOutputWindow;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetNewCipher;
        private System.Windows.Forms.TextBox maxEncryptFileSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCipherFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEncryptedFilename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEncryptedFileSize;
        private System.Windows.Forms.TextBox txtEncryptionTimeTicks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInputFileSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCipherFileSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.SaveFileDialog saveCipherDialog;
        private System.Windows.Forms.Button btnSaveCipher;
        private System.Windows.Forms.Label labelApplicationTitle;
        private System.Windows.Forms.OpenFileDialog openCipherDialog;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.ProgressBar progressBarECDC;
        private System.Windows.Forms.Button btnOpenFileToEncrypt;
        private System.Windows.Forms.Button btnOpenCipherFile;
        private System.Windows.Forms.TextBox txtCipherEncryptStartLocation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLoadSelectedCipher;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnUploadCipher;
        private System.Windows.Forms.Button btnRefreshCipherList;
        private System.Windows.Forms.ListView lvCipherList;
        private System.Windows.Forms.ColumnHeader colCreated;
        private System.Windows.Forms.ListView lvCipherRequestList;
        private System.Windows.Forms.ColumnHeader colRequestFrom;
        private System.Windows.Forms.ColumnHeader colRequestDateTIme;
        private System.Windows.Forms.ColumnHeader colRequestCipherLen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnRefreshCipherRequests;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAcceptDeny;
        private System.Windows.Forms.ToolStripMenuItem acceptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem denyToolStripMenuItem;
        private System.Windows.Forms.Button btnSendCipher;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbLoginUsername;
        private System.Windows.Forms.ColumnHeader colMaxEncrypt;
        private System.Windows.Forms.ColumnHeader colSerialNumber;
        private System.Windows.Forms.ColumnHeader colSendId;
        private System.Windows.Forms.ContextMenuStrip contextMenuCipherList;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSetPoint;
    }
}


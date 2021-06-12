
namespace DesktopProto2
{
    partial class QuantumEncryptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuantumEncryptForm));
            this.txtCipherSerialNo = new System.Windows.Forms.TextBox();
            this.txtOutputWindow = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.rbUseExistingCipher = new System.Windows.Forms.RadioButton();
            this.rbGenerateNewCipher = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateCipher = new System.Windows.Forms.Button();
            this.maxEncryptFileSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCipherFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEncryptedFilename = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbAutoGenerateCipher = new System.Windows.Forms.RadioButton();
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
            this.label9 = new System.Windows.Forms.Label();
            this.openCipherDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.progressBarECDC = new System.Windows.Forms.ProgressBar();
            this.btnOpenFileToEncrypt = new System.Windows.Forms.Button();
            this.btnOpenCipherFile = new System.Windows.Forms.Button();
            this.txtCipherEncryptStartLocation = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCipherSerialNo
            // 
            this.txtCipherSerialNo.Location = new System.Drawing.Point(63, 341);
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
            this.txtOutputWindow.Size = new System.Drawing.Size(667, 466);
            this.txtOutputWindow.TabIndex = 2;
            this.txtOutputWindow.Enter += new System.EventHandler(this.txtCipherEncryptStartLocation_Enter);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // rbUseExistingCipher
            // 
            this.rbUseExistingCipher.AutoSize = true;
            this.rbUseExistingCipher.Location = new System.Drawing.Point(63, 96);
            this.rbUseExistingCipher.Name = "rbUseExistingCipher";
            this.rbUseExistingCipher.Size = new System.Drawing.Size(126, 19);
            this.rbUseExistingCipher.TabIndex = 4;
            this.rbUseExistingCipher.TabStop = true;
            this.rbUseExistingCipher.Text = "Use Existing Cipher";
            this.rbUseExistingCipher.UseVisualStyleBackColor = true;
            this.rbUseExistingCipher.CheckedChanged += new System.EventHandler(this.rbUseExistingCipher_CheckedChanged);
            // 
            // rbGenerateNewCipher
            // 
            this.rbGenerateNewCipher.AutoSize = true;
            this.rbGenerateNewCipher.Location = new System.Drawing.Point(63, 121);
            this.rbGenerateNewCipher.Name = "rbGenerateNewCipher";
            this.rbGenerateNewCipher.Size = new System.Drawing.Size(124, 19);
            this.rbGenerateNewCipher.TabIndex = 5;
            this.rbGenerateNewCipher.TabStop = true;
            this.rbGenerateNewCipher.Text = "Create New Cipher";
            this.rbGenerateNewCipher.UseVisualStyleBackColor = true;
            this.rbGenerateNewCipher.CheckedChanged += new System.EventHandler(this.rbGenerateNewCipher_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cipher Serial Number";
            // 
            // btnGenerateCipher
            // 
            this.btnGenerateCipher.Location = new System.Drawing.Point(63, 146);
            this.btnGenerateCipher.Name = "btnGenerateCipher";
            this.btnGenerateCipher.Size = new System.Drawing.Size(158, 23);
            this.btnGenerateCipher.TabIndex = 7;
            this.btnGenerateCipher.Text = "Generate Cipher";
            this.btnGenerateCipher.UseVisualStyleBackColor = true;
            this.btnGenerateCipher.Visible = false;
            this.btnGenerateCipher.Click += new System.EventHandler(this.generateCipher_Click);
            // 
            // maxEncryptFileSize
            // 
            this.maxEncryptFileSize.Enabled = false;
            this.maxEncryptFileSize.Location = new System.Drawing.Point(63, 388);
            this.maxEncryptFileSize.Name = "maxEncryptFileSize";
            this.maxEncryptFileSize.Size = new System.Drawing.Size(230, 23);
            this.maxEncryptFileSize.TabIndex = 8;
            this.maxEncryptFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maxEncryptFileSize.Click += new System.EventHandler(this.maxEncryptedFileSize_Enter);
            this.maxEncryptFileSize.Enter += new System.EventHandler(this.maxEncryptedFileSize_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Max File Size Cipher can Encrypt";
            // 
            // txtCipherFileName
            // 
            this.txtCipherFileName.Location = new System.Drawing.Point(63, 247);
            this.txtCipherFileName.Name = "txtCipherFileName";
            this.txtCipherFileName.Size = new System.Drawing.Size(199, 23);
            this.txtCipherFileName.TabIndex = 10;
            this.txtCipherFileName.Enter += new System.EventHandler(this.cipherFileName_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cipher Filename";
            // 
            // txtEncryptedFilename
            // 
            this.txtEncryptedFilename.Location = new System.Drawing.Point(63, 200);
            this.txtEncryptedFilename.Name = "txtEncryptedFilename";
            this.txtEncryptedFilename.Size = new System.Drawing.Size(199, 23);
            this.txtEncryptedFilename.TabIndex = 12;
            this.txtEncryptedFilename.Enter += new System.EventHandler(this.txtEncryptedFilename_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "File to Encrypt";
            // 
            // rbAutoGenerateCipher
            // 
            this.rbAutoGenerateCipher.AutoSize = true;
            this.rbAutoGenerateCipher.Location = new System.Drawing.Point(63, 71);
            this.rbAutoGenerateCipher.Name = "rbAutoGenerateCipher";
            this.rbAutoGenerateCipher.Size = new System.Drawing.Size(139, 19);
            this.rbAutoGenerateCipher.TabIndex = 14;
            this.rbAutoGenerateCipher.TabStop = true;
            this.rbAutoGenerateCipher.Text = "Auto Generate Cipher";
            this.rbAutoGenerateCipher.UseVisualStyleBackColor = true;
            this.rbAutoGenerateCipher.CheckedChanged += new System.EventHandler(this.rbAutoGenerateCipher_CheckedChanged);
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
            this.btnSave.Location = new System.Drawing.Point(63, 464);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(230, 42);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save Encrypted File";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDecrypt.Location = new System.Drawing.Point(184, 417);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(109, 41);
            this.btnDecrypt.TabIndex = 25;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnSaveCipher
            // 
            this.btnSaveCipher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveCipher.Location = new System.Drawing.Point(63, 512);
            this.btnSaveCipher.Name = "btnSaveCipher";
            this.btnSaveCipher.Size = new System.Drawing.Size(230, 46);
            this.btnSaveCipher.TabIndex = 26;
            this.btnSaveCipher.Text = "Save Cipher";
            this.btnSaveCipher.UseVisualStyleBackColor = true;
            this.btnSaveCipher.Click += new System.EventHandler(this.btnSaveCipher_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(309, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(255, 30);
            this.label9.TabIndex = 27;
            this.label9.Text = "QuantumLock Encryption";
            // 
            // openCipherDialog
            // 
            this.openCipherDialog.FileName = "openFileDialog2";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEncrypt.Location = new System.Drawing.Point(63, 417);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(115, 41);
            this.btnEncrypt.TabIndex = 28;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // progressBarECDC
            // 
            this.progressBarECDC.Location = new System.Drawing.Point(309, 559);
            this.progressBarECDC.Name = "progressBarECDC";
            this.progressBarECDC.Size = new System.Drawing.Size(667, 10);
            this.progressBarECDC.TabIndex = 29;
            // 
            // btnOpenFileToEncrypt
            // 
            this.btnOpenFileToEncrypt.Image = global::QuantumEncryptDesktop.Properties.Resources.icons8_folder_16;
            this.btnOpenFileToEncrypt.Location = new System.Drawing.Point(268, 200);
            this.btnOpenFileToEncrypt.Name = "btnOpenFileToEncrypt";
            this.btnOpenFileToEncrypt.Size = new System.Drawing.Size(25, 23);
            this.btnOpenFileToEncrypt.TabIndex = 30;
            this.btnOpenFileToEncrypt.UseVisualStyleBackColor = true;
            this.btnOpenFileToEncrypt.Click += new System.EventHandler(this.btnOpenFileToEncrypt_Click);
            // 
            // btnOpenCipherFile
            // 
            this.btnOpenCipherFile.Image = global::QuantumEncryptDesktop.Properties.Resources.icons8_folder_16;
            this.btnOpenCipherFile.Location = new System.Drawing.Point(268, 246);
            this.btnOpenCipherFile.Name = "btnOpenCipherFile";
            this.btnOpenCipherFile.Size = new System.Drawing.Size(25, 23);
            this.btnOpenCipherFile.TabIndex = 31;
            this.btnOpenCipherFile.UseVisualStyleBackColor = true;
            this.btnOpenCipherFile.Click += new System.EventHandler(this.btnOpenCipherFile_Click);
            // 
            // txtCipherEncryptStartLocation
            // 
            this.txtCipherEncryptStartLocation.Location = new System.Drawing.Point(63, 294);
            this.txtCipherEncryptStartLocation.Name = "txtCipherEncryptStartLocation";
            this.txtCipherEncryptStartLocation.Size = new System.Drawing.Size(230, 23);
            this.txtCipherEncryptStartLocation.TabIndex = 32;
            this.txtCipherEncryptStartLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCipherEncryptStartLocation.Enter += new System.EventHandler(this.txtCipherEncryptStartLocation_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(63, 276);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(228, 15);
            this.label10.TabIndex = 33;
            this.label10.Text = "Cipher Start Location After Reserved Bytes";
            // 
            // QuantumEncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 594);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCipherEncryptStartLocation);
            this.Controls.Add(this.btnOpenCipherFile);
            this.Controls.Add(this.btnOpenFileToEncrypt);
            this.Controls.Add(this.progressBarECDC);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.label9);
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
            this.Controls.Add(this.rbAutoGenerateCipher);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEncryptedFilename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCipherFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxEncryptFileSize);
            this.Controls.Add(this.btnGenerateCipher);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbGenerateNewCipher);
            this.Controls.Add(this.rbUseExistingCipher);
            this.Controls.Add(this.txtOutputWindow);
            this.Controls.Add(this.txtCipherSerialNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuantumEncryptForm";
            this.Text = "QuantumLock Encrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCipherSerialNo;
        private System.Windows.Forms.TextBox txtOutputWindow;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton rbUseExistingCipher;
        private System.Windows.Forms.RadioButton rbGenerateNewCipher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateCipher;
        private System.Windows.Forms.TextBox maxEncryptFileSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCipherFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEncryptedFilename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbAutoGenerateCipher;
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog openCipherDialog;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.ProgressBar progressBarECDC;
        private System.Windows.Forms.Button btnOpenFileToEncrypt;
        private System.Windows.Forms.Button btnOpenCipherFile;
        private System.Windows.Forms.TextBox txtCipherEncryptStartLocation;
        private System.Windows.Forms.Label label10;
    }
}


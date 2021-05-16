﻿
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
            this.btnLoadandEncrypt = new System.Windows.Forms.Button();
            this.txtCipherSerialNo = new System.Windows.Forms.TextBox();
            this.txtOutputWindow = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadCipher = new System.Windows.Forms.Button();
            this.rbUseExistingCipher = new System.Windows.Forms.RadioButton();
            this.rbGenerateNewCipher = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateCipher = new System.Windows.Forms.Button();
            this.maxEncryptFileSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cipherFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEncryptedFilename = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbAutoGenerateCipher = new System.Windows.Forms.RadioButton();
            this.btnRandomizeSerialNo = new System.Windows.Forms.Button();
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
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.openCipherDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnLoadandEncrypt
            // 
            this.btnLoadandEncrypt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLoadandEncrypt.Location = new System.Drawing.Point(63, 370);
            this.btnLoadandEncrypt.Name = "btnLoadandEncrypt";
            this.btnLoadandEncrypt.Size = new System.Drawing.Size(116, 41);
            this.btnLoadandEncrypt.TabIndex = 0;
            this.btnLoadandEncrypt.Text = "Load and Encrypt";
            this.btnLoadandEncrypt.UseVisualStyleBackColor = true;
            this.btnLoadandEncrypt.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // txtCipherSerialNo
            // 
            this.txtCipherSerialNo.Location = new System.Drawing.Point(63, 255);
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
            this.txtOutputWindow.Size = new System.Drawing.Size(667, 420);
            this.txtOutputWindow.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLoadCipher
            // 
            this.btnLoadCipher.Location = new System.Drawing.Point(63, 117);
            this.btnLoadCipher.Name = "btnLoadCipher";
            this.btnLoadCipher.Size = new System.Drawing.Size(158, 23);
            this.btnLoadCipher.TabIndex = 3;
            this.btnLoadCipher.Text = "Load Cipher";
            this.btnLoadCipher.UseVisualStyleBackColor = true;
            this.btnLoadCipher.Click += new System.EventHandler(this.loadCipher_Click);
            // 
            // rbUseExistingCipher
            // 
            this.rbUseExistingCipher.AutoSize = true;
            this.rbUseExistingCipher.Location = new System.Drawing.Point(63, 67);
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
            this.rbGenerateNewCipher.Location = new System.Drawing.Point(63, 92);
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
            this.label1.Location = new System.Drawing.Point(63, 237);
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
            this.btnGenerateCipher.Click += new System.EventHandler(this.generateCipher_Click);
            // 
            // maxEncryptFileSize
            // 
            this.maxEncryptFileSize.Enabled = false;
            this.maxEncryptFileSize.Location = new System.Drawing.Point(63, 298);
            this.maxEncryptFileSize.Name = "maxEncryptFileSize";
            this.maxEncryptFileSize.Size = new System.Drawing.Size(230, 23);
            this.maxEncryptFileSize.TabIndex = 8;
            this.maxEncryptFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Max File Size";
            // 
            // cipherFileName
            // 
            this.cipherFileName.Location = new System.Drawing.Point(63, 200);
            this.cipherFileName.Name = "cipherFileName";
            this.cipherFileName.Size = new System.Drawing.Size(230, 23);
            this.cipherFileName.TabIndex = 10;
            this.cipherFileName.Enter += new System.EventHandler(this.cipherFileName_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cipher Filename";
            // 
            // txtEncryptedFilename
            // 
            this.txtEncryptedFilename.Enabled = false;
            this.txtEncryptedFilename.Location = new System.Drawing.Point(63, 341);
            this.txtEncryptedFilename.Name = "txtEncryptedFilename";
            this.txtEncryptedFilename.Size = new System.Drawing.Size(230, 23);
            this.txtEncryptedFilename.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "File to Encrypt";
            // 
            // rbAutoGenerateCipher
            // 
            this.rbAutoGenerateCipher.AutoSize = true;
            this.rbAutoGenerateCipher.Location = new System.Drawing.Point(63, 42);
            this.rbAutoGenerateCipher.Name = "rbAutoGenerateCipher";
            this.rbAutoGenerateCipher.Size = new System.Drawing.Size(139, 19);
            this.rbAutoGenerateCipher.TabIndex = 14;
            this.rbAutoGenerateCipher.TabStop = true;
            this.rbAutoGenerateCipher.Text = "Auto Generate Cipher";
            this.rbAutoGenerateCipher.UseVisualStyleBackColor = true;
            this.rbAutoGenerateCipher.CheckedChanged += new System.EventHandler(this.rbAutoGenerateCipher_CheckedChanged);
            // 
            // btnRandomizeSerialNo
            // 
            this.btnRandomizeSerialNo.Location = new System.Drawing.Point(218, 229);
            this.btnRandomizeSerialNo.Name = "btnRandomizeSerialNo";
            this.btnRandomizeSerialNo.Size = new System.Drawing.Size(75, 23);
            this.btnRandomizeSerialNo.TabIndex = 15;
            this.btnRandomizeSerialNo.Text = "Randomize";
            this.btnRandomizeSerialNo.UseVisualStyleBackColor = true;
            this.btnRandomizeSerialNo.Click += new System.EventHandler(this.btnRandomizeSerialNo_Click);
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
            this.btnSave.Location = new System.Drawing.Point(63, 417);
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
            this.btnDecrypt.Location = new System.Drawing.Point(190, 370);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(103, 41);
            this.btnDecrypt.TabIndex = 25;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(63, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 46);
            this.button1.TabIndex = 26;
            this.button1.Text = "Save Cipher";
            this.button1.UseVisualStyleBackColor = true;
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
            // QuantumEncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 594);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
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
            this.Controls.Add(this.btnRandomizeSerialNo);
            this.Controls.Add(this.rbAutoGenerateCipher);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEncryptedFilename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cipherFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxEncryptFileSize);
            this.Controls.Add(this.btnGenerateCipher);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbGenerateNewCipher);
            this.Controls.Add(this.rbUseExistingCipher);
            this.Controls.Add(this.btnLoadCipher);
            this.Controls.Add(this.txtOutputWindow);
            this.Controls.Add(this.txtCipherSerialNo);
            this.Controls.Add(this.btnLoadandEncrypt);
            this.Name = "QuantumEncryptForm";
            this.Text = "QuantumLock Encrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadandEncrypt;
        private System.Windows.Forms.TextBox txtCipherSerialNo;
        private System.Windows.Forms.TextBox txtOutputWindow;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLoadCipher;
        private System.Windows.Forms.RadioButton rbUseExistingCipher;
        private System.Windows.Forms.RadioButton rbGenerateNewCipher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateCipher;
        private System.Windows.Forms.TextBox maxEncryptFileSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cipherFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEncryptedFilename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbAutoGenerateCipher;
        private System.Windows.Forms.Button btnRandomizeSerialNo;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog openCipherDialog;
    }
}

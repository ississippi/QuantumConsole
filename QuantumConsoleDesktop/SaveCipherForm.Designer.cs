
namespace QuantumConsoleDesktop
{
    partial class SaveCipherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_ECDCComplete = new System.Windows.Forms.Label();
            this.saveCipherModal = new System.Windows.Forms.SaveFileDialog();
            this.btnModalSaveCipher = new System.Windows.Forms.Button();
            this.btnCancelSaveCipher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_ECDCComplete
            // 
            this.label_ECDCComplete.AutoSize = true;
            this.label_ECDCComplete.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_ECDCComplete.Location = new System.Drawing.Point(22, 47);
            this.label_ECDCComplete.Name = "label_ECDCComplete";
            this.label_ECDCComplete.Size = new System.Drawing.Size(322, 32);
            this.label_ECDCComplete.TabIndex = 6;
            this.label_ECDCComplete.Text = "Save New Cipher Segment?";
            // 
            // btnModalSaveCipher
            // 
            this.btnModalSaveCipher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModalSaveCipher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnModalSaveCipher.Location = new System.Drawing.Point(51, 124);
            this.btnModalSaveCipher.Name = "btnModalSaveCipher";
            this.btnModalSaveCipher.Size = new System.Drawing.Size(85, 35);
            this.btnModalSaveCipher.TabIndex = 4;
            this.btnModalSaveCipher.Text = "Save";
            this.btnModalSaveCipher.UseVisualStyleBackColor = true;
            this.btnModalSaveCipher.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancelSaveCipher
            // 
            this.btnCancelSaveCipher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelSaveCipher.Location = new System.Drawing.Point(231, 124);
            this.btnCancelSaveCipher.Name = "btnCancelSaveCipher";
            this.btnCancelSaveCipher.Size = new System.Drawing.Size(75, 35);
            this.btnCancelSaveCipher.TabIndex = 5;
            this.btnCancelSaveCipher.Text = "Cancel";
            this.btnCancelSaveCipher.UseVisualStyleBackColor = true;
            // 
            // SaveCipherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelSaveCipher;
            this.ClientSize = new System.Drawing.Size(356, 199);
            this.Controls.Add(this.label_ECDCComplete);
            this.Controls.Add(this.btnCancelSaveCipher);
            this.Controls.Add(this.btnModalSaveCipher);
            this.Name = "SaveCipherForm";
            this.Text = "SaveCipherForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ECDCComplete;
        private System.Windows.Forms.SaveFileDialog saveCipherModal;
        private System.Windows.Forms.Button btnModalSaveCipher;
        private System.Windows.Forms.Button btnCancelSaveCipher;
    }
}
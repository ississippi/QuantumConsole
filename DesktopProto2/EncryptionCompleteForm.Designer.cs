
namespace QuantumEncryptPoCDesktop
{
    partial class EncryptionCompleteDialog
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
            this.btnModalSaveEncrypted = new System.Windows.Forms.Button();
            this.btnCancelEncrypted = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveEncryptedModal = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnModalSaveEncrypted
            // 
            this.btnModalSaveEncrypted.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModalSaveEncrypted.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnModalSaveEncrypted.Location = new System.Drawing.Point(45, 121);
            this.btnModalSaveEncrypted.Name = "btnModalSaveEncrypted";
            this.btnModalSaveEncrypted.Size = new System.Drawing.Size(85, 35);
            this.btnModalSaveEncrypted.TabIndex = 0;
            this.btnModalSaveEncrypted.Text = "Save";
            this.btnModalSaveEncrypted.UseVisualStyleBackColor = true;
            // 
            // btnCancelEncrypted
            // 
            this.btnCancelEncrypted.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelEncrypted.Location = new System.Drawing.Point(225, 121);
            this.btnCancelEncrypted.Name = "btnCancelEncrypted";
            this.btnCancelEncrypted.Size = new System.Drawing.Size(75, 35);
            this.btnCancelEncrypted.TabIndex = 1;
            this.btnCancelEncrypted.Text = "Cancel";
            this.btnCancelEncrypted.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(45, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Encryption Complete";
            // 
            // EncryptionCompleteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelEncrypted;
            this.ClientSize = new System.Drawing.Size(356, 199);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelEncrypted);
            this.Controls.Add(this.btnModalSaveEncrypted);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EncryptionCompleteDialog";
            this.Text = "Encryption Complete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModalSaveEncrypted;
        private System.Windows.Forms.Button btnCancelEncrypted;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveEncryptedModal;
    }
}

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
            this.btnModalSaveEncrypted = new System.Windows.Forms.Button();
            this.btnCancelEncrypted = new System.Windows.Forms.Button();
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
            // btnModalSaveEncrypted
            // 
            this.btnModalSaveEncrypted.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModalSaveEncrypted.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnModalSaveEncrypted.Location = new System.Drawing.Point(51, 124);
            this.btnModalSaveEncrypted.Name = "btnModalSaveEncrypted";
            this.btnModalSaveEncrypted.Size = new System.Drawing.Size(85, 35);
            this.btnModalSaveEncrypted.TabIndex = 4;
            this.btnModalSaveEncrypted.Text = "Save";
            this.btnModalSaveEncrypted.UseVisualStyleBackColor = true;
            this.btnModalSaveEncrypted.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancelEncrypted
            // 
            this.btnCancelEncrypted.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelEncrypted.Location = new System.Drawing.Point(231, 124);
            this.btnCancelEncrypted.Name = "btnCancelEncrypted";
            this.btnCancelEncrypted.Size = new System.Drawing.Size(75, 35);
            this.btnCancelEncrypted.TabIndex = 5;
            this.btnCancelEncrypted.Text = "Cancel";
            this.btnCancelEncrypted.UseVisualStyleBackColor = true;
            // 
            // SaveCipherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 199);
            this.Controls.Add(this.label_ECDCComplete);
            this.Controls.Add(this.btnCancelEncrypted);
            this.Controls.Add(this.btnModalSaveEncrypted);
            this.Name = "SaveCipherForm";
            this.Text = "SaveCipherForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ECDCComplete;
        private System.Windows.Forms.SaveFileDialog saveCipherModal;
        private System.Windows.Forms.Button btnModalSaveEncrypted;
        private System.Windows.Forms.Button btnCancelEncrypted;
    }
}
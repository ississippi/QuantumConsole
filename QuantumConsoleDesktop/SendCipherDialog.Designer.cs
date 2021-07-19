
namespace QuantumConsoleDesktop
{
    partial class SendCipherDialog
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
            this.btnSendCipherDialogSend = new System.Windows.Forms.Button();
            this.btnSendCipherDialogCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSendCipherToUser = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSendCipherDialogSend
            // 
            this.btnSendCipherDialogSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSendCipherDialogSend.Location = new System.Drawing.Point(147, 87);
            this.btnSendCipherDialogSend.Name = "btnSendCipherDialogSend";
            this.btnSendCipherDialogSend.Size = new System.Drawing.Size(100, 23);
            this.btnSendCipherDialogSend.TabIndex = 0;
            this.btnSendCipherDialogSend.Text = "Send Cipher";
            this.btnSendCipherDialogSend.UseVisualStyleBackColor = true;
            this.btnSendCipherDialogSend.Click += new System.EventHandler(this.btnSendCipherDialogSend_Click);
            // 
            // btnSendCipherDialogCancel
            // 
            this.btnSendCipherDialogCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSendCipherDialogCancel.Location = new System.Drawing.Point(335, 87);
            this.btnSendCipherDialogCancel.Name = "btnSendCipherDialogCancel";
            this.btnSendCipherDialogCancel.Size = new System.Drawing.Size(100, 23);
            this.btnSendCipherDialogCancel.TabIndex = 1;
            this.btnSendCipherDialogCancel.Text = "Cancel";
            this.btnSendCipherDialogCancel.UseVisualStyleBackColor = true;
            this.btnSendCipherDialogCancel.Click += new System.EventHandler(this.btnSendCipherDialogCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(46, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Send To User";
            // 
            // cbSendCipherToUser
            // 
            this.cbSendCipherToUser.FormattingEnabled = true;
            this.cbSendCipherToUser.Location = new System.Drawing.Point(147, 37);
            this.cbSendCipherToUser.Name = "cbSendCipherToUser";
            this.cbSendCipherToUser.Size = new System.Drawing.Size(288, 23);
            this.cbSendCipherToUser.TabIndex = 4;
            // 
            // SendCipherDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 151);
            this.Controls.Add(this.cbSendCipherToUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendCipherDialogCancel);
            this.Controls.Add(this.btnSendCipherDialogSend);
            this.Name = "SendCipherDialog";
            this.Text = "SendCipherDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendCipherDialogSend;
        private System.Windows.Forms.Button btnSendCipherDialogCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSendCipherToUser;
    }
}
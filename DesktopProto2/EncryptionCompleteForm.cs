using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopProto2;

namespace QuantumEncryptPoCDesktop
{
    public partial class EncryptionCompleteDialog : Form
    {
        byte[] _fileBytes;
        public EncryptionCompleteDialog(bool isEncryption, byte[] fileBytes, string fileName)
        {
            InitializeComponent();
            label_ECDCComplete.Text = (isEncryption) ? "Encryption Complete" : "Decryption Complete";
            _fileBytes = new byte[fileBytes.Length];
            fileBytes.CopyTo(_fileBytes, 0);
            if (isEncryption)
            {
                saveEncryptedModal.FileName = fileName + ".qlock"; 
                saveEncryptedModal.Filter = "QuantumLock Files (*.qlock)|*.qlock";
            }
            else
            {
                saveEncryptedModal.FileName = fileName;
                saveEncryptedModal.Filter = "All files (*.*)|*.*";
            }
        }

        private void EncryptionCompleteDialog_Load(object sender, System.EventArgs e)
        {
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveEncryptedModal.ShowDialog() == DialogResult.OK)
            {
                if (saveEncryptedModal.FileName != "")
                {
                    // default extension for saved encrypted files to be .qlock
                    FileStream fs = (System.IO.FileStream)saveEncryptedModal.OpenFile();
                    fs.Write(_fileBytes, 0, _fileBytes.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
            this.Close();
        }
    }
}

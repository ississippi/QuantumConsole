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

using QuantumEncryptLib;
using QuantumEncryptModels;

namespace QuantumConsoleDesktop
{
    public partial class SaveCipherForm : Form
    {
        byte[] _fileBytes;
        public SaveCipherForm(Cipher cipherObj)
        {
            InitializeComponent();

            _fileBytes = new byte[cipherObj.cipherString.Length];
            var idx = 0;
            QuantumEncrypt.CopyStringToByteArray(cipherObj.cipherString, ref _fileBytes, ref idx);

            saveCipherModal.FileName = $"Cipher_{cipherObj.cipherString.Substring(0, 6)}" + ".cipher";
            saveCipherModal.Filter = "QuantumLock Cipher Files (*.cipher)|*.cipher";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveCipherModal.ShowDialog() == DialogResult.OK)
            {
                if (saveCipherModal.FileName != "")
                {
                    // default extension for saved encrypted files to be .qlock
                    FileStream fs = (System.IO.FileStream)saveCipherModal.OpenFile();
                    fs.Write(_fileBytes, 0, _fileBytes.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
            this.Close();
        }
    }
}

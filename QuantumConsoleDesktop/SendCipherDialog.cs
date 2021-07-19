using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuantumConsoleDesktop
{
    public partial class SendCipherDialog : Form
    {
        public SendCipherDialog()
        {
            InitializeComponent();
        }

        private void btnSendCipherDialogSend_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSendCipherDialogCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

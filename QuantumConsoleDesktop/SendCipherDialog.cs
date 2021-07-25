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
        Dictionary<string, int> _userList;
        public int RecipientUserId { get; set; }
        public SendCipherDialog(Dictionary<string,int> userList)
        {
            InitializeComponent();
            _userList = userList;
            foreach(string user in _userList.Keys)
            {
                cbSendCipherToUser.Items.Add(user);
            }
        }

        private void btnSendCipherDialogSend_Click(object sender, EventArgs e)
        {
            var recipientUserId = 0;
            _userList.TryGetValue(cbSendCipherToUser.SelectedItem.ToString(), out recipientUserId);
            RecipientUserId = recipientUserId;
            this.Close();
        }

        private void btnSendCipherDialogCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

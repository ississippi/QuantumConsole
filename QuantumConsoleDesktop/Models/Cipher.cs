using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumConsoleDesktop.Models
{
    public class NewCipherRequest
    {
        public int UserId { get; set; }
        public int Length { get; set; }
    }

    public class Cipher
    {
        public int cipherId { get; set; }
        public int userId { get; set; }
        public DateTime createdDateTime { get; set; }
        public string serialNumber { get; set; }
        public int startingPoint { get; set; }
        public string cipherString { get; set; }
    }

    public class CipherList
    {
        public CipherList()
        {
            Ciphers = new List<Cipher>();
        }
        public List<Cipher> Ciphers { get; set; }
    }

    public class CipherSend
    {
        public int CipherSendId { get; set; }
        public int SenderUserId { get; set; }
        public int RecipientUserId { get; set; }
        public int CipherId { get; set; }
        public int StartingPoint { get; set; }
        public string AcceptDenyStatus { get; set; }
        public DateTime AcceptDenyStatusDateTime { get; set; }
        public DateTime CreateDate { get; set; }

    }

    public class CipherSendList
    {
        public CipherSendList()
        {
            SendRequests = new List<CipherSend>();
        }
        public List<CipherSend> SendRequests { get; set; }
    }

    public class CipherAcceptDeny
    {
        public int UserId { get; set; }
        public int CipherSendRequestId { get; set; }
        public string AcceptDeny { get; set; }
    }

    public class CipherRequest
    {
        public int UserId { get; set; }
        public int CipherId { get; set; }
    }
}

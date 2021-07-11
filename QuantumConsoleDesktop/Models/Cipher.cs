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
        //public DateTime createdDateTime { get; set; }
        public string serialNumber { get; set; }
        public int startingPoint { get; set; }
        public string cipherString { get; set; }
    }
}

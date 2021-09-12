using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuantumConsoleDesktop.Models
{
    public class CipherSetPoint
    {
        public string serialNumber { get; set; }
        public int setPoint { get; set; }
    }

    public class CipherSetPointList
    {
        public CipherSetPointList()
        {
            CipherSetPoints = new Dictionary<string, string>();
        }
        // Dictionary Key: serialNumber, Value: setPoint
        public Dictionary<string, string>CipherSetPoints { get; set; }
    }

    public class UserCipherSetPointList
    {
        public UserCipherSetPointList()
        {
            UserSetPoints = new Dictionary<int, CipherSetPointList>();
        }
        public Dictionary<int, CipherSetPointList> UserSetPoints { get; set; }
    }

}

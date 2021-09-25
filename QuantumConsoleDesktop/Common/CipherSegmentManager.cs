using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuantumEncryptModels;
using QuantumConsoleDesktop.Providers;

namespace QuantumConsoleDesktop.Common
{
    public static class CipherSegmentManager
    {
        private static int _userId = -1;
        private static int _quantityToRequest = 50;
        private static CipherSerials _cipherSerialList = null;

        private static async Task Init(int userId)
        {
            if (userId != _userId || _cipherSerialList == null || _cipherSerialList.SerialNumbers == null || _cipherSerialList.SerialNumbers.Count == 0)
            {
                _userId = userId;
                _cipherSerialList = await QuantumHubProvider.GetCipherSerialNumberList(userId, _quantityToRequest);
            }
        }

        public static async Task<string> GetNewSegmentSerialNumber(int userId)
        {
            var serialNo = await GetNextSerialAndRemove(userId);

            return serialNo;
        }

        public static async Task<string> GetNextSerialAndRemove(int userId)
        {
            await Init(userId);

            var serialNumber = _cipherSerialList.SerialNumbers[0];
            _cipherSerialList.SerialNumbers.RemoveAt(0);

            return serialNumber;
        }
    }
}

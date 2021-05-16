using System;
using System.Security.Cryptography;
using System.Text;

namespace QuantumEncryptLib
{
    public static class QuantumEncrypt
    {
        const int CIPHER_VERSION_LEN = 2;
        const int CIPHER_SERIAL_NO_LEN = 75;
        const int CIPHER_START = CIPHER_VERSION_LEN + CIPHER_SERIAL_NO_LEN;
        const int ENCRYPTION_START_LOCATION_LEN = 25;
        const int _VERSION_LEN = 2;
        const int _SERIAL_LEN = 75;
        const int _HEADERLEN = _VERSION_LEN + _SERIAL_LEN;
        public static byte[] Encrypt(string fileName, byte[] arr, string cipher, string serialNo)
        {
            //var serialNo = QuantumEncrypt.GenerateRandomSerialNumber();
            var result = new byte[GetEncryptedFileLen(arr.Length, fileName.Length)];
            var idxResult = 0;
            var encryptedBytes = ECDC(arr, 0, cipher, arr.Length);
            var encryptionBegin = 100 + fileName.Length;
            var startLocation = encryptionBegin.ToString("D25");

            CopyStringToByteArray(serialNo, ref result, ref idxResult);
            CopyStringToByteArray(startLocation, ref result, ref idxResult);
            CopyStringToByteArray(fileName, ref result, ref idxResult);
            encryptedBytes.CopyTo(result, idxResult);

            //var newResult = new byte[GetEncryptedFileLen(arr.Length, fileName.Length)];
            //var idxNew = 0;
            //foreach (char c in serialNo.ToCharArray())
            //{
            //    newResult[idxNew++] = (byte)c;
            //}
            //foreach (char c in startLocation.ToCharArray())
            //{
            //    newResult[idxNew++] = (byte)c;
            //}
            //foreach (char c in fileName.ToCharArray())
            //{
            //    newResult[idxNew++] = (byte)c;
            //}
            //foreach (byte x in encryptedBytes)
            //{
            //    newResult[idxNew++] += ((byte)x);
            //}

            return result;
        }
        
        public static void CopyStringToByteArray(string str, ref byte[] arrDestination, ref int idxDestination)
        {
            foreach (char c in str.ToCharArray())
            {
                arrDestination[idxDestination++] = (byte)c;
            }
        }
        public static string CopyBytesToString(byte[] arr, int idx, int len)
        {
            var newArr = new byte[len];
            var endLoc = idx + len;
            var j = 0;
            for(int i = idx; i < endLoc; i++)
            {
                newArr[j++] = arr[i];
            }
            var str = Encoding.Default.GetString(newArr);

            return str;
        }
        public static byte[] Decrypt(byte[] arr, string cipher)
        {
            var startLocStr = CopyBytesToString(arr, CIPHER_SERIAL_NO_LEN, ENCRYPTION_START_LOCATION_LEN);
            double startLoc = 0;
            Double.TryParse(startLocStr, out startLoc);
            var newArrayLen = arr.Length - (int)startLoc;

            return ECDC(arr, (int)startLoc, cipher, newArrayLen);
        }

        private static byte[] ECDC(byte[] arr, int idxArr, string cipher, int newArrayLen)
        {
            int idxCipher = CIPHER_START - 1;
            var result = new byte[newArrayLen];
            var idxResult = 0;
            for (int idx = idxArr; idx < arr.Length; idx++)
            {
                int y = ((int)cipher[idxCipher] ^ (int)arr[idx]);
                result[idxResult] += ((byte)y);
                idxCipher++;
                idxResult++;
            }
            return result;
        }

        //public static double GetEncryptionStartLocation()
        //{
        //    Double.TryParse(startLocation, out dblVal);
        //}
        public static int GetEncryptedFileLen(int fileToEncryptLen, int fileNameLen)
        {
            return fileToEncryptLen + 100 + fileNameLen;
        }

        public static int GetCipherLen(int fileToEncryptLen)
        {

            return _HEADERLEN + fileToEncryptLen;
        }
        public static int GetMaxFileSizeForEncryption(string cipherString)
        {
            return cipherString.Length - _HEADERLEN;
        }

        public static string GetSerialNumberFromCipher(string cipherString)
        {
            return cipherString.Substring(2, _SERIAL_LEN);
        }
        public static string GetVersionNumberFromCipher(string cipherString)
        {
            return cipherString.Substring(0, _VERSION_LEN);
        }

        public static string GenerateRandomCryptographicKey(int keyLength)
        {
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[keyLength];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
        public static string GenerateRandomSerialNumber()
        {
            var serial = "111111111122222222223333333333444444444455555555556666666666777777777788888";

            var randomBytes = GenerateRandomCryptographicKey(75);
            var serialNumberString = "";
            foreach (byte x in randomBytes)
            {
                //serialNumberString += (x % 10)
            }

            return serial;
        }

        /// <summary>
        /// Create a Formatted Display of the input byte array returning as a string.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="bytesPerLine"></param>
        /// <returns></returns>
        public static string HexDump(byte[] bytes, int bytesPerLine = 16)
        {
            if (bytes == null) return "<null>";
            int bytesLength = bytes.Length;

            char[] HexChars = "0123456789ABCDEF".ToCharArray();

            int firstHexColumn =
                  8                   // 8 characters for the address
                + 3;                  // 3 spaces

            int firstCharColumn = firstHexColumn
                + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                + 2;                  // 2 spaces 

            int lineLength = firstCharColumn
                + bytesPerLine           // - characters to show the ascii value
                + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new String(' ', lineLength - Environment.NewLine.Length) + Environment.NewLine).ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            StringBuilder result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = HexChars[(i >> 28) & 0xF];
                line[1] = HexChars[(i >> 24) & 0xF];
                line[2] = HexChars[(i >> 20) & 0xF];
                line[3] = HexChars[(i >> 16) & 0xF];
                line[4] = HexChars[(i >> 12) & 0xF];
                line[5] = HexChars[(i >> 8) & 0xF];
                line[6] = HexChars[(i >> 4) & 0xF];
                line[7] = HexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char)b);
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }
            return result.ToString();
        }
    }
}

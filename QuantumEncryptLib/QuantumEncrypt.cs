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
        public static byte[] Encrypt(string fileName, byte[] arr, string cipher, string serialNo)
        {
            //var serialNo = QuantumEncrypt.GenerateRandomSerialNumber();
            var result = new byte[GetEncryptedFileLen(arr.Length, fileName.Length)];
            var i = 0;
            var encryptedBytes = ECDC(arr, cipher);
            foreach(char c in serialNo.ToCharArray())
            {
                result[i] = (byte)c;
                i++;
            }
            var encryptionBegin = 100 + fileName.Length;
            var startLocation = string.Format("{0, 25}", encryptionBegin);
            foreach (char c in startLocation.ToCharArray())
            {
                result[i] = (byte)c;
                i++;
            }
            foreach (char c in fileName.ToCharArray())
            {
                result[i] = (byte)c;
                i++;
            }
            foreach (byte x in encryptedBytes)
            {
                result[i++] += ((byte)x);
            }

            return result;
            //return ECDC(arr, result, fileName.Length, cipher, i);
        }
        
        public static byte[] Decrypt(byte[] arr, string cipher)
        {
            var newArr = new byte[25];
            int x = CIPHER_SERIAL_NO_LEN;
            // 1. Get the starting location of the encrypted bytes.
            for (int i = 0; i < 25; i++)
            {
                int cByte = (int)arr[x++];
                newArr[i] = ((byte)x);
            }
            var isstring = Encoding.Default.GetString(newArr);
            var isDouble = BitConverter.ToDouble(newArr, 16);
            var startOfEncrypt = Convert.ToDouble(newArr.ToString());

            return ECDC(newArr, cipher);
        }

        private static byte[] ECDC(byte[] arr, string cipher)
        {
            int idxCipher = CIPHER_START - 1;
            var result = new byte[arr.Length];
            var idxResult = 0;
            foreach (byte x in arr)
            {
                int y = ((int)cipher[idxCipher] ^ (int)x);
                result[idxResult] += ((byte)y);
                idxCipher++;
                idxResult++;
            }
            return result;
        }

        public static int GetEncryptedFileLen(int fileToEncryptLen, int fileNameLen)
        {
            return fileToEncryptLen + 100 + fileNameLen + 16;
        }

        public static int GetCipherLen(int fileToEncryptLen)
        {
            var _VERSION_LEN = 2;
            var _SERIAL_LEN = 75;
            var _HEADERLEN = _VERSION_LEN + _SERIAL_LEN;
            return _HEADERLEN + fileToEncryptLen + 8;
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

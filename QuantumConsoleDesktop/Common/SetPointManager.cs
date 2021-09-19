using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using QuantumConsoleDesktop.Models;
using QuantumEncryptModels;

namespace QuantumConsoleDesktop.Common
{
    public class SetPointManager
    {
        private static SetPointManager _instance = null;
        private string _setPointFlle = @"CipherSetPointList.json";
        private UserCipherSetPointList _userSetPointList = null;

        private SetPointManager() { }
        public static SetPointManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SetPointManager();
                }
                return _instance;
            }
        }

        public async Task Init()
        {
            if (_userSetPointList == null)
            {
                await LoadPersistedCipherSetPointList();
            }
        }

        public async Task AddNewCipher(int userId, string serialNumber)
        {
            await Init();
            CipherSetPointList cipherSetPointList = null;
            _userSetPointList.UserSetPoints.TryGetValue(userId, out cipherSetPointList);
            // Add new entry for user with existing entries
            if (cipherSetPointList != null && cipherSetPointList.CipherSetPoints != null)
            {
                var setPoint = string.Empty;
                if (_userSetPointList.UserSetPoints[userId].CipherSetPoints.TryGetValue(serialNumber, out setPoint))
                {
                    return;
                }
                _userSetPointList.UserSetPoints[userId].CipherSetPoints.Add(serialNumber, "0");
            }
            // No entries for current user.
            else
            {
                var cspl = new CipherSetPointList();
                cspl.CipherSetPoints.Add(serialNumber, "0");
                _userSetPointList.UserSetPoints.Add(userId, cspl);
            }
            await SaveCipherSetPointList(_userSetPointList);

        }
        /// <summary>
        /// Check for an existing persisted CipherSetPointList
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsCipherSetPointListNull(int userId)
        {
            await Init();
            if (!File.Exists(_setPointFlle))
                return true;
            if (_userSetPointList == null || _userSetPointList.UserSetPoints == null)
                return true;
            CipherSetPointList cipherSetPointList = null;
            _userSetPointList.UserSetPoints.TryGetValue(userId, out cipherSetPointList);
            return (cipherSetPointList == null);
        }

        public async Task<bool> IsSetPointListInSync(int userId, CipherList cipherList)
        {
            var isNull = await IsCipherSetPointListNull(userId);
            if (isNull)
                return false;
            if (_userSetPointList == null || _userSetPointList.UserSetPoints == null)
                return false;
            CipherSetPointList cipherSetPointList = null;
            _userSetPointList.UserSetPoints.TryGetValue(userId, out cipherSetPointList);
            if (cipherSetPointList == null)
                return false;
            if (cipherSetPointList.CipherSetPoints.Count != cipherList.Ciphers.Count)
                return false;
            return true;
        }

        public async Task BuildNewSetPointList(int userId, CipherList cipherList)
        {
            try
            {
                if (cipherList == null || cipherList.Ciphers == null || cipherList.Ciphers.Count == 0)
                    return;
                await Init();
                if (_userSetPointList != null)
                {
                    // Clear only the current user's setPointList.
                    if (_userSetPointList.UserSetPoints != null && _userSetPointList.UserSetPoints.Count > 0)
                    {
                        foreach (var splUserId in _userSetPointList.UserSetPoints.Keys)
                        {
                            if (userId == splUserId)
                            {
                                _userSetPointList.UserSetPoints[userId].CipherSetPoints.Clear();
                            }
                        }
                    }
                }
                else _userSetPointList = new UserCipherSetPointList();
                var l = new CipherSetPointList();
                foreach (var c in cipherList.Ciphers)
                {
                    var setPoint = string.Empty;
                    l.CipherSetPoints.TryGetValue(c.serialNumber, out setPoint);
                    if (!string.IsNullOrEmpty(setPoint))
                        continue;
                    l.CipherSetPoints.Add(c.serialNumber, "0");
                }
                CipherSetPointList cipherSetPointList = null;
                _userSetPointList.UserSetPoints.TryGetValue(userId, out cipherSetPointList);
                if (cipherSetPointList == null)
                    _userSetPointList.UserSetPoints.Add(userId, l);
                else
                    _userSetPointList.UserSetPoints[userId] = l;
                await SaveCipherSetPointList(_userSetPointList);
            }
            catch (Exception ex)
            {
                throw new Exception($"BuildNewSetPointList() Exception.\n\nError message: {ex.Message}\n\nDetails:\n\n{ex.StackTrace}");
            }
        }

        /// <summary>
        /// Synchronize the input list with the persisted SetPointList
        /// If input serialNumber not found in persisted SetPointList, add it with a SetPoint of 0.
        /// TODO: When serialNo in persisted SetPointList but not in input list, remove???
        /// </summary>
        public async Task SyncSetPointList(int userId, CipherList cipherList)
        {
            if (cipherList == null || cipherList.Ciphers == null || cipherList.Ciphers.Count == 0)
                return;
            await Init();
            CipherSetPointList cipherSetPointList = null;
            _userSetPointList.UserSetPoints.TryGetValue(userId, out cipherSetPointList);
            if(cipherSetPointList == null)
            {
                cipherSetPointList = new CipherSetPointList();
                _userSetPointList.UserSetPoints.Add(userId, cipherSetPointList);
            }

            var cspList = new CipherSetPointList();
            foreach (var c in cipherList.Ciphers)
            {
                var setPoint = string.Empty;
                var setPointValue = _userSetPointList.UserSetPoints[userId].CipherSetPoints.TryGetValue(c.serialNumber, out setPoint);

                if (string.IsNullOrEmpty(setPoint))
                {
                    _userSetPointList.UserSetPoints[userId].CipherSetPoints.Add(c.serialNumber, "0");
                }
            }
            await SaveCipherSetPointList(_userSetPointList);
        }

        /// <summary>
        /// Return the entire UserCipherSetPointList from persisted storage.
        /// </summary>
        /// <returns></returns>
        public async Task<UserCipherSetPointList> GetUserSetPointList()
        {
            return _userSetPointList;
        }

        /// <summary>
        /// For the input serialNo, 
        /// 1) Retrieve the persisted setpoint
        /// 2) Increment the persisted setpoint
        /// 3) Persist the updated CipherSetPointList
        /// 4) return the new setpoint.
        /// Set Points are incremented by the length of the last encrypted file + the length of the filename + 1 byte for the colon delimiter.
        /// </summary>
        /// <param name="userId">Which user to increment set point for</param>
        /// <param name="serialNo">Which serial number for this user to increment set point for</param>
        /// <param name="incrementBy">How much to increment the set point</param>
        /// <returns></returns>
        public async Task<int> IncrementSetPoint(int userId, string serialNo, int incrementBy)
        {
            await Init();
            CipherSetPointList cipherSetPointList = null;
            if (_userSetPointList.UserSetPoints != null)
                _userSetPointList.UserSetPoints.TryGetValue(userId, out cipherSetPointList);
            var newSetPoint = 0;
            if (cipherSetPointList != null)
            {
                var setPoint = string.Empty;
                if (_userSetPointList.UserSetPoints != null)
                {
                    _userSetPointList.UserSetPoints[userId].CipherSetPoints.TryGetValue(serialNo, out setPoint);
                }
                if (!string.IsNullOrEmpty(setPoint))
                {
                    newSetPoint = Int32.Parse(setPoint);
                    newSetPoint += incrementBy;
                    _userSetPointList.UserSetPoints[userId].CipherSetPoints[serialNo] = newSetPoint.ToString();
                }
            }
            else
            {
                cipherSetPointList = new CipherSetPointList();
                cipherSetPointList.CipherSetPoints.Add(serialNo, newSetPoint.ToString());
                _userSetPointList.UserSetPoints.Add(userId, cipherSetPointList);
            }
            await SaveCipherSetPointList(_userSetPointList);

            return newSetPoint;
        }

        /// <summary>
        /// For the input serialNo, get the current setpoint.
        /// </summary>
        /// <param name="serialNo"></param>
        /// <returns></returns>
        public async Task<int> GetSetPoint(int userId, string serialNo)
        {
            await Init();
            CipherSetPointList cipherSetPointList = null;
            _userSetPointList.UserSetPoints.TryGetValue(userId, out cipherSetPointList);
            var setPoint = string.Empty;
            if (cipherSetPointList == null)
            {
                // there is no CipherSetPointList for the current user. Create one now.
                await AddNewCipher(userId, serialNo);
            }
            _userSetPointList.UserSetPoints[userId].CipherSetPoints.TryGetValue(serialNo, out setPoint);
            if (setPoint == null)
            {
                // this cipher is not in the user's sertPointList, add it now.
                await AddNewCipher(userId, serialNo);
                _userSetPointList.UserSetPoints[userId].CipherSetPoints.TryGetValue(serialNo, out setPoint);
            }
            return Int32.Parse(setPoint);
        }

        private async Task LoadPersistedCipherSetPointList()
        {
            if (_userSetPointList == null)
                _userSetPointList = await GetPersistedCipherSetPointList();
            if (_userSetPointList == null)
                _userSetPointList = new UserCipherSetPointList();
        }        

        /// <summary>
        /// Return the CipherSetPointList
        /// </summary>
        /// <returns></returns>
        private async Task<UserCipherSetPointList> GetPersistedCipherSetPointList()
        {
            if (!File.Exists(_setPointFlle))
                return null;
            using FileStream setPointStream = File.Open(_setPointFlle, FileMode.Open, FileAccess.Read);
            var userSetPointList = await JsonSerializer.DeserializeAsync<UserCipherSetPointList>(setPointStream);
            await setPointStream.DisposeAsync();
            return userSetPointList;
        }

        /// <summary>
        /// Save the CipherSetPointList to the resource file.
        /// </summary>
        private async Task SaveCipherSetPointList(UserCipherSetPointList setPointList)
        {
            using FileStream setPointStream = File.OpenWrite(_setPointFlle);

            var options = new JsonSerializerOptions { WriteIndented = true };
            await JsonSerializer.SerializeAsync<UserCipherSetPointList>(setPointStream, setPointList, options);
            await setPointStream.DisposeAsync();
        }
    }
}

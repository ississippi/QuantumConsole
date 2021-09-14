﻿using System;
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

        }
        /// <summary>
        /// Check for an existing persisted CipherSetPointList
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsCipherSetPointListNull()
        {
            return !File.Exists(_setPointFlle);
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

                if (!string.IsNullOrEmpty(setPoint))
                {
                    _userSetPointList.UserSetPoints[userId].CipherSetPoints.Add(c.serialNumber, "0");
                    await SaveCipherSetPointList(_userSetPointList);
                }
            }

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
        /// </summary>
        /// <param name="serialNo"></param>
        /// <returns></returns>
        public async Task<int> IncrementSetPoint(int userId, string serialNo)
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
                    newSetPoint++;
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
            _userSetPointList.UserSetPoints[userId].CipherSetPoints.TryGetValue(serialNo, out setPoint);

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
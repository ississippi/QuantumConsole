
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

using Newtonsoft.Json;
using QuantumConsoleDesktop.Common;
using QuantumConsoleDesktop.Models;

namespace QuantumConsoleDesktop.Providers
{
    public static class QuantumHubProvider
    {
        private static async Task<string> HealthCheck()
        {
            var healthString = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("plain/text"));
                    httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Quantum Console");

                    healthString = await httpClient.GetStringAsync(GetQuantumHubBaseAddress() + "/api/Cipher");
                }
            }
            catch (Exception e)
            {

            }
            return healthString;
        }

        public async static Task<Cipher> GetNewCipher(int userId, int encryptionLength)
        {
            Cipher cipher = null;
            try
            {
                var n = new NewCipherRequest
                {
                    UserId = userId,
                    Length = encryptionLength
                };
                var h = await HealthCheck();
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(GetQuantumHubBaseAddress());
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Quantum Console");
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(n));
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    string getNewCipherPath = "/api/Cipher/GetNewCipher";
                    var response = await httpClient.PostAsync(getNewCipherPath, httpContent);
                    var content = await response.Content.ReadAsStringAsync();
                    //var baseResponse = JsonSerializer.Deserialize<BaseResponse<Cipher>>(content);
                    var baseResponse = JsonConvert.DeserializeObject<BaseResponse<Cipher>>(content);
                    cipher = baseResponse.Data;
                }
            }
            catch (Exception e)
            {

            }

            return cipher;
        }

        public async static Task<CipherList> GetCipherList(int userId)
        {
            CipherList list = null;
            try
            {
                var h = await HealthCheck();
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(GetQuantumHubBaseAddress());
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Quantum Console");
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedAccessSignature", sBToken);
                    //HttpContent httpContent = new StringContent(JsonSerializer.Serialize<NewCipherRequest>(n));
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(userId));
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    string getCipherListPath = "/api/Cipher/GetCipherList";
                    var response = await httpClient.PostAsync(getCipherListPath, httpContent);
                    var content = await response.Content.ReadAsStringAsync();
                    //var baseResponse = JsonSerializer.Deserialize<BaseResponse<Cipher>>(content);
                    var baseResponse = JsonConvert.DeserializeObject<BaseResponse<CipherList>>(content);
                    list = baseResponse.Data;
                }
            }
            catch (Exception e)
            {

            }

            return list;
        }

        public async static Task<int> SendCipher(CipherSend cs)
        {
            var sendId = -1;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(GetQuantumHubBaseAddress());
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Quantum Console");
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedAccessSignature", sBToken);
                    //HttpContent httpContent = new StringContent(JsonSerializer.Serialize<NewCipherRequest>(n));
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(cs));
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    string sendCipherPath = "/api/Cipher/SendCipher";
                    var response = await httpClient.PostAsync(sendCipherPath, httpContent);
                    var content = await response.Content.ReadAsStringAsync();
                    var baseResponse = JsonConvert.DeserializeObject<BaseResponse<int>>(content);
                    sendId = baseResponse.Data;
                }
            }
            catch (Exception e)
            {

            }

            return sendId;
        }

        public async static Task<Cipher> AcceptDeny(CipherAcceptDeny ad)
        {
            Cipher cipher = null;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(GetQuantumHubBaseAddress());
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Quantum Console");
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedAccessSignature", sBToken);
                    //HttpContent httpContent = new StringContent(JsonSerializer.Serialize<NewCipherRequest>(n));
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(ad));
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    string acceptDenyPath = "/api/Cipher/AcceptDenyCipher";
                    var response = await httpClient.PostAsync(acceptDenyPath, httpContent);
                    var content = await response.Content.ReadAsStringAsync();
                    var baseResponse = JsonConvert.DeserializeObject<BaseResponse<Cipher>>(content);
                    cipher = baseResponse.Data;
                }
            }
            catch (Exception e)
            {

            }

            return cipher;
        }

        public async static Task<Cipher> GetCipher(CipherRequest cr)
        {
            Cipher cipher = null;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(GetQuantumHubBaseAddress());
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Quantum Console");
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(cr));
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    string getCipherPath = "/api/Cipher/GetCipher";
                    var response = await httpClient.PostAsync(getCipherPath, httpContent);
                    var content = await response.Content.ReadAsStringAsync();
                    var baseResponse = JsonConvert.DeserializeObject<BaseResponse<Cipher>>(content);
                    cipher = baseResponse.Data;
                }
            }
            catch (Exception e)
            {

            }

            return cipher;
        }

        public async static Task<CipherSendList> GetNotifications(int recipientId, string status)
        {
            CipherSendList list = null;
            try
            {
                var req = new NotificationRequest()
                {
                    RecipientId = recipientId,
                    Status = status
                };
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(GetQuantumHubBaseAddress());
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Quantum Console");
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(req));
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    string getNotificationsPath = "/api/Notifications/GetNotifications";
                    var response = await httpClient.PostAsync(getNotificationsPath, httpContent);
                    var content = await response.Content.ReadAsStringAsync();
                    var baseResponse = JsonConvert.DeserializeObject<BaseResponse<CipherSendList>>(content);
                    list = baseResponse.Data;
                }
            }
            catch (Exception e)
            {

            }

            return list;
        }

        public static string GetQuantumHubBaseAddress()
        {
//#if DEBUG
//            return "https://localhost:44342/";
//#else
            return "https://quantumhub.azurewebsites.net";
//#endif
        }
    }
}


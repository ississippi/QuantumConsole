
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

                    healthString = await httpClient.GetStringAsync("https://localhost:44342/api/Cipher");
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
                    httpClient.BaseAddress = new Uri("https://localhost:44342");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Quantum Console");
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedAccessSignature", sBToken);
                    //HttpContent httpContent = new StringContent(JsonSerializer.Serialize<NewCipherRequest>(n));
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
    }
}


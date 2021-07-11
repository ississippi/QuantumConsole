
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
        private static readonly HttpClient client = new HttpClient();
        public async static Task<Cipher> GetNewCipher(int userId, int encryptionLength)
        {
            var n = new NewCipherRequest
            {
                UserId = userId,
                Length = encryptionLength
            };
            //if (h != "Healthy")
            //    return null;
            //RestClient rClient = new RestClient();
            //rClient.verbHttp = httpVerb.POST;
            //rClient.endPoint = "https://localhost:44342/api/cipher/getnewcipher";
            //rClient.authTech = authenticationTechnique.RollYourOwn;
            //rClient.authType = authenticationType.Basic;
            //rClient.userName = txtUserName.Text;
            //rClient.userPassword = txtPassword.Text;
            //var strResponse = string.Empty;
            //strResponse = rClient.makeRequest();

            var c = await GetNewCipher(n);

            return c;
        }


        //private static async Task<Cipher> GetNewCipher(NewCipherRequest n)
        //{
        //    Cipher newCipher = null;
        //    try
        //    {
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(
        //            new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Add("User-Agent", ".NET Quantum Console");
        //        var streamTask = client.PostAsync("https://localhost:44342/api/Cipher/GetNewCipher", n);
        //        newCipher = await JsonSerializer.DeserializeAsync<Cipher>(await streamTask);
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return newCipher;
        //}

        //private static async Task<string> HealthCheck()
        //{
        //    var healthString = string.Empty;
        //    try
        //    {
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(
        //            new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Add("User-Agent", ".NET Quantum Console");

        //        var streamTask = client.GetStreamAsync("https://localhost:44342/api/Cipher");
        //        healthString = await JsonSerializer.DeserializeAsync<string>(await streamTask);
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return healthString;
        //}

        public async static Task<Cipher> GetNewCipher(NewCipherRequest n)
        {
            Cipher cipher = null;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44342");
                httpClient.DefaultRequestHeaders.Accept.Clear();

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

                return cipher;
            }
        }
    }
}


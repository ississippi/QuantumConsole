﻿using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuantumConsoleDesktop.Models;

namespace QuantumConsoleDesktop.Common
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum authenticationType
    {
        Basic,
        NTLM
    }

    public enum authenticationTechnique
    {
        RollYourOwn,
        NetworkCredential
    }

    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public authenticationType authType { get; set; }
        public authenticationTechnique authTech { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public httpVerb verbHttp { get; set; }


        public RestClient()
        {
            endPoint = string.Empty;
            httpMethod = verbHttp;
        }

        public string makeRequest()
        {
            var strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpVerb.POST.ToString(); //httpMethod.ToString();

            //String authHeader = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(userName + ":" + userPassword));
            //request.Headers.Add("Authorization", authType.ToString() + " " + authHeader);

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                
                //Process the response stream... (could be JSON, XML or HTML etc..._
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;
        }



    }
}



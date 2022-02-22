using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;

namespace CallingExternalWebApi
{
    public class ExternalWebApi
    {
        private string clientId = null;
        private string clientSecret = null;

        public ExternalWebApi(string _clientId, string _clientSecret)
        {
            this.clientId = _clientId;
            this.clientSecret = _clientSecret;
        }
        
        public ApiList[] GetApi()
        {
            string apiListResponse = null;
            var access_token = GenerateAccessToken();
            var apiListRequest = WebRequest.Create("https://api-sandbox.pottencial.com.br/products/v1/products/sensedia/apis");
            var httpWebRequest = (HttpWebRequest)apiListRequest;
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Headers.Add("client_id", this.clientId);
            httpWebRequest.Headers.Add("client_secret", this.clientSecret);
            httpWebRequest.Headers.Add("access_token", access_token);
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (Stream stream = httpResponse.GetResponseStream())
            {
                StreamReader streamReader = new StreamReader(stream);
                apiListResponse = streamReader.ReadToEnd();
                streamReader.Close();
            }

            ApiList[] apiList = JsonConvert.DeserializeObject<ApiList[]>(apiListResponse);
            return apiList;
        }
        public string GenerateAccessToken()
        {
            string newAccessToken = null;
            WebRequest requestObject = WebRequest.Create("https://api-sandbox.pottencial.com.br/oauth/v3/access-token");
            var encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(clientId + ":" + clientSecret));
            requestObject.Headers.Add("Authorization", "Basic " + encoded);
            requestObject.ContentType = "application/json; charset=utf-8";
            requestObject.Method = WebRequestMethods.Http.Post;
            HttpWebResponse responseObject = (HttpWebResponse)requestObject.GetResponse();

            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader streamReader = new StreamReader(stream);
                newAccessToken = streamReader.ReadToEnd();
                streamReader.Close();
            }

            AccessToken token = JsonConvert.DeserializeObject<AccessToken>(newAccessToken);
            return token.Access_token;
        }

        public List<string> GetListOfApis(ApiList[] apiList)
        {
            var listOfBrokers = new List<string>();
            foreach (var api in apiList)
            {
                listOfBrokers.Add(api.Api);
            }
            return listOfBrokers;
        }
    }
}
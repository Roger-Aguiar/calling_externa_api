using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CallingExternalWebApi
{
    public class ExternalWebApi : IWings
    {
        private string clientId = null;
        private string clientSecret = null;

        public ExternalWebApi(string _clientId, string _clientSecret)
        {
            this.clientId = _clientId;
            this.clientSecret = _clientSecret;
        }
        
        public List<ApiList> GetApi()
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

            var apiList = JsonConvert.DeserializeObject<List<ApiList>>(apiListResponse);
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

        public List<string> GetListOfApis(List<ApiList> apiList)
        {
            var listOfApis = new List<string>();
            foreach (var api in apiList)
            {                
                listOfApis.Add(char.ToUpper(api.Api[0]) + api.Api.Substring(1));                
            }
            return listOfApis;
        }

        public Broker GetBrokers()
        {
            string brokerListResponse = null;
            var token = GenerateAccessTokenBroker();
            var brokerListRequest = WebRequest.Create("https://api-corporativo-dev.pottencial.com.br/cadastro/api/corretoras?nome=%");
            var httpWebRequest = (HttpWebRequest)brokerListRequest;
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Headers["Authorization"] = $"Bearer {token}";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (Stream stream = httpResponse.GetResponseStream())
            {
                StreamReader streamReader = new StreamReader(stream);
                brokerListResponse = streamReader.ReadToEnd();
                streamReader.Close();
            }
            
            var brokerList = JsonConvert.DeserializeObject<Broker>(brokerListResponse);            
            return brokerList;
        }

        public string GenerateAccessTokenBroker()
        {
            string accessToken = null;
            WebRequest requestObject = WebRequest.Create("https://api-corporativo-dev.pottencial.com.br/cadastro/api/usuarios/pottencial-api/Potte@Api/2");
           
            requestObject.ContentType = "application/json; charset=utf-8";
            requestObject.Method = WebRequestMethods.Http.Get;
            HttpWebResponse responseObject = (HttpWebResponse)requestObject.GetResponse();

            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader streamReader = new StreamReader(stream);
                accessToken = streamReader.ReadToEnd();
                streamReader.Close();
            }

            AccessTokenBroker token = JsonConvert.DeserializeObject<AccessTokenBroker>(accessToken);
            return token.Token;
        }

        public List<string> GetListOfBrokers(BrokerResult[] brokersResult)
        {
            var brokers = new List<string>();

            foreach (var broker in brokersResult)
            {
                brokers.Add(broker.NomePessoa);                
            }
            
            brokers.Sort();
            return brokers;
        }

        public void DisplayListOfApis(List<string> apiList)
        {
            Console.WriteLine('\n');

            foreach (var api in apiList)
            {
                Console.WriteLine(api);
            }
        }

        public string[] GetListOfProductsByApi(string api, ApiList[] apiList)
        {
            string[] products = null;

            foreach (var item in apiList)
            {
                if (item.Api.ToUpper() == api.ToUpper())
                {
                    products = item.ProductsKey;
                }
            }
            return products;
        }

        public void DisplayProductsOfApis(string[] productsKey)
        {
            Console.WriteLine();
            Array.Sort(productsKey, StringComparer.InvariantCulture);

            foreach (var product in productsKey)
            {                
                string newProduct = null;                
                string [] splitProducts = product.Split(' ', '-');
                
                foreach (var splitProduct in splitProducts)
                {
                    newProduct += char.ToUpper(splitProduct[0]) + splitProduct.Substring(1) + " ";
                }
                Console.WriteLine(newProduct);
            }
        }

        public string GetCnpjOfBroker(string broker, BrokerResult[] brokersResult)
        {                      
            var cnpj = from selectedBroker in brokersResult
                       where selectedBroker.NomePessoa == broker
                       select selectedBroker.CpfCnpj.ToString();
                                   
            return cnpj.ElementAt(0);
        }
    }
}
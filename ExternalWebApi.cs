using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CallingExternalWebApi
{
    public class ExternalWebApi
    {
        private readonly HttpClient client = new HttpClient();

        private string clientId = null;
        private string clientSecret = null;

        public ExternalWebApi(string _clientId, string _clientSecret )
        {
            this.clientId = _clientId;
            this.clientSecret = _clientSecret;
        }

        public void GetUsersFromApi()
        {    
            string usersObject = null;        
            WebRequest requestObject = WebRequest.Create("https://jsonplaceholder.typicode.com/users/");
            requestObject.ContentType = "application/json; charset=utf-8";
            requestObject.Method = WebRequestMethods.Http.Get;         
            HttpWebResponse responseObject = (HttpWebResponse)requestObject.GetResponse();            
            
            using(Stream stream = responseObject.GetResponseStream())
            {                           
                StreamReader streamReader = new StreamReader(stream);
                usersObject = streamReader.ReadToEnd();
                streamReader.Close();
            }
                       
            Users [] users = JsonConvert.DeserializeObject<Users[]>(usersObject);
            DisplayUsers(users);
            Console.WriteLine($"{users.Length} users.");
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
        
        public void GetApiList()
        {    
            string apiObject = null;        
            WebRequest requestObject = WebRequest.Create("https://api-sandbox.pottencial.com.br/products/v1/products/sensedia/apis");
            //requestObject.Credentials = new NetworkCredential(clientId, clientSecret);
            requestObject.ContentType = "application/json; charset=utf-8";
            requestObject.Method = WebRequestMethods.Http.Get;         
            HttpWebResponse responseObject = (HttpWebResponse)requestObject.GetResponse();            
            
            using(Stream stream = responseObject.GetResponseStream())
            {                           
                StreamReader streamReader = new StreamReader(stream);
                apiObject = streamReader.ReadToEnd();
                streamReader.Close();
            }
                       
            /*Users [] users = JsonConvert.DeserializeObject<Users[]>(apiObject);
            DisplayUsers(users);
            Console.WriteLine($"{users.Length} users."); */
        }
        
        private void DisplayUsers(Users [] users)
        {            
            foreach(var user in users)
            {
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Street: {user.Address.Street}");
                Console.WriteLine($"Suite: {user.Address.Suite}");
                Console.WriteLine($"City: {user.Address.City}");
                Console.WriteLine($"Zip code: {user.Address.Zipcode}");
                Console.WriteLine($"Geo => Lat: {user.Address.Geo.Lat}");
                Console.WriteLine($"Geo => Lng: {user.Address.Geo.Lng}");
                Console.WriteLine($"Phone: {user.Phone}");
                Console.WriteLine($"Web site: {user.Website}");
                Console.WriteLine($"Company name: {user.Company.Name}");
                Console.WriteLine($"Company Catch Prase: {user.Company.CatchPhrase}");
                Console.WriteLine($"Company Bs: {user.Company.Bs}");
                Console.WriteLine("\n***************************************************************************************************\n");
            }
        }
        
        //This is the correct form of filling an Object
        private Users CreateJsonUsers()
        {
            var users = new Users();
            users.Id = 1;
            users.Name = "Leanne Graham";
            users.Username = "Bret";
            users.Email = "Sincere@april.biz";
            users.Address = new Address()
            {
                Street = "Kulas Light",
                Suite = "Apt. 556",
                City = "Gwenborough",
                Zipcode = "92998-3874",
                Geo = new Geo()
                {
                    Lat = "-37.3159",
                    Lng = "81.1496"
                }
            };
            users.Phone = "1-770-736-8031 x56442";
            users.Website = "hildegard.org";
            users.Company = new Company()
            {
                Name = "Romaguera-Crona",
                CatchPhrase = "Multi-layered client-server neural-net",
                Bs = "harness real-time e-markets"
            };
            return users;
        }

    }
}
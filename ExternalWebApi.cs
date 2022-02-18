using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace CallingExternalWebApi
{
    public class ExternalWebApi
    {
        public void GetUsersFromApi()
        {    
            string usersObject = null;        
            WebRequest requestObject = WebRequest.Create("https://jsonplaceholder.typicode.com/users/1");
            requestObject.ContentType = "application/json; charset=utf-8";
            requestObject.Method = WebRequestMethods.Http.Get;         
            HttpWebResponse responseObject = (HttpWebResponse)requestObject.GetResponse();            
            
            using(Stream stream = responseObject.GetResponseStream())
            {                           
                StreamReader streamReader = new StreamReader(stream);
                usersObject = streamReader.ReadToEnd();
                streamReader.Close();
            }
                       
            Users user = JsonConvert.DeserializeObject<Users>(usersObject);   
            //Users [] user = JsonConvert.DeserializeObject<Users[]>(usersObject);
        }

        public void GetApis()
        {
            string usersObject = null;        
            WebRequest requestObject = WebRequest.Create("https://api-sandbox.pottencial.com.br/products/v1/products/sensedia/apis");
            requestObject.Credentials = new NetworkCredential("c3b9d872-d137-3f79-b801-8ac182f8379f", 
                                                              "e57c37fc-236b-3204-9e54-aa25abde9111", 
                                                              "85ba15ed-e5a9-3b2c-a45e-dbcfaa26a554");
            requestObject.Method = "GET"; 
            HttpWebResponse responseObject = (HttpWebResponse)requestObject.GetResponse();            
            
            using(Stream stream = responseObject.GetResponseStream())
            {                
                StreamReader streamReader = new StreamReader(stream);
                usersObject = streamReader.ReadToEnd();
                streamReader.Close();
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
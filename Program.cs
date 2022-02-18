using System;

namespace CallingExternalWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientId = "c3b9d872-d137-3f79-b801-8ac182f8379f";
            var clientSecret = "e57c37fc-236b-3204-9e54-aa25abde9111";           
            ExternalWebApi externalWebApi = new ExternalWebApi(clientId, clientSecret);
            
            string access_token = externalWebApi.GenerateAccessToken();
            Console.WriteLine($"Access token: {access_token}");
        }
    }
}

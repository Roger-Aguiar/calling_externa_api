using System;

namespace CallingExternalWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ExternalWebApi externalWebApi = new ExternalWebApi();
            externalWebApi.GetUsersFromApi();
            //externalWebApi.GetApis();
        }
    }
}

using System;
using System.Collections.Generic;

namespace CallingExternalWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Console.Write("Enter the client_id: ");
            var client_id = Console.ReadLine();
            Console.Write("Enter the client_secret: ");
            var client_secret = Console.ReadLine(); */

            //ExternalWebApi externalWebApi = new ExternalWebApi(client_id, client_secret);
            ExternalWebApi externalWebApi = new ExternalWebApi("c3b9d872-d137-3f79-b801-8ac182f8379f", "e57c37fc-236b-3204-9e54-aa25abde9111");
            var token = externalWebApi.GenerateAccessTokenBroker();
            Console.WriteLine(token);
            //var apiList = externalWebApi.GetApi();
            //var listOfApis = externalWebApi.GetListOfApis(apiList);
            //DisplayListOfApis(listOfApis);

            //Console.Write("\nSelect an API: ");
            //var api = Console.ReadLine();

            //var listOfProductsOfApi = GetListOfProductsOfApi(api, apiList);
            //DisplayProductsOfApis(listOfProductsOfApi);
        }

        static void DisplayListOfApis(List<string> apiList)
        {
            Console.WriteLine('\n');

            foreach (var api in apiList)
            {
                Console.WriteLine(api);
            }
        }

        static string [] GetListOfProductsOfApi(string api, ApiList[] apiList)
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

        static void DisplayProductsOfApis(string [] productsKey)
        {
            Console.WriteLine();

            foreach (var product in productsKey)
            {
                Console.WriteLine(product);
            }
        }
    }
}

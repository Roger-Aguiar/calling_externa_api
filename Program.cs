using System;

namespace CallingExternalWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the client_id: ");
            var client_id = Console.ReadLine();
            Console.Write("Enter the client_secret: ");
            var client_secret = Console.ReadLine();

            ExternalWebApi externalWebApi = new ExternalWebApi(client_id, client_secret);

            ApiList[] apiList = externalWebApi.GetApi();
            var listOfApis = externalWebApi.GetListOfApis(apiList);
            DisplayListOfApis(apiList);

            Console.Write("\nSelect an API: ");
            var api = Console.ReadLine();

            var listOfProductsOfApi = GetListOfProductsOfApi(api, apiList);
            DisplayProductsOfApis(listOfProductsOfApi);
        }

        static void DisplayListOfApis(ApiList[] apiList)
        {
            Console.WriteLine('\n');

            foreach (var api in apiList)
            {
                Console.WriteLine(api.Api);
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

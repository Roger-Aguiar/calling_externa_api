namespace CallingExternalWebApi
{
    class Program
    {
        static void Main(string[] args)
        {         
            var client_id = "c3b9d872-d137-3f79-b801-8ac182f8379f"; 
            var client_secret = "e57c37fc-236b-3204-9e54-aa25abde9111";

            IWings wings = new ExternalWebApi(client_id, client_secret);
            var apiList = wings.GetApi();
            wings.DisplayProductsOfApis(apiList[3].ProductsKey);             

            var brokerList = wings.GetBrokers();

            var cnpjBroker = wings.GetCnpjOfBroker("Finlandia Corretora de Seguros LTDA", brokerList.Result);
            System.Console.WriteLine($"CNPJ: {cnpjBroker}");        
        }
    }
}

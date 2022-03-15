using System.Collections.Generic;

namespace CallingExternalWebApi
{
    public interface IWings
    {
        List<ApiList> GetApi();

        string GenerateAccessToken();

        Broker GetBrokers();

        string GenerateAccessTokenBroker();

        List<string> GetListOfBrokers(BrokerResult [] brokersResult);

        string GetCnpjOfBroker(string broker, BrokerResult [] brokersResult);

        void DisplayListOfApis(List<string> apiList);

        string [] GetListOfProductsByApi(string api, ApiList[] apiList);

        void DisplayProductsOfApis(string [] productsKey);
    }
}
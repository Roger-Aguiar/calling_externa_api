namespace CallingExternalWebApi
{
    public class ApiList
    {
        private string api;

        private string [] productsKey;
        
        public string Api { get => api; set => api = value; }
        public string [] ProductsKey { get => productsKey; set => productsKey = value; }
    }
}
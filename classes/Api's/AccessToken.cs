namespace CallingExternalWebApi
{
    public class AccessToken
    {
        private string access_token;
        private string refresh_token;
        private string token_type;
        private int expires_in;

        public string Access_token { get => access_token; set => access_token = value; }
        public string Refresh_token { get => refresh_token; set => refresh_token = value; }
        public string Token_type { get => token_type; set => token_type = value; }
        public int Expires_in { get => expires_in; set => expires_in = value; }
    }
}
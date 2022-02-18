namespace CallingExternalWebApi
{
    public class Users 
    {
        private int id;
        private string name;
        private string username;
        private string email;
        private Address address;
        private string phone;
        private string website;
        private Company company;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public Address Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Website { get => website; set => website = value; }
        public Company Company { get => company; set => company = value; }
    }
}
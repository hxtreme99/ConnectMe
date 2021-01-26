namespace ConnectMe
{
    class Client : User
    {
        public Client(int id, string name, string email, string username, string password) : base(id, name,
            email, username, password) { }
    }
}
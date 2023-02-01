namespace DP_SUM0023.Authentication
{
    public class UserSession
    {
        public string Username { get; }

        public string Role { get; }

        public UserSession(string username, string role)
        {
            Username = username;
            Role = role;
        }
    }
}

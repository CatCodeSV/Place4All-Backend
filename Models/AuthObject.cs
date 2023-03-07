namespace WebApi.Models
{
    public class AuthObject
    {
        public string? Token { get; set; }
        public Users? User { get; set; }

        public AuthObject()
        {
            Token = string.Empty;
            User = new Users();
        }

        public AuthObject (string token, Users user)
        {
            Token = token;
            User = user;
        }
    }
}

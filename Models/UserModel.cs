using System.Collections.Generic;
namespace URLShortnerMVC_Project.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<ShortUrl> Urls { get; set; } = new List<ShortUrl>();
    }
}

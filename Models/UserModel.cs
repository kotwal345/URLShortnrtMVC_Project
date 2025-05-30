using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace URLShortnerMVC_Project.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public List<ShortUrl> Urls { get; set; } = new List<ShortUrl>();
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URLShortnerMVC_Project.Models
{
    public class ShortUrl
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OriginalUrl { get; set; } = string.Empty;

        [Required]
        public string ShortenedUrl { get; set; } = string.Empty;

        // Foreign key
        [Required]
        public int UserId { get; set; }

        // Navigation property
        public UserModel User { get; set; } = null!;
    }
}

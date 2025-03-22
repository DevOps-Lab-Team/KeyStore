using System.ComponentModel.DataAnnotations;

namespace KeyStore.Models
{
    public class UserRole
    {
        [Key]
        public required int id { get; set; }
        [Required]
        public required string role { get; set; }
    }
}

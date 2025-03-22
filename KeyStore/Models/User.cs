using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeyStore.Models
{
    public class User
    {
        [Key]
        public required int id { get; set; }
        [Required]
        public required string name { get; set; }
        [Required]
        public required string password { get; set; }

        [ForeignKey("UserRole")]
        [Required]
        public required int roleid { get; set; }
        public required UserRole UserRole { get; set; }
    }
}

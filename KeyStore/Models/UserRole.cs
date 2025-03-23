using System.ComponentModel.DataAnnotations;

namespace KeyStore.Models
{
    public class UserRole
    {
        /// <summary>
        /// Id (автоинкремент)
        /// </summary>
        [Key]
        public required int id { get; set; }
        /// <summary>
        /// Название роли
        /// </summary>
        [Required]
        public required string role { get; set; }
    }
}

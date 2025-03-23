using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeyStore.Models
{
    public class User
    {
        /// <summary>
        /// Id (автоинкремент)
        /// </summary>
        [Key]
        public required int id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public required string name { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        public required string password { get; set; }
        /// <summary>
        /// Роль
        /// </summary>
        [ForeignKey("UserRole")]
        [Required]
        public required int roleid { get; set; }
        public required UserRole UserRole { get; set; }
    }
}

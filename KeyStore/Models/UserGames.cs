using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeyStore.Models
{
    public class UserGame
    {
        /// <summary>
        /// Id (автоинкремент)
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// Id пользователя
        /// </summary>
        [ForeignKey("User")]
        [Required]
        public int userid { get; set; }
        public required User User { get; set; }
        /// <summary>
        /// Id игры
        /// </summary>
        [ForeignKey("Game")]
        [Required]
        public int gameid { get; set; }        
        public required Game Game { get; set; }
    }
}

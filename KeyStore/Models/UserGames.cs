using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeyStore.Models
{
    public class UserGame
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("User")]
        [Required]
        public int userid { get; set; }
        public required User User { get; set; }

        [ForeignKey("gameid")]
        [Required]
        public int gameid { get; set; }        
        public required Game Game { get; set; }
    }
}

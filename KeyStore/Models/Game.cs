using System.ComponentModel.DataAnnotations;

namespace KeyStore.Models
{
    public class Game
    {
        /// <summary>
        /// Id (автоинкремент)
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        [Required]
        public required string name { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        [Required]
        public decimal price { get; set; }
        /// <summary>
        /// Жанр
        /// </summary>
        [Required]
        public string? genre { get; set; }
        /// <summary>
        /// Обложка
        /// </summary>
        public string? img { get; set; }
    }
}

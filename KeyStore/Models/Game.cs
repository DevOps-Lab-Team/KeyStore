namespace KeyStore.Models
{
    public class Game
    {
        /// <summary>
        /// Id (автоинкремент)
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public required string name { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// Жанр
        /// </summary>
        public string? genre { get; set; }
    }
}

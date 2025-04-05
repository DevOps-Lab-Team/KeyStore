namespace KeyStore.Dto;

public class GameDto
{
    /// <summary>
    /// Id (автоинкремент)
    /// </summary>
    //public int id { get; set; }
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
    /// <summary>
    /// Обложка
    /// </summary>
    public string? img { get; set; }
}
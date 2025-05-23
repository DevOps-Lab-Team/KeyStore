﻿namespace KeyStore.Models.Repository
{
    public interface IGameRepository
    {
        ICollection<Game> GetGames();
        Game GetGame(int id);
        Game GetGame(string name);
        bool GameExists(int id);
        bool CreateGame(Game game);
        bool DeleteGame(Game game);
        bool UpdateGame(Game game);
        bool Save();
    }
}

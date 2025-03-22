using KeyStore.Models;

namespace KeyStore.Utils
{
    public static class InitialDbValues
    {
        public static Game[] CreateGames()
        {
            return
            [
                new Game { id = 1, name = "Starcraft Brood War", price = 500, genre = "RTS" },
                new Game { id = 2, name = "Diablo II", price = 1000, genre = "RPG" },
                new Game { id = 3, name = "Balatro", price = 550, genre = "Rouge Like" },
                new Game { id = 4, name = "Ultrakill", price = 450, genre = "Shooter" },
                new Game { id = 5, name = "Noita", price = 700, genre = "Rouge Like" }
            ];
        }
    }
}

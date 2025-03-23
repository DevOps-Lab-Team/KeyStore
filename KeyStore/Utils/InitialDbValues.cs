using KeyStore.Models;

namespace KeyStore.Utils
{
    public static class InitialDbValues
    {
        public static Game[] CreateGames()
        {
            return
            [
                new Game { id = 1, name = "Starcraft Brood War", price = 500, genre = "RTS", img = "https://upload.wikimedia.org/wikipedia/ru/f/fe/StarcraftBW.jpg" },
                new Game { id = 2, name = "Diablo II", price = 1000, genre = "RPG", img = "https://upload.wikimedia.org/wikipedia/ru/thumb/0/0e/Bliz_diablo2_lg.jpg/640px-Bliz_diablo2_lg.jpg" },
                new Game { id = 3, name = "Balatro", price = 550, genre = "Rouge Like", img = "https://image.api.playstation.com/vulcan/ap/rnd/202401/2218/d8c5d5861249cd80a300efb723450f56d0347e4345e2eb80.png?w=960&h=960" },
                new Game { id = 4, name = "Ultrakill", price = 450, genre = "Shooter", img = "https://upload.wikimedia.org/wikipedia/ru/4/48/Ultrakill_cover.png" },
                new Game { id = 5, name = "Noita", price = 700, genre = "Rouge Like", img = "https://m.media-amazon.com/images/M/MV5BZGEwZDBjODAtMGFjOS00OTZmLTg2OGItZDYyMTE3MjFmOGMyXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg" }
            ];
        }
    }
}

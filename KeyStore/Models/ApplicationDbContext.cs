using KeyStore.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace KeyStore.Models
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public DbSet<Game> Game { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserGame> UserGame { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ограничение: roleId в User не может указывать на несуществующую роль
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserRole)
                .WithMany()
                .HasForeignKey(u => u.roleid)
                .OnDelete(DeleteBehavior.Restrict);

            // Многие-ко-многим: User <-> Game через UserGames
            modelBuilder.Entity<UserGame>()
                .HasIndex(ug => new { ug.userid, ug.gameid })
                .IsUnique();

            // Начальные данные для таблицы Games
            modelBuilder.Entity<Game>().HasData(InitialDbValues.CreateGames());
        }
    }
}

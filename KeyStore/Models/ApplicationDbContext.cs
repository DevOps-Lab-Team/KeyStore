using KeyStore.Utils;
using Microsoft.EntityFrameworkCore;

namespace KeyStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
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

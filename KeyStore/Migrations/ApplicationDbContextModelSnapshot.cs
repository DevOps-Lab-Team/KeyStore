﻿// <auto-generated />
using KeyStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KeyStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KeyStore.Models.Game", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("img")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.ToTable("Game");

                    b.HasData(
                        new
                        {
                            id = 1,
                            genre = "RTS",
                            img = "https://upload.wikimedia.org/wikipedia/ru/f/fe/StarcraftBW.jpg",
                            name = "Starcraft Brood War",
                            price = 500m
                        },
                        new
                        {
                            id = 2,
                            genre = "RPG",
                            img = "https://upload.wikimedia.org/wikipedia/ru/thumb/0/0e/Bliz_diablo2_lg.jpg/640px-Bliz_diablo2_lg.jpg",
                            name = "Diablo II",
                            price = 1000m
                        },
                        new
                        {
                            id = 3,
                            genre = "Rouge Like",
                            img = "https://image.api.playstation.com/vulcan/ap/rnd/202401/2218/d8c5d5861249cd80a300efb723450f56d0347e4345e2eb80.png?w=960&h=960",
                            name = "Balatro",
                            price = 550m
                        },
                        new
                        {
                            id = 4,
                            genre = "Shooter",
                            img = "https://upload.wikimedia.org/wikipedia/ru/4/48/Ultrakill_cover.png",
                            name = "Ultrakill",
                            price = 450m
                        },
                        new
                        {
                            id = 5,
                            genre = "Rouge Like",
                            img = "https://m.media-amazon.com/images/M/MV5BZGEwZDBjODAtMGFjOS00OTZmLTg2OGItZDYyMTE3MjFmOGMyXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
                            name = "Noita",
                            price = 700m
                        });
                });

            modelBuilder.Entity("KeyStore.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("roleid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("roleid");

                    b.ToTable("User");
                });

            modelBuilder.Entity("KeyStore.Models.UserGame", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("gameid")
                        .HasColumnType("integer");

                    b.Property<int>("userid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("gameid");

                    b.HasIndex("userid", "gameid")
                        .IsUnique();

                    b.ToTable("UserGame");
                });

            modelBuilder.Entity("KeyStore.Models.UserRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("KeyStore.Models.User", b =>
                {
                    b.HasOne("KeyStore.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("roleid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("KeyStore.Models.UserGame", b =>
                {
                    b.HasOne("KeyStore.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("gameid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KeyStore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}

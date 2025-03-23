using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyStore.Migrations
{
    /// <inheritdoc />
    public partial class db_v02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Game",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "id",
                keyValue: 1,
                column: "img",
                value: "https://upload.wikimedia.org/wikipedia/ru/f/fe/StarcraftBW.jpg");

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "id",
                keyValue: 2,
                column: "img",
                value: "https://upload.wikimedia.org/wikipedia/ru/thumb/0/0e/Bliz_diablo2_lg.jpg/640px-Bliz_diablo2_lg.jpg");

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "id",
                keyValue: 3,
                column: "img",
                value: "https://image.api.playstation.com/vulcan/ap/rnd/202401/2218/d8c5d5861249cd80a300efb723450f56d0347e4345e2eb80.png?w=960&h=960");

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "id",
                keyValue: 4,
                column: "img",
                value: "https://upload.wikimedia.org/wikipedia/ru/4/48/Ultrakill_cover.png");

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "id",
                keyValue: 5,
                column: "img",
                value: "https://m.media-amazon.com/images/M/MV5BZGEwZDBjODAtMGFjOS00OTZmLTg2OGItZDYyMTE3MjFmOGMyXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "Game");
        }
    }
}

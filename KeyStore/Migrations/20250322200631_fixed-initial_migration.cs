using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyStore.Migrations
{
    /// <inheritdoc />
    public partial class fixedinitial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_roleid",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "UserRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserRole_roleid",
                table: "User",
                column: "roleid",
                principalTable: "UserRole",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserRole_roleid",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "Role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_roleid",
                table: "User",
                column: "roleid",
                principalTable: "Role",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

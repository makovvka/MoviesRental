using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "UserAccountsCollection",
                newName: "UserName");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccountsCollection_Username",
                table: "UserAccountsCollection",
                newName: "IX_UserAccountsCollection_UserName");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserAccountsCollection",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserAccountsCollection",
                newName: "Username");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccountsCollection_UserName",
                table: "UserAccountsCollection",
                newName: "IX_UserAccountsCollection_Username");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserAccountsCollection",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}

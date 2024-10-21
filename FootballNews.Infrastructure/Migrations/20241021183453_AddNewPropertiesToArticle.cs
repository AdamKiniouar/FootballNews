using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballNews.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertiesToArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$7NWO1byDseatIwy6OBRmBu2JcatMs3TVfqh5/2WkE9v9tZlpJdJG.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$0pL.t0u4WbJ.dBmfQAvRLerzH5VNow5dd1QXh0BmMC7HIxwH1RCE.");
        }
    }
}

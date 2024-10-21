using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballNews.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamIdToUserAndArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Insert default team
            migrationBuilder.Sql(@"
                INSERT INTO Teams (Name, Icon, League, Trainer, Description) 
                VALUES ('IFK Göteborg', 'To Do', 1, 'To Do', 'To Do')
            ");

            // Get the ID of the default team
            migrationBuilder.Sql(@"
                DECLARE @DefaultTeamId INT;
                SELECT @DefaultTeamId = Id FROM Teams WHERE Name = 'IFK Göteborg';

                -- Update existing records to reference the default team
                UPDATE Users SET TeamId = @DefaultTeamId WHERE TeamId = 0;
                UPDATE Articles SET TeamId = @DefaultTeamId WHERE TeamId = 0;
            ");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TeamId",
                table: "Articles",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Teams_TeamId",
                table: "Articles",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Teams_TeamId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TeamId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Articles_TeamId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Articles");

            migrationBuilder.Sql("DELETE FROM Teams WHERE Name = 'IFK Göteborg'");
        }
    }
}
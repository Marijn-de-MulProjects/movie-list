using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieList.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserAndMovieListRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "MovieLists",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MovieListUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MovieListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieListUsers", x => new { x.UserId, x.MovieListId });
                    table.ForeignKey(
                        name: "FK_MovieListUsers_MovieLists_MovieListId",
                        column: x => x.MovieListId,
                        principalTable: "MovieLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieListUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieLists_UserId1",
                table: "MovieLists",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_MovieListUsers_MovieListId",
                table: "MovieListUsers",
                column: "MovieListId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieLists_Users_UserId1",
                table: "MovieLists",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieLists_Users_UserId1",
                table: "MovieLists");

            migrationBuilder.DropTable(
                name: "MovieListUsers");

            migrationBuilder.DropIndex(
                name: "IX_MovieLists_UserId1",
                table: "MovieLists");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "MovieLists");
        }
    }
}

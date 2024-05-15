using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookshelf2_api.Migrations
{
    /// <inheritdoc />
    public partial class CreateBookShelfDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    displayName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__3213E83FF03ADD68", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    author = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    pages = table.Column<int>(type: "int", nullable: true),
                    lentOut = table.Column<bool>(type: "bit", nullable: true),
                    ownerId = table.Column<int>(type: "int", nullable: true),
                    lentOutToId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Book__3213E83F56B36CA8", x => x.id);
                    table.ForeignKey(
                        name: "FK__Book__lentOutToI__5070F446",
                        column: x => x.lentOutToId,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Book__ownerId__4F7CD00D",
                        column: x => x.ownerId,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "displayName", "username" },
                values: new object[,]
                {
                    { 1, "Orville Wright", "orville" },
                    { 2, "Amelia Earhart", "amelia" },
                    { 3, "Bessie Coleman", "bessie" },
                    { 4, "Charles Lindbergh", "charles" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "id", "author", "lentOut", "lentOutToId", "ownerId", "pages", "title" },
                values: new object[,]
                {
                    { 1, "Jane Austen", false, null, 1, 432, "Pride and Prejudice" },
                    { 2, "Harper Lee", true, 2, 1, 281, "To Kill a Mockingbird" },
                    { 3, "Gabriel García Márquez", true, 4, 1, 448, "One Hundred Years of Solitude" },
                    { 4, "Truman Capote", false, null, 1, 368, "In Cold Blood" },
                    { 5, "Mark Twain", true, 3, 1, 308, "The Adventures of Tom Sawyer" },
                    { 6, "Mark Twain", false, null, 1, 366, "The Adventures of Huckleberry Finn" },
                    { 7, "F. Scott Fitzgerald", false, null, 2, 192, "The Great Gatsby" },
                    { 8, "Fyodor Dostoevsky", true, 1, 2, 492, "Crime and Punishment" },
                    { 9, "Truman Capote", true, 3, 2, 368, "In Cold Blood" },
                    { 10, "Aldous Huxley", false, null, 2, 288, "Brave New World" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_lentOutToId",
                table: "Book",
                column: "lentOutToId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_ownerId",
                table: "Book",
                column: "ownerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

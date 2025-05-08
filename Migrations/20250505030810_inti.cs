using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Search_Engine.Migrations
{
    /// <inheritdoc />
    public partial class inti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    UrlId = table.Column<int>(type: "int", nullable: false),
                    UrlName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rank = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.UrlId);
                });

            migrationBuilder.CreateTable(
                name: "InvertedIndexes",
                columns: table => new
                {
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    FirstPosition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_InvertedIndexes_Urls_UrlId",
                        column: x => x.UrlId,
                        principalTable: "Urls",
                        principalColumn: "UrlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvertedIndexes_UrlId",
                table: "InvertedIndexes",
                column: "UrlId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvertedIndexes");

            migrationBuilder.DropTable(
                name: "Urls");
        }
    }
}

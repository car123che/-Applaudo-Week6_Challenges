using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFUnivestityRentalData.Migrations
{
    public partial class DBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PosterStock = table.Column<int>(type: "int", nullable: false),
                    TrailerLink = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieTags_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Availability", "Description", "Likes", "PosterStock", "SalePrice", "Title", "TrailerLink" },
                values: new object[,]
                {
                    { 1, 0, "Marvel Studios Avenger", 80, 5, 10.52, "Avengers", "Avengers.com" },
                    { 2, 0, "Marvel Studios Avenger", 90, 4, 13.52, "Avengers 2", "Avengers.com" },
                    { 3, 0, "Dicaprio el origen", 50, 3, 12.52, "El origen", "ELROGINE.COM" },
                    { 4, 0, "Nemo nemo", 70, 4, 9.5199999999999996, "Nemo", "Nemo.com" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Accion" },
                    { 2, "Comedia" },
                    { 3, "Niños" },
                    { 4, "Suspenso" },
                    { 5, "Misiones" },
                    { 6, "Animadas" }
                });

            migrationBuilder.InsertData(
                table: "MovieTags",
                columns: new[] { "Id", "MovieId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 1 },
                    { 4, 2, 2 },
                    { 5, 3, 3 },
                    { 6, 4, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_SalePrice",
                table: "Movies",
                column: "SalePrice");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Title",
                table: "Movies",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTags_MovieId",
                table: "MovieTags",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTags_TagId",
                table: "MovieTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTags");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}

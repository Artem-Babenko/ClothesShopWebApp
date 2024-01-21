using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WearShopWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudienceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Audiences_AudienceId",
                        column: x => x.AudienceId,
                        principalTable: "Audiences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prise = table.Column<float>(type: "real", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaterialsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clothes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClothesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colors_Clothes_ClothesId",
                        column: x => x.ClothesId,
                        principalTable: "Clothes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ClothesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Clothes_ClothesId",
                        column: x => x.ClothesId,
                        principalTable: "Clothes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClothesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Clothes_ClothesId",
                        column: x => x.ClothesId,
                        principalTable: "Clothes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClothesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sizes_Clothes_ClothesId",
                        column: x => x.ClothesId,
                        principalTable: "Clothes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Audiences",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "male" },
                    { 2, "female" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "AudienceId", "Name", "PhotoPath" },
                values: new object[,]
                {
                    { 1, 1, "Куртки", "/categoryPhotos/men's jacket.jpeg" },
                    { 2, 1, "Джинси", "/categoryPhotos/men's jeans.jpg" },
                    { 3, 1, "Штани", "/categoryPhotos/men's pants.jpg" },
                    { 4, 1, "Світшоти", "/categoryPhotos/men's sweatshirt.jpg" },
                    { 5, 1, "Светри", null },
                    { 6, 1, "Футболки", null },
                    { 7, 1, "Сорочки", null },
                    { 8, 1, "Шорти", null },
                    { 9, 2, "Куртки та пальта", null },
                    { 10, 2, "Джинси", null },
                    { 11, 2, "Штани і легінси", null },
                    { 12, 2, "Світшоти", null },
                    { 13, 2, "Светри", null },
                    { 14, 2, "Блузки", null },
                    { 15, 2, "Футболки та топи", null },
                    { 16, 2, "Сукні", null },
                    { 17, 2, "Сорочки", null },
                    { 18, 2, "Спідниці", null },
                    { 19, 2, "Шорти", null }
                });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "CategoryId", "Count", "CreateDate", "Description", "MaterialsDescription", "Name", "Prise" },
                values: new object[] { 1, 1, 5, new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Local), null, "100% поліестер", "Чоловічий пуховик на блискавці", 1549f });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "ClothesId", "Hex", "Name" },
                values: new object[,]
                {
                    { 1, 1, "#CCC", "Сірий" },
                    { 2, 1, "#3d0f0f", "Бордовий" },
                    { 3, 1, "#0f144a", "Синій" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "ClothesId", "LocalPath" },
                values: new object[,]
                {
                    { 1, 1, "/clothesPhotos/169579534755b6b57ee8d8805234309d890fb7.jpg" },
                    { 2, 1, "/clothesPhotos/169579534448daa59f7bb9c796ea145ace05723c21_thumbnail_900x.jpg" },
                    { 3, 1, "/clothesPhotos/1695795342ad226754a58ed6ff5a733f3599bed69b_thumbnail_900x.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "ClothesId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "46 (S)" },
                    { 2, 1, "48 (M)" },
                    { 3, 1, "50 (L)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AudienceId",
                table: "Categories",
                column: "AudienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_CategoryId",
                table: "Clothes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ClothesId",
                table: "Colors",
                column: "ClothesId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ClothesId",
                table: "Comments",
                column: "ClothesId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ClothesId",
                table: "Photos",
                column: "ClothesId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ClothesId",
                table: "Sizes",
                column: "ClothesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Audiences");
        }
    }
}

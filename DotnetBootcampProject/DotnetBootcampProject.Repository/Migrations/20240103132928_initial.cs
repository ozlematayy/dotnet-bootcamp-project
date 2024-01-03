using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetBootcampProject.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicationInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edition = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicationInfos_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "ContactEmail", "CreatedDate", "PublisherName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "İstanbul", "iletisim@ykykultur.com", new DateTime(2024, 1, 3, 16, 29, 28, 88, DateTimeKind.Local).AddTicks(499), "Yapı Kredi Yayınları", null },
                    { 2, "İstanbul", "iletisim@pegasus.com", new DateTime(2024, 1, 3, 16, 29, 28, 88, DateTimeKind.Local).AddTicks(500), "Pegasus Yayınları", null },
                    { 3, "Ankara", "iletisim@iskultur.com", new DateTime(2024, 1, 3, 16, 29, 28, 88, DateTimeKind.Local).AddTicks(501), "İş Bankası Kültür Yayınları", null },
                    { 4, "İstanbul", "info@everest.com", new DateTime(2024, 1, 3, 16, 29, 28, 88, DateTimeKind.Local).AddTicks(502), "Everest Yayınları", null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "BookName", "CreatedDate", "Genre", "PublisherId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Fyodor Dostoyevski", "Suç ve Ceza", new DateTime(2024, 1, 3, 16, 29, 28, 88, DateTimeKind.Local).AddTicks(195), "Psikolojik Roman", 3, null },
                    { 2, "Ahmet Hamdi Tanpınar", "Saatleri Ayarlama Enstitüsü", new DateTime(2024, 1, 3, 16, 29, 28, 88, DateTimeKind.Local).AddTicks(204), "Edebi Kurgu", 1, null },
                    { 3, " Stephen King", "Kara Kule: Silahşör", new DateTime(2024, 1, 3, 16, 29, 28, 88, DateTimeKind.Local).AddTicks(205), "Bilim Kurgu", 2, null },
                    { 4, "Sabahattin Ali", "Kürk Mantolu Madonna", new DateTime(2024, 1, 3, 16, 29, 28, 88, DateTimeKind.Local).AddTicks(206), "Edebi Kurgu romanı", 4, null }
                });

            migrationBuilder.InsertData(
                table: "PublicationInfos",
                columns: new[] { "Id", "BookId", "CreatedDate", "Edition", "PublicationDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 3, 16, 29, 28, 88, DateTimeKind.Local).AddTicks(369), 1, new DateTime(1866, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 2, new DateTime(2024, 1, 3, 16, 29, 28, 88, DateTimeKind.Local).AddTicks(371), 1, new DateTime(1954, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 3, new DateTime(2024, 1, 3, 16, 29, 28, 88, DateTimeKind.Local).AddTicks(371), 1, new DateTime(1982, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, 4, new DateTime(2024, 1, 3, 16, 29, 28, 88, DateTimeKind.Local).AddTicks(372), 1, new DateTime(1981, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 4, new DateTime(2024, 1, 3, 16, 29, 28, 88, DateTimeKind.Local).AddTicks(373), 2, new DateTime(2001, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationInfos_BookId",
                table: "PublicationInfos",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicationInfos");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}

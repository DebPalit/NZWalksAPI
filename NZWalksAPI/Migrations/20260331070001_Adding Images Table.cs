using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("56da5bcd-0a54-4742-8048-9acec8c0bff8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c982ef08-f130-4b09-963b-b4dc44843b2e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("fbd4e8ac-4eb5-4199-aefc-4731644fb0ef"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5513d45f-be9e-46df-b40d-cb06e404d552"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("56005eaf-7aa7-4244-9b5d-723a25b995c4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6e73bf95-6faf-4954-b360-5cb197a3ef25"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7d42bb7b-baa5-4e3c-a3f6-3b554df46f95"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a3bd61b1-638d-4643-a2a8-45be6e6a43b8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d6a2cb96-f2e3-4417-baa4-b22ad876f4e1"));

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("56da5bcd-0a54-4742-8048-9acec8c0bff8"), "Medium" },
                    { new Guid("c982ef08-f130-4b09-963b-b4dc44843b2e"), "Hard" },
                    { new Guid("fbd4e8ac-4eb5-4199-aefc-4731644fb0ef"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("5513d45f-be9e-46df-b40d-cb06e404d552"), "STL", "Southland", "null" },
                    { new Guid("56005eaf-7aa7-4244-9b5d-723a25b995c4"), "AKL", "Auckland", "https://images.pexels.com/photos/5342978/pexels-photo-5342978.jpeg" },
                    { new Guid("6e73bf95-6faf-4954-b360-5cb197a3ef25"), "NSL", "Nelson", "https://media.istockphoto.com/id/1209995566/photo/panorama-of-nelson-city-reflected-in-the-maitai-river-new-zealand.jpg?s=1024x1024&w=is&k=20&c=ynC5H3sKnrq4Tc4swHlao07JPv13wPEmdwuGG6d7IQE=" },
                    { new Guid("7d42bb7b-baa5-4e3c-a3f6-3b554df46f95"), "NTL", "Northland", "null" },
                    { new Guid("a3bd61b1-638d-4643-a2a8-45be6e6a43b8"), "BOP", "Bay Of Plenty", "null" },
                    { new Guid("d6a2cb96-f2e3-4417-baa4-b22ad876f4e1"), "WGL", "Wellington", "https://images.pexels.com/photos/33954807/pexels-photo-33954807.jpeg" }
                });
        }
    }
}

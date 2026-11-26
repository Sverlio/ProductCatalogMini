using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductCatalogData.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            // Прехвърляме уникалните имена на съществуващите категории в новата таблица Categories
            migrationBuilder.Sql(@"
                INSERT INTO [Categories] ([Name])
                SELECT DISTINCT LTRIM(RTRIM([Category]))
                FROM [Products]
                WHERE [Category] IS NOT NULL AND LTRIM(RTRIM([Category])) <> '';

                IF NOT EXISTS (SELECT 1 FROM [Categories]) AND EXISTS (SELECT 1 FROM [Products])
                BEGIN
                    INSERT INTO [Categories] ([Name]) VALUES (N'Общи');
                END

                UPDATE p
                SET p.[CategoryId] = c.[Id]
                FROM [Products] p
                INNER JOIN [Categories] c ON LTRIM(RTRIM(p.[Category])) = c.[Name];

                UPDATE [Products]
                SET [CategoryId] = (SELECT TOP (1) [Id] FROM [Categories] ORDER BY [Id])
                WHERE [CategoryId] IS NULL;
            ");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(@"
                UPDATE p
                SET p.[Category] = c.[Name]
                FROM [Products] p
                INNER JOIN [Categories] c ON p.[CategoryId] = c.[Id];
            ");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Faber-Castell", "Пишещи средства", "Химикалка Blue Gel", 2.50m, 150 },
                    { 2, "Miquelrius", "Хартиени изделия", "Тетрадка А5 (80 листа)", 4.80m, 80 },
                    { 3, "Stabilo", "Пишещи средства", "Маркер жълт", 3.20m, 45 }
                });
        }
    }
}
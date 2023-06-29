using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Config.AppContext.Migrations
{
    public partial class UpdateCategoryTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorys_ProductTypes_ProductTypeId",
                table: "Categorys");

            migrationBuilder.DropIndex(
                name: "IX_Categorys_ProductTypeId",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "Categorys");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_CategoryId",
                table: "ProductTypes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Categorys_CategoryId",
                table: "ProductTypes",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Categorys_CategoryId",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_CategoryId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "Categorys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_ProductTypeId",
                table: "Categorys",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorys_ProductTypes_ProductTypeId",
                table: "Categorys",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id");
        }
    }
}

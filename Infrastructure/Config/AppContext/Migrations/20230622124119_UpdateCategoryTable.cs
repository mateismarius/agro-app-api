using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Config.AppContext.Migrations
{
    public partial class UpdateCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

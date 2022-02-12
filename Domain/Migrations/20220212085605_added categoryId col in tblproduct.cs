using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class addedcategoryIdcolintblproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "tblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_CategoryId",
                table: "tblProduct",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProduct_tblCategories_CategoryId",
                table: "tblProduct",
                column: "CategoryId",
                principalTable: "tblCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProduct_tblCategories_CategoryId",
                table: "tblProduct");

            migrationBuilder.DropIndex(
                name: "IX_tblProduct_CategoryId",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "tblProduct");
        }
    }
}

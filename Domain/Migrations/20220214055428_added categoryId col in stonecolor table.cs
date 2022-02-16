using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class addedcategoryIdcolinstonecolortable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category_Id",
                table: "tblCategoryStoneColors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblCategoryStoneColors_CategoryId",
                table: "tblCategoryStoneColors",
                column: "Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCategoryStoneColors_tblCategories_Category_Id",
                table: "tblCategoryStoneColors",
                column: "Category_Id",
                principalTable: "tblCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "StoneColorId",
               table: "tblCategories",
               type: "int",
               nullable: false,
               defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblCategories_StoneColorId",
                table: "tblCategories",
                column: "StoneColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCategoryStoneColors_tblCategories_Category_Id",
                table: "tblCategoryStoneColors",
                column: "Category_Id",
                principalTable: "tblCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

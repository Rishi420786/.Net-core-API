using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class addedcategoryIdcolinstonecolormastertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_tblCategories_tblCategoryStoneColors_StoneColorId",
            //    table: "tblCategories");

            //migrationBuilder.DropIndex(
            //    name: "IX_tblCategories_StoneColorId",
            //    table: "tblCategories");

            //migrationBuilder.DropColumn(
            //    name: "StoneColorId",
            //    table: "tblCategories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "tblCategoryStoneColors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblCategoryStoneColors_CategoryId",
                table: "tblCategoryStoneColors",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCategoryStoneColors_tblCategories_CategoryId",
                table: "tblCategoryStoneColors",
                column: "CategoryId",
                principalTable: "tblCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_tblCategoryStoneColors_tblCategories_CategoryId",
            //    table: "tblCategoryStoneColors");

            //migrationBuilder.DropIndex(
            //    name: "IX_tblCategoryStoneColors_CategoryId",
            //    table: "tblCategoryStoneColors");

            //migrationBuilder.DropColumn(
            //    name: "CategoryId",
            //    table: "tblCategoryStoneColors");

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
                name: "FK_tblCategories_tblCategoryStoneColors_StoneColorId",
                table: "tblCategories",
                column: "StoneColorId",
                principalTable: "tblCategoryStoneColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

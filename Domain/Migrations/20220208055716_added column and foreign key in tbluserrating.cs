using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class addedcolumnandforeignkeyintbluserrating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FromUserId",
                table: "tblUserRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRatings_FromUserId",
                table: "tblUserRatings",
                column: "FromUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserRatings_tblUsers_FromUserId",
                table: "tblUserRatings",
                column: "FromUserId",
                principalTable: "tblUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUserRatings_tblUsers_FromUserId",
                table: "tblUserRatings");

            migrationBuilder.DropIndex(
                name: "IX_tblUserRatings_FromUserId",
                table: "tblUserRatings");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "tblUserRatings");
        }
    }
}

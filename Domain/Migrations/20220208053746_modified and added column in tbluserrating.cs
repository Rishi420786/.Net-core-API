using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class modifiedandaddedcolumnintbluserrating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUserRatings_tblUsers_UserId",
                table: "tblUserRatings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "tblUserRatings",
                newName: "ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserRatings_UserId",
                table: "tblUserRatings",
                newName: "IX_tblUserRatings_ToUserId");

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

            //migrationBuilder.AddForeignKey(
            //    name: "FK_tblUserRatings_tblUsers_FromUserId",
            //    table: "tblUserRatings",
            //    column: "FromUserId",
            //    principalTable: "tblUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserRatings_tblUsers_ToUserId",
                table: "tblUserRatings",
                column: "ToUserId",
                principalTable: "tblUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUserRatings_tblUsers_FromUserId",
                table: "tblUserRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserRatings_tblUsers_ToUserId",
                table: "tblUserRatings");

            //migrationBuilder.DropIndex(
            //    name: "IX_tblUserRatings_FromUserId",
            //    table: "tblUserRatings");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "tblUserRatings");

            migrationBuilder.RenameColumn(
                name: "ToUserId",
                table: "tblUserRatings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserRatings_ToUserId",
                table: "tblUserRatings",
                newName: "IX_tblUserRatings_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserRatings_tblUsers_UserId",
                table: "tblUserRatings",
                column: "UserId",
                principalTable: "tblUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

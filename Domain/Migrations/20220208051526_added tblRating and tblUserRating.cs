using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class addedtblRatingandtblUserRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUsers_TblRole_RoleId",
                table: "tblUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblRole",
                table: "TblRole");

            migrationBuilder.RenameTable(
                name: "TblRole",
                newName: "tblRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblRoles",
                table: "tblRoles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tblRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRatings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUserRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblUserRatings_tblRatings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "tblRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblUserRatings_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRatings_RatingId",
                table: "tblUserRatings",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRatings_UserId",
                table: "tblUserRatings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUsers_tblRoles_RoleId",
                table: "tblUsers",
                column: "RoleId",
                principalTable: "tblRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUsers_tblRoles_RoleId",
                table: "tblUsers");

            migrationBuilder.DropTable(
                name: "tblUserRatings");

            migrationBuilder.DropTable(
                name: "tblRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblRoles",
                table: "tblRoles");

            migrationBuilder.RenameTable(
                name: "tblRoles",
                newName: "TblRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblRole",
                table: "TblRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUsers_TblRole_RoleId",
                table: "tblUsers",
                column: "RoleId",
                principalTable: "TblRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

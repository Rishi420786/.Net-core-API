using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class addedemployeeanddealertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEmployeeMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MobileNo = table.Column<string>(type: "varchar(15)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PAN = table.Column<string>(type: "varchar(15)", nullable: false),
                    Aadhaar = table.Column<string>(type: "varchar(15)", nullable: false),
                    UniqueId = table.Column<string>(type: "varchar(20)", nullable: false),
                    Destination = table.Column<string>(type: "varchar(20)", nullable: false),
                    Designation = table.Column<string>(type: "varchar(50)", nullable: false),
                    State = table.Column<string>(type: "varchar(20)", nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", nullable: false),
                    ImageFileName = table.Column<string>(type: "varchar(150)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployeeMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmployeeMaster_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDealers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopName = table.Column<string>(type: "varchar(150)", nullable: false),
                    Discount = table.Column<string>(type: "varchar(10)", nullable: false),
                    GstNo = table.Column<string>(type: "varchar(10)", nullable: false),
                    MobileNo = table.Column<string>(type: "varchar(15)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "varchar(20)", nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", nullable: false),
                    ImageFileName = table.Column<string>(type: "varchar(150)", nullable: false),
                    SalesmanId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblDealers_tblEmployeeMaster_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblDealers_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblDealers_SalesmanId",
                table: "tblDealers",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDealers_UserId",
                table: "tblDealers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMaster_UserId",
                table: "tblEmployeeMaster",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDealers");

            migrationBuilder.DropTable(
                name: "tblEmployeeMaster");
        }
    }
}

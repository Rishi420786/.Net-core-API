using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class addedcategoryandqualitytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblStoneColorMaster");

            migrationBuilder.CreateTable(
                name: "tblCategoryStoneColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryColor = table.Column<string>(type: "varchar(50)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategoryStoneColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblGstMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gst = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGstMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(70)", nullable: false),
                    UniqueNumber = table.Column<string>(type: "varchar(30)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    StoneCutId = table.Column<int>(type: "int", nullable: false),
                    StoneShapeId = table.Column<int>(type: "int", nullable: false),
                    StoneColorId = table.Column<int>(type: "int", nullable: false),
                    GstId = table.Column<int>(type: "int", nullable: false),
                    QualityId = table.Column<int>(type: "int", nullable: false),
                    Magnification = table.Column<string>(type: "varchar(30)", nullable: false),
                    OpticCharacter = table.Column<string>(type: "varchar(30)", nullable: false),
                    ReferactiveIndex = table.Column<string>(type: "varchar(30)", nullable: false),
                    Birefringence = table.Column<double>(type: "float", nullable: false),
                    SpecificGravity = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_tblCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCategories_tblCategoryStoneColors_StoneColorId",
                        column: x => x.StoneColorId,
                        principalTable: "tblCategoryStoneColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCategories_tblGstMaster_GstId",
                        column: x => x.GstId,
                        principalTable: "tblGstMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCategories_tblQualityMaster_QualityId",
                        column: x => x.QualityId,
                        principalTable: "tblQualityMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCategories_tblStoneCutMaster_StoneCutId",
                        column: x => x.StoneCutId,
                        principalTable: "tblStoneCutMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCategories_tblStoneShapeMaster_StoneShapeId",
                        column: x => x.StoneShapeId,
                        principalTable: "tblStoneShapeMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCategories_GstId",
                table: "tblCategories",
                column: "GstId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategories_QualityId",
                table: "tblCategories",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategories_StoneColorId",
                table: "tblCategories",
                column: "StoneColorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategories_StoneCutId",
                table: "tblCategories",
                column: "StoneCutId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategories_StoneShapeId",
                table: "tblCategories",
                column: "StoneShapeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCategories");

            migrationBuilder.DropTable(
                name: "tblCategoryStoneColors");

            migrationBuilder.DropTable(
                name: "tblGstMaster");

            migrationBuilder.CreateTable(
                name: "tblStoneColorMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStoneColorMaster", x => x.Id);
                });
        }
    }
}

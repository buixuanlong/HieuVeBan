using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldMBTIFunctionalFactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name_en",
                schema: "dbo",
                table: "mbti_functional_factors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "colors",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mbti_functional_factor_name_details",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    character = table.Column<byte>(type: "tinyint", maxLength: 255, nullable: false),
                    sort_order = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    color_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mbti_functional_factor_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mbti_functional_factor_name_details", x => x.id);
                    table.ForeignKey(
                        name: "FK_mbti_functional_factor_name_details_colors_color_id",
                        column: x => x.color_id,
                        principalSchema: "dbo",
                        principalTable: "colors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_mbti_functional_factor_name_details_mbti_functional_factors_mbti_functional_factor_id",
                        column: x => x.mbti_functional_factor_id,
                        principalSchema: "dbo",
                        principalTable: "mbti_functional_factors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mbti_functional_factor_name_details_color_id",
                schema: "dbo",
                table: "mbti_functional_factor_name_details",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_mbti_functional_factor_name_details_mbti_functional_factor_id",
                schema: "dbo",
                table: "mbti_functional_factor_name_details",
                column: "mbti_functional_factor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mbti_functional_factor_name_details",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "colors",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "name_en",
                schema: "dbo",
                table: "mbti_functional_factors");
        }
    }
}

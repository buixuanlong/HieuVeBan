using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldMBTIResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "dbo",
                table: "mbti_personality_groups",
                newName: "description");

            migrationBuilder.CreateIndex(
                name: "IX_mbti_functional_factors_symbol",
                schema: "dbo",
                table: "mbti_functional_factors",
                column: "symbol",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_mbti_functional_factors_symbol",
                schema: "dbo",
                table: "mbti_functional_factors");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "dbo",
                table: "mbti_personality_groups",
                newName: "Description");
        }
    }
}

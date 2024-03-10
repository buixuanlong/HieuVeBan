using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeInPersonalityAssessmentQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "type",
                schema: "dbo",
                table: "personality_assessment_method",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                comment: "Type of MethodType: 1 Holland, 2 MBTI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                schema: "dbo",
                table: "personality_assessment_method");
        }
    }
}

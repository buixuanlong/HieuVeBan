using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitPersonalityAssessmentQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_datetime",
                schema: "dbo",
                table: "personality_assessment_method");

            migrationBuilder.CreateTable(
                name: "personality_assessment_question",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    question_number = table.Column<int>(type: "int", nullable: false),
                    question_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalityAssessmentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personality_assessment_question", x => x.id);
                    table.ForeignKey(
                        name: "FK_personality_assessment_question_personality_assessment_method_PersonalityAssessmentMethodId",
                        column: x => x.PersonalityAssessmentMethodId,
                        principalSchema: "dbo",
                        principalTable: "personality_assessment_method",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personality_assessment_question_PersonalityAssessmentMethodId",
                schema: "dbo",
                table: "personality_assessment_question",
                column: "PersonalityAssessmentMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personality_assessment_question",
                schema: "dbo");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_datetime",
                schema: "dbo",
                table: "personality_assessment_method",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

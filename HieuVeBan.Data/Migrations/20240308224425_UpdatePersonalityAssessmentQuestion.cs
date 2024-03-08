using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePersonalityAssessmentQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personality_assessment_question_personality_assessment_method_PersonalityAssessmentMethodId",
                schema: "dbo",
                table: "personality_assessment_question");

            migrationBuilder.RenameColumn(
                name: "PersonalityAssessmentMethodId",
                schema: "dbo",
                table: "personality_assessment_question",
                newName: "personality_assessment_method_id");

            migrationBuilder.RenameIndex(
                name: "IX_personality_assessment_question_PersonalityAssessmentMethodId",
                schema: "dbo",
                table: "personality_assessment_question",
                newName: "IX_personality_assessment_question_personality_assessment_method_id");

            migrationBuilder.AddForeignKey(
                name: "FK_personality_assessment_question_personality_assessment_method_personality_assessment_method_id",
                schema: "dbo",
                table: "personality_assessment_question",
                column: "personality_assessment_method_id",
                principalSchema: "dbo",
                principalTable: "personality_assessment_method",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personality_assessment_question_personality_assessment_method_personality_assessment_method_id",
                schema: "dbo",
                table: "personality_assessment_question");

            migrationBuilder.RenameColumn(
                name: "personality_assessment_method_id",
                schema: "dbo",
                table: "personality_assessment_question",
                newName: "PersonalityAssessmentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_personality_assessment_question_personality_assessment_method_id",
                schema: "dbo",
                table: "personality_assessment_question",
                newName: "IX_personality_assessment_question_PersonalityAssessmentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_personality_assessment_question_personality_assessment_method_PersonalityAssessmentMethodId",
                schema: "dbo",
                table: "personality_assessment_question",
                column: "PersonalityAssessmentMethodId",
                principalSchema: "dbo",
                principalTable: "personality_assessment_method",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

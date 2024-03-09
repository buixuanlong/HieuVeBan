using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "holland_answer",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    short_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_holland_answer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mbti_answer",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personality_assessment_question_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mbti_answer", x => x.id);
                    table.ForeignKey(
                        name: "FK_mbti_answer_personality_assessment_question_personality_assessment_question_id",
                        column: x => x.personality_assessment_question_id,
                        principalSchema: "dbo",
                        principalTable: "personality_assessment_question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mbti_answer_personality_assessment_question_id",
                schema: "dbo",
                table: "mbti_answer",
                column: "personality_assessment_question_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "holland_answer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mbti_answer",
                schema: "dbo");
        }
    }
}

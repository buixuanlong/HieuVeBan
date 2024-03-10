using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitMBTIResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mbti_dichotomous_pairs",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mbti_dichotomous_pairs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mbti_personality_groups",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    symbol = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mbti_personality_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mbti_functional_factors",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    symbol = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    mbti_dichotomous_pair_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mbti_functional_factors", x => x.id);
                    table.ForeignKey(
                        name: "FK_mbti_functional_factors_mbti_dichotomous_pairs_mbti_dichotomous_pair_id",
                        column: x => x.mbti_dichotomous_pair_id,
                        principalSchema: "dbo",
                        principalTable: "mbti_dichotomous_pairs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "mbti_celebrities",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personality_group_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mbti_celebrities", x => x.id);
                    table.ForeignKey(
                        name: "FK_mbti_celebrities_mbti_personality_groups_personality_group_id",
                        column: x => x.personality_group_id,
                        principalSchema: "dbo",
                        principalTable: "mbti_personality_groups",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "mbti_results",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mbti_functional_factor_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    personality_assessment_question_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mbti_answer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mark = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mbti_results", x => x.id);
                    table.ForeignKey(
                        name: "FK_mbti_results_mbti_answers_mbti_answer_id",
                        column: x => x.mbti_answer_id,
                        principalSchema: "dbo",
                        principalTable: "mbti_answers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_mbti_results_mbti_functional_factors_mbti_functional_factor_id",
                        column: x => x.mbti_functional_factor_id,
                        principalSchema: "dbo",
                        principalTable: "mbti_functional_factors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_mbti_results_personality_assessment_questions_personality_assessment_question_id",
                        column: x => x.personality_assessment_question_id,
                        principalSchema: "dbo",
                        principalTable: "personality_assessment_questions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_mbti_celebrities_personality_group_id",
                schema: "dbo",
                table: "mbti_celebrities",
                column: "personality_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_mbti_functional_factors_mbti_dichotomous_pair_id",
                schema: "dbo",
                table: "mbti_functional_factors",
                column: "mbti_dichotomous_pair_id");

            migrationBuilder.CreateIndex(
                name: "IX_mbti_results_mbti_answer_id",
                schema: "dbo",
                table: "mbti_results",
                column: "mbti_answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_mbti_results_mbti_functional_factor_id",
                schema: "dbo",
                table: "mbti_results",
                column: "mbti_functional_factor_id");

            migrationBuilder.CreateIndex(
                name: "IX_mbti_results_personality_assessment_question_id",
                schema: "dbo",
                table: "mbti_results",
                column: "personality_assessment_question_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mbti_celebrities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mbti_results",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mbti_personality_groups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mbti_functional_factors",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mbti_dichotomous_pairs",
                schema: "dbo");
        }
    }
}

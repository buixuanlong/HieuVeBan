using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldProvince : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mbti_answer_personality_assessment_question_personality_assessment_question_id",
                schema: "dbo",
                table: "mbti_answer");

            migrationBuilder.DropForeignKey(
                name: "FK_personality_assessment_question_personality_assessment_method_personality_assessment_method_id",
                schema: "dbo",
                table: "personality_assessment_question");

            migrationBuilder.DropForeignKey(
                name: "FK_user_information_province_province_id",
                schema: "dbo",
                table: "user_information");

            migrationBuilder.DropForeignKey(
                name: "FK_user_information_user_object_user_object_id",
                schema: "dbo",
                table: "user_information");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_object",
                schema: "dbo",
                table: "user_object");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_information",
                schema: "dbo",
                table: "user_information");

            migrationBuilder.DropPrimaryKey(
                name: "PK_province",
                schema: "dbo",
                table: "province");

            migrationBuilder.DropPrimaryKey(
                name: "PK_personality_assessment_question",
                schema: "dbo",
                table: "personality_assessment_question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_personality_assessment_method",
                schema: "dbo",
                table: "personality_assessment_method");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mbti_answer",
                schema: "dbo",
                table: "mbti_answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_holland_answer",
                schema: "dbo",
                table: "holland_answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_app_user",
                schema: "dbo",
                table: "app_user");

            migrationBuilder.RenameTable(
                name: "user_object",
                schema: "dbo",
                newName: "user_objects",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "user_information",
                schema: "dbo",
                newName: "user_informations",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "province",
                schema: "dbo",
                newName: "provinces",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "personality_assessment_question",
                schema: "dbo",
                newName: "personality_assessment_questions",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "personality_assessment_method",
                schema: "dbo",
                newName: "personality_assessment_methods",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "mbti_answer",
                schema: "dbo",
                newName: "mbti_answers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "holland_answer",
                schema: "dbo",
                newName: "holland_answers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "app_user",
                schema: "dbo",
                newName: "app_users",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_user_information_user_object_id",
                schema: "dbo",
                table: "user_informations",
                newName: "IX_user_informations_user_object_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_information_province_id",
                schema: "dbo",
                table: "user_informations",
                newName: "IX_user_informations_province_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_information_email",
                schema: "dbo",
                table: "user_informations",
                newName: "IX_user_informations_email");

            migrationBuilder.RenameIndex(
                name: "IX_personality_assessment_question_personality_assessment_method_id",
                schema: "dbo",
                table: "personality_assessment_questions",
                newName: "IX_personality_assessment_questions_personality_assessment_method_id");

            migrationBuilder.RenameIndex(
                name: "IX_mbti_answer_personality_assessment_question_id",
                schema: "dbo",
                table: "mbti_answers",
                newName: "IX_mbti_answers_personality_assessment_question_id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "dbo",
                table: "provinces",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "dbo",
                table: "provinces",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "administrative_region_id",
                schema: "dbo",
                table: "provinces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "administrative_unit_id",
                schema: "dbo",
                table: "provinces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "code_name",
                schema: "dbo",
                table: "provinces",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "full_name",
                schema: "dbo",
                table: "provinces",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "full_name_en",
                schema: "dbo",
                table: "provinces",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name_en",
                schema: "dbo",
                table: "provinces",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_objects",
                schema: "dbo",
                table: "user_objects",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_informations",
                schema: "dbo",
                table: "user_informations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_provinces",
                schema: "dbo",
                table: "provinces",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_personality_assessment_questions",
                schema: "dbo",
                table: "personality_assessment_questions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_personality_assessment_methods",
                schema: "dbo",
                table: "personality_assessment_methods",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mbti_answers",
                schema: "dbo",
                table: "mbti_answers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_holland_answers",
                schema: "dbo",
                table: "holland_answers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_app_users",
                schema: "dbo",
                table: "app_users",
                column: "id");

            migrationBuilder.CreateTable(
                name: "administrative_regions",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    code_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrative_regions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "administrative_units",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    full_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    short_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    short_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrative_units", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_provinces_administrative_region_id",
                schema: "dbo",
                table: "provinces",
                column: "administrative_region_id");

            migrationBuilder.CreateIndex(
                name: "IX_provinces_administrative_unit_id",
                schema: "dbo",
                table: "provinces",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_provinces_code",
                schema: "dbo",
                table: "provinces",
                column: "code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_mbti_answers_personality_assessment_questions_personality_assessment_question_id",
                schema: "dbo",
                table: "mbti_answers",
                column: "personality_assessment_question_id",
                principalSchema: "dbo",
                principalTable: "personality_assessment_questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personality_assessment_questions_personality_assessment_methods_personality_assessment_method_id",
                schema: "dbo",
                table: "personality_assessment_questions",
                column: "personality_assessment_method_id",
                principalSchema: "dbo",
                principalTable: "personality_assessment_methods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_provinces_administrative_regions_administrative_region_id",
                schema: "dbo",
                table: "provinces",
                column: "administrative_region_id",
                principalSchema: "dbo",
                principalTable: "administrative_regions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_provinces_administrative_units_administrative_unit_id",
                schema: "dbo",
                table: "provinces",
                column: "administrative_unit_id",
                principalSchema: "dbo",
                principalTable: "administrative_units",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_informations_provinces_province_id",
                schema: "dbo",
                table: "user_informations",
                column: "province_id",
                principalSchema: "dbo",
                principalTable: "provinces",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_informations_user_objects_user_object_id",
                schema: "dbo",
                table: "user_informations",
                column: "user_object_id",
                principalSchema: "dbo",
                principalTable: "user_objects",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mbti_answers_personality_assessment_questions_personality_assessment_question_id",
                schema: "dbo",
                table: "mbti_answers");

            migrationBuilder.DropForeignKey(
                name: "FK_personality_assessment_questions_personality_assessment_methods_personality_assessment_method_id",
                schema: "dbo",
                table: "personality_assessment_questions");

            migrationBuilder.DropForeignKey(
                name: "FK_provinces_administrative_regions_administrative_region_id",
                schema: "dbo",
                table: "provinces");

            migrationBuilder.DropForeignKey(
                name: "FK_provinces_administrative_units_administrative_unit_id",
                schema: "dbo",
                table: "provinces");

            migrationBuilder.DropForeignKey(
                name: "FK_user_informations_provinces_province_id",
                schema: "dbo",
                table: "user_informations");

            migrationBuilder.DropForeignKey(
                name: "FK_user_informations_user_objects_user_object_id",
                schema: "dbo",
                table: "user_informations");

            migrationBuilder.DropTable(
                name: "administrative_regions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "administrative_units",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_objects",
                schema: "dbo",
                table: "user_objects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_informations",
                schema: "dbo",
                table: "user_informations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_provinces",
                schema: "dbo",
                table: "provinces");

            migrationBuilder.DropIndex(
                name: "IX_provinces_administrative_region_id",
                schema: "dbo",
                table: "provinces");

            migrationBuilder.DropIndex(
                name: "IX_provinces_administrative_unit_id",
                schema: "dbo",
                table: "provinces");

            migrationBuilder.DropIndex(
                name: "IX_provinces_code",
                schema: "dbo",
                table: "provinces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_personality_assessment_questions",
                schema: "dbo",
                table: "personality_assessment_questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_personality_assessment_methods",
                schema: "dbo",
                table: "personality_assessment_methods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mbti_answers",
                schema: "dbo",
                table: "mbti_answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_holland_answers",
                schema: "dbo",
                table: "holland_answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_app_users",
                schema: "dbo",
                table: "app_users");

            migrationBuilder.DropColumn(
                name: "administrative_region_id",
                schema: "dbo",
                table: "provinces");

            migrationBuilder.DropColumn(
                name: "administrative_unit_id",
                schema: "dbo",
                table: "provinces");

            migrationBuilder.DropColumn(
                name: "code_name",
                schema: "dbo",
                table: "provinces");

            migrationBuilder.DropColumn(
                name: "full_name",
                schema: "dbo",
                table: "provinces");

            migrationBuilder.DropColumn(
                name: "full_name_en",
                schema: "dbo",
                table: "provinces");

            migrationBuilder.DropColumn(
                name: "name_en",
                schema: "dbo",
                table: "provinces");

            migrationBuilder.RenameTable(
                name: "user_objects",
                schema: "dbo",
                newName: "user_object",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "user_informations",
                schema: "dbo",
                newName: "user_information",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "provinces",
                schema: "dbo",
                newName: "province",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "personality_assessment_questions",
                schema: "dbo",
                newName: "personality_assessment_question",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "personality_assessment_methods",
                schema: "dbo",
                newName: "personality_assessment_method",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "mbti_answers",
                schema: "dbo",
                newName: "mbti_answer",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "holland_answers",
                schema: "dbo",
                newName: "holland_answer",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "app_users",
                schema: "dbo",
                newName: "app_user",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_user_informations_user_object_id",
                schema: "dbo",
                table: "user_information",
                newName: "IX_user_information_user_object_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_informations_province_id",
                schema: "dbo",
                table: "user_information",
                newName: "IX_user_information_province_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_informations_email",
                schema: "dbo",
                table: "user_information",
                newName: "IX_user_information_email");

            migrationBuilder.RenameIndex(
                name: "IX_personality_assessment_questions_personality_assessment_method_id",
                schema: "dbo",
                table: "personality_assessment_question",
                newName: "IX_personality_assessment_question_personality_assessment_method_id");

            migrationBuilder.RenameIndex(
                name: "IX_mbti_answers_personality_assessment_question_id",
                schema: "dbo",
                table: "mbti_answer",
                newName: "IX_mbti_answer_personality_assessment_question_id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "dbo",
                table: "province",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "dbo",
                table: "province",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_object",
                schema: "dbo",
                table: "user_object",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_information",
                schema: "dbo",
                table: "user_information",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_province",
                schema: "dbo",
                table: "province",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_personality_assessment_question",
                schema: "dbo",
                table: "personality_assessment_question",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_personality_assessment_method",
                schema: "dbo",
                table: "personality_assessment_method",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mbti_answer",
                schema: "dbo",
                table: "mbti_answer",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_holland_answer",
                schema: "dbo",
                table: "holland_answer",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_app_user",
                schema: "dbo",
                table: "app_user",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_mbti_answer_personality_assessment_question_personality_assessment_question_id",
                schema: "dbo",
                table: "mbti_answer",
                column: "personality_assessment_question_id",
                principalSchema: "dbo",
                principalTable: "personality_assessment_question",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personality_assessment_question_personality_assessment_method_personality_assessment_method_id",
                schema: "dbo",
                table: "personality_assessment_question",
                column: "personality_assessment_method_id",
                principalSchema: "dbo",
                principalTable: "personality_assessment_method",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_information_province_province_id",
                schema: "dbo",
                table: "user_information",
                column: "province_id",
                principalSchema: "dbo",
                principalTable: "province",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_information_user_object_user_object_id",
                schema: "dbo",
                table: "user_information",
                column: "user_object_id",
                principalSchema: "dbo",
                principalTable: "user_object",
                principalColumn: "id");
        }
    }
}

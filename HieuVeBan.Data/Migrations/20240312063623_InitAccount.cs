using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_informations",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "education_program_types",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_education_program_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dob = table.Column<DateTime>(type: "Date", nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    thpt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    province_id = table.Column<int>(type: "int", nullable: false),
                    user_object_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_provinces_province_id",
                        column: x => x.province_id,
                        principalSchema: "dbo",
                        principalTable: "provinces",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_users_user_objects_user_object_id",
                        column: x => x.user_object_id,
                        principalSchema: "dbo",
                        principalTable: "user_objects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "education_programs",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    education_program_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_education_programs", x => x.id);
                    table.ForeignKey(
                        name: "FK_education_programs_education_program_types_education_program_type_id",
                        column: x => x.education_program_type_id,
                        principalSchema: "dbo",
                        principalTable: "education_program_types",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    role_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_accounts_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "dbo",
                        principalTable: "roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_histories",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    symbol = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    personality_assessment_method_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_histories", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_histories_personality_assessment_methods_personality_assessment_method_id",
                        column: x => x.personality_assessment_method_id,
                        principalSchema: "dbo",
                        principalTable: "personality_assessment_methods",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_histories_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_mbti_personality_groups_symbol",
                schema: "dbo",
                table: "mbti_personality_groups",
                column: "symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_accounts_role_id",
                schema: "dbo",
                table: "accounts",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_education_programs_education_program_type_id",
                schema: "dbo",
                table: "education_programs",
                column: "education_program_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_histories_personality_assessment_method_id",
                schema: "dbo",
                table: "user_histories",
                column: "personality_assessment_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_histories_user_id",
                schema: "dbo",
                table: "user_histories",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                schema: "dbo",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_province_id",
                schema: "dbo",
                table: "users",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_object_id",
                schema: "dbo",
                table: "users",
                column: "user_object_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "education_programs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "user_histories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "education_program_types",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "users",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_mbti_personality_groups_symbol",
                schema: "dbo",
                table: "mbti_personality_groups");

            migrationBuilder.CreateTable(
                name: "user_informations",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    province_id = table.Column<int>(type: "int", nullable: false),
                    user_object_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dob = table.Column<DateTime>(type: "Date", nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    thpt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_informations", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_informations_provinces_province_id",
                        column: x => x.province_id,
                        principalSchema: "dbo",
                        principalTable: "provinces",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_informations_user_objects_user_object_id",
                        column: x => x.user_object_id,
                        principalSchema: "dbo",
                        principalTable: "user_objects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_informations_email",
                schema: "dbo",
                table: "user_informations",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_informations_province_id",
                schema: "dbo",
                table: "user_informations",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_informations_user_object_id",
                schema: "dbo",
                table: "user_informations",
                column: "user_object_id");
        }
    }
}

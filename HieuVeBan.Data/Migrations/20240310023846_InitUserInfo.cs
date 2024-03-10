using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "province",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_province", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_object",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_object", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_information",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dob = table.Column<DateTime>(type: "Date", nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    thpt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    province_id = table.Column<int>(type: "int", nullable: false),
                    user_object_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_information", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_information_province_province_id",
                        column: x => x.province_id,
                        principalSchema: "dbo",
                        principalTable: "province",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_information_user_object_user_object_id",
                        column: x => x.user_object_id,
                        principalSchema: "dbo",
                        principalTable: "user_object",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_information_province_id",
                schema: "dbo",
                table: "user_information",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_information_user_object_id",
                schema: "dbo",
                table: "user_information",
                column: "user_object_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_information",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "province",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "user_object",
                schema: "dbo");
        }
    }
}

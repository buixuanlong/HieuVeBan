using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "app_user",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    secret_key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    row_version = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_userid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_user", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_user",
                schema: "dbo");
        }
    }
}

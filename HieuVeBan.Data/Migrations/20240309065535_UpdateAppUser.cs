using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "secret_key",
                schema: "dbo",
                table: "app_user",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "password_hashed",
                schema: "dbo",
                table: "app_user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "type",
                schema: "dbo",
                table: "app_user",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                comment: "Type of UserType: 0 Unknown, 1 Internal, 2 External");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_hashed",
                schema: "dbo",
                table: "app_user");

            migrationBuilder.DropColumn(
                name: "type",
                schema: "dbo",
                table: "app_user");

            migrationBuilder.AlterColumn<string>(
                name: "secret_key",
                schema: "dbo",
                table: "app_user",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}

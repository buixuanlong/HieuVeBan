using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldMBTIFunctionalFactorDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "character",
                schema: "dbo",
                table: "mbti_functional_factor_name_details",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 255);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "character",
                schema: "dbo",
                table: "mbti_functional_factor_name_details",
                type: "tinyint",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);
        }
    }
}

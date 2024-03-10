using HieuVeBan.Data.Scripts;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HieuVeBan.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataProvince : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT administrative_regions ON;");
            migrationBuilder.Sql(ScriptToMigration.SeedDataAdministrativeRegion);
            migrationBuilder.Sql("SET IDENTITY_INSERT administrative_regions OFF;");
            migrationBuilder.Sql("SET IDENTITY_INSERT administrative_units ON;");
            migrationBuilder.Sql(ScriptToMigration.SeedDataAdministrativeUnit);
            migrationBuilder.Sql("SET IDENTITY_INSERT administrative_units OFF;");
            migrationBuilder.Sql("SET IDENTITY_INSERT provinces ON;");
            migrationBuilder.Sql(ScriptToMigration.SeedDataProvince);
            migrationBuilder.Sql("SET IDENTITY_INSERT provinces OFF;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

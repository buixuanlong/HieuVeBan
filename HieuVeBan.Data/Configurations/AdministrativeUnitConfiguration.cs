using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class AdministrativeUnitConfiguration : BaseEntityConfiguration<AdministrativeUnit, int>
    {
        public override string TableName => "administrative_units";

        public override void Configure(EntityTypeBuilder<AdministrativeUnit> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.FullName)
                .HasColumnName("full_name")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(x => x.FullNameEn)
                .HasColumnName("full_name_en")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(x => x.ShortName)
                .HasColumnName("short_name")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(x => x.ShortNameEn)
                .HasColumnName("short_name_en")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(x => x.CodeName)
                .HasColumnName("code_name")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(x => x.CodeNameEn)
                .HasColumnName("code_name_en")
                .HasMaxLength(255)
                .IsRequired(false);
        }
    }
}

using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class ProvinceConfiguration : BaseEntityConfiguration<Province, int>
    {
        public override string TableName => "provinces";

        public override void Configure(EntityTypeBuilder<Province> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Code)
                .HasColumnName("code")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.NameEn)
                .HasColumnName("name_en")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(x => x.FullName)
                .HasColumnName("full_name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.FullNameEn)
                .HasColumnName("full_name_en")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(x => x.CodeName)
                .HasColumnName("code_name")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(x => x.AdministrativeRegionId)
                .HasColumnName("administrative_region_id")
                .IsRequired();

            builder.HasOne(x => x.AdministrativeRegion)
                .WithMany()
                .HasForeignKey(x => x.AdministrativeRegionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.AdministrativeUnitId)
                .HasColumnName("administrative_unit_id")
                .IsRequired();

            builder.HasOne(x => x.AdministrativeUnit)
                .WithMany()
                .HasForeignKey(x => x.AdministrativeUnitId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.Code).IsUnique();
        }
    }
}

using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class AdministrativeRegionConfiguration : BaseEntityConfiguration<AdministrativeRegion, int>
    {
        public override string TableName => "administrative_regions";

        public override void Configure(EntityTypeBuilder<AdministrativeRegion> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.NameEn)
                .HasColumnName("name_en")
                .HasMaxLength(255)
                .IsRequired();

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

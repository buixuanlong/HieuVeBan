using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class MBTIFunctionalFactorNameDetailConfiguration : BaseEntityConfiguration<MBTIFunctionalFactorNameDetail, Guid>
    {
        public override string TableName => "mbti_functional_factor_name_details";

        public override void Configure(EntityTypeBuilder<MBTIFunctionalFactorNameDetail> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Character)
                .HasColumnName("character")
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(x => x.SortOrder)
                .HasColumnName("sort_order")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.ColorId)
                .HasColumnName("color_id")
                .IsRequired();

            builder.HasOne(x => x.Color)
                .WithMany()
                .HasForeignKey(x => x.ColorId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.MBTIFunctionalFactorId)
                .HasColumnName("mbti_functional_factor_id")
                .IsRequired();

            builder.HasOne(x => x.MBTIFunctionalFactor)
                .WithMany(x => x.MBTIFunctionalFactorNameDetails)
                .HasForeignKey(x => x.MBTIFunctionalFactorId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

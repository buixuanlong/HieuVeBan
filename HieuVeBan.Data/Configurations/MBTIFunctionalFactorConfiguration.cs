using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class MBTIFunctionalFactorConfiguration : BaseEntityConfiguration<MBTIFunctionalFactor, Guid>
    {
        public override string TableName => "mbti_functional_factors";

        public override void Configure(EntityTypeBuilder<MBTIFunctionalFactor> builder)
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

            builder.Property(x => x.Symbol)
                .HasColumnName("symbol")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.MBTIDichotomousPairId)
                .HasColumnName("mbti_dichotomous_pair_id")
                .IsRequired();

            builder.HasOne(x => x.MBTIDichotomousPair)
                .WithMany()
                .HasForeignKey(x => x.MBTIDichotomousPairId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.Symbol).IsUnique();
        }
    }
}

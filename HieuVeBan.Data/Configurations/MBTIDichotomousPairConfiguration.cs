using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class MBTIDichotomousPairConfiguration : BaseEntityConfiguration<MBTIDichotomousPair, Guid>
    {
        public override string TableName => "mbti_dichotomous_pairs";

        public override void Configure(EntityTypeBuilder<MBTIDichotomousPair> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}

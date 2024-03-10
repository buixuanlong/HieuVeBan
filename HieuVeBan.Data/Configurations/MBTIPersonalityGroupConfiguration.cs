using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class MBTIPersonalityGroupConfiguration : BaseEntityConfiguration<MBTIPersonalityGroup, Guid>
    {
        public override string TableName => "mbti_personality_groups";

        public override void Configure(EntityTypeBuilder<MBTIPersonalityGroup> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Symbol)
                .HasColumnName("symbol")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.HasIndex(x => x.Symbol).IsUnique();
        }
    }
}

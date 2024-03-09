using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class HollandAnswerConfiguration : BaseEntityConfiguration<HollandAnswer, Guid>
    {
        public override string TableName => "holland_answer";

        public override void Configure(EntityTypeBuilder<HollandAnswer> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.ShortName)
                .HasColumnName("short_name")
                .IsRequired(false);
        }
    }
}

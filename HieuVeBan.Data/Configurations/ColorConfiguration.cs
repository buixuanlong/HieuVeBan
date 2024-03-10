using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class ColorConfiguration : BaseEntityConfiguration<Color, Guid>
    {
        public override string TableName => "colors";

        public override void Configure(EntityTypeBuilder<Color> builder)
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

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(255)
                .IsRequired(false);
        }
    }
}

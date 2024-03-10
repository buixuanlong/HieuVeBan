using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class UserObjectConfiguration : BaseEntityConfiguration<UserObject, Guid>
    {
        public override string TableName => "user_objects";

        public override void Configure(EntityTypeBuilder<UserObject> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Code)
                .HasColumnName("code")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.SortOrder)
                .HasColumnName("sort_order")
                .IsRequired();
        }
    }
}

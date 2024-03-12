using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Data.Helpers;
using HieuVeBan.Models.Entities;
using HieuVeBan.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class AccountConfiguration : BaseEntityConfiguration<Account, Guid>
    {
        public override string TableName => "accounts";

        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Role)
                .HasColumnName("role")
                .HasComment(EnumHelpers.GetDescriptions<Role>())
                .IsRequired();
        }
    }
}

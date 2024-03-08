using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class AppUserConfiguration : BaseEntityConfiguration<AppUser, Guid>
    {
        public override string TableName => "app_user";

        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.UserName)
                .HasColumnName("user_name")
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.UserEmail)
                .HasColumnName("user_email")
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.SecretKey)
                .HasColumnName("secret_key")
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
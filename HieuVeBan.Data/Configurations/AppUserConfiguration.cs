using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Data.Helpers;
using HieuVeBan.Models.Entities;
using HieuVeBan.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class AppUserConfiguration : BaseEntityConfiguration<AppUser, Guid>
    {
        public override string TableName => "app_users";

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
                .HasMaxLength(250)
                .IsRequired(false);

            builder.Property(x => x.Type)
                .HasColumnName("type")
                .IsRequired()
                .HasComment(EnumHelpers.GetDescriptions<UserType>());

            builder.Property(x => x.PasswordHash)
                .HasColumnName("password_hashed")
                .HasColumnType("text")
                .IsRequired();

            builder.HasIndex(x => x.UserName, "u_idx_app_user_username")
                .IsUnique();
        }
    }
}
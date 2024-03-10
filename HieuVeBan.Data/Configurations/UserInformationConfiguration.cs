using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class UserInformationConfiguration : BaseEntityConfiguration<UserInformation, Guid>
    {
        public override string TableName => "user_informations";

        public override void Configure(EntityTypeBuilder<UserInformation> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Dob)
                .HasColumnName("dob")
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Phone)
                .HasColumnName("phone")
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.Thpt)
                .HasColumnName("thpt")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.ProvinceId)
                .HasColumnName("province_id")
                .IsRequired();

            builder.HasOne(x => x.Province)
                .WithMany()
                .HasForeignKey(x => x.ProvinceId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.UserObjectId)
                .HasColumnName("user_object_id")
                .IsRequired();

            builder.HasOne(x => x.UserObject)
                .WithMany()
                .HasForeignKey(x => x.UserObjectId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}

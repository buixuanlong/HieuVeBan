using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class MBTICelebrityConfiguration : BaseEntityConfiguration<MBTICelebrity, Guid>
    {
        public override string TableName => "mbti_celebrities";

        public override void Configure(EntityTypeBuilder<MBTICelebrity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(x => x.ImageLink)
                .HasColumnName("image_link")
                .IsRequired();

            builder.Property(x => x.PersonalityGroupId)
                .HasColumnName("personality_group_id")
                .IsRequired();

            builder.HasOne(x => x.PersonalityGroup)
                .WithMany()
                .HasForeignKey(x => x.PersonalityGroupId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

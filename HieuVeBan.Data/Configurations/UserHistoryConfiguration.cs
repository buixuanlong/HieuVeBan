using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class UserHistoryConfiguration : BaseEntityConfiguration<UserHistory, Guid>
    {
        public override string TableName => "user_histories";

        public override void Configure(EntityTypeBuilder<UserHistory> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Symbol)
                .HasColumnName("symbol")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.PersonalityAssessmentMethodId)
                .HasColumnName("personality_assessment_method_id")
                .IsRequired();

            builder.HasOne(x => x.PersonalityAssessmentMethod)
                .WithMany()
                .HasForeignKey(x => x.PersonalityAssessmentMethodId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

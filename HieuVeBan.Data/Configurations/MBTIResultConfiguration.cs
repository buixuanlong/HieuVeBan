using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class MBTIResultConfiguration : BaseEntityConfiguration<MBTIResult, Guid>
    {
        public override string TableName => "mbti_results";

        public override void Configure(EntityTypeBuilder<MBTIResult> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Mark)
                .HasColumnName("mark")
                .IsRequired();

            builder.Property(x => x.PersonalityAssessmentQuestionId)
                .HasColumnName("personality_assessment_question_id")
                .IsRequired();

            builder.HasOne(x => x.PersonalityAssessmentQuestion)
                .WithMany()
                .HasForeignKey(x => x.PersonalityAssessmentQuestionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.MBTIAnswerId)
                .HasColumnName("mbti_answer_id")
                .IsRequired();

            builder.HasOne(x => x.MBTIAnswer)
                .WithMany()
                .HasForeignKey(x => x.MBTIAnswerId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.MBTIFunctionalFactorId)
                .HasColumnName("mbti_functional_factor_id")
                .IsRequired();

            builder.HasOne(x => x.MBTIFunctionalFactor)
                .WithMany()
                .HasForeignKey(x => x.MBTIFunctionalFactorId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

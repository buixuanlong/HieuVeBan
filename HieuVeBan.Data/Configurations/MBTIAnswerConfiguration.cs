using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class MBTIAnswerConfiguration : BaseEntityConfiguration<MBTIAnswer, Guid>
    {
        public override string TableName => "mbti_answer";

        public override void Configure(EntityTypeBuilder<MBTIAnswer> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.PersonalityAssessmentQuestionId)
                .HasColumnName("personality_assessment_question_id")
                .IsRequired();

            builder.HasOne(x => x.PersonalityAssessmentQuestion)
                .WithMany()
                .HasForeignKey(x => x.PersonalityAssessmentQuestionId)
                .IsRequired();
        }
    }
}

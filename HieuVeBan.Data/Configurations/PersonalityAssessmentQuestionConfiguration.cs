using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class PersonalityAssessmentQuestionConfiguration : BaseEntityConfiguration<PersonalityAssessmentQuestion, Guid>
    {
        public override string TableName => "personality_assessment_questions";

        public override void Configure(EntityTypeBuilder<PersonalityAssessmentQuestion> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.QuestionNumber)
                .HasColumnName("question_number")
                .IsRequired();

            builder.Property(x => x.QuestionName)
                .HasColumnName("question_name")
                .IsRequired();

            builder.Property(x => x.PersonalityAssessmentMethodId)
                .HasColumnName("personality_assessment_method_id")
                .IsRequired();

            builder.HasOne(x => x.PersonalityAssessmentMethod)
                .WithMany(x => x.PersonalityAssessmentQuestions)
                .HasForeignKey(x => x.PersonalityAssessmentMethodId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

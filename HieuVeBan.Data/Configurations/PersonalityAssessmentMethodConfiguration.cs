using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class PersonalityAssessmentMethodConfiguration : BaseEntityConfiguration<PersonalityAssessmentMethod, Guid>
    {
        public override string TableName => "personality_assessment_method";

        public override void Configure(EntityTypeBuilder<PersonalityAssessmentMethod> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.Author)
                .HasColumnName("author")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(x => x.Note)
                .HasColumnName("note")
                .IsRequired();
        }
    }
}

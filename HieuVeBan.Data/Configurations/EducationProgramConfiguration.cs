using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class EducationProgramConfiguration : BaseEntityConfiguration<EducationProgram, Guid>
    {
        public override string TableName => "education_programs";

        public override void Configure(EntityTypeBuilder<EducationProgram> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.Link)
                .HasColumnName("link")
                .HasMaxLength(2048)
                .IsRequired(false);

            builder.Property(x => x.EducationProgramTypeId)
                .HasColumnName("education_program_type_id")
                .IsRequired();

            builder.HasOne(x => x.EducationProgramType)
                .WithMany()
                .HasForeignKey(x => x.EducationProgramTypeId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

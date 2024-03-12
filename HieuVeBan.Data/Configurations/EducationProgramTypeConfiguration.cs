using HieuVeBan.Abstraction.EFCore.Configuration;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HieuVeBan.Data.Configurations
{
    internal class EducationProgramTypeConfiguration : BaseEntityConfiguration<EducationProgramType, Guid>
    {
        public override string TableName => "education_program_types";

        public override void Configure(EntityTypeBuilder<EducationProgramType> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.Link)
                .HasColumnName("link")
                .IsRequired(false);

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired(false);
        }
    }
}

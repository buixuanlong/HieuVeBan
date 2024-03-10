using HieuVeBan.Abstraction.EFCore;
using HieuVeBan.Abstraction.Interfaces;
using HieuVeBan.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HieuVeBan.Data
{
    public partial class ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IUserContext userContext) : BaseDbContext(options, userContext)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<PersonalityAssessmentMethod> PersonalityAssessmentMethods { get; set; }
        public DbSet<PersonalityAssessmentQuestion> PersonalityAssessmentQuestions { get; set; }
        public DbSet<HollandAnswer> HollandAnswers { get; set; }
        public DbSet<MBTIAnswer> MBTIAnswers { get; set; }
        public DbSet<UserObject> UserObjects { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<AdministrativeRegion> AdministrativeRegions { get; set; }
        public DbSet<AdministrativeUnit> AdministrativeUnits { get; set; }
    }
}

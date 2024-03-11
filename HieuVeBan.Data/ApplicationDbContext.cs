using HieuVeBan.Abstraction.EFCore;
using HieuVeBan.Abstraction.Interfaces;
using HieuVeBan.Models.Entities;
using HieuVeBan.Models.Entities.OldEntities;
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
        public DbSet<MBTIFunctionalFactor> MBTIFunctionalFactors { get; set; }
        public DbSet<MBTIDichotomousPair> MBTIDichotomousPairs { get; set; }
        public DbSet<MBTIPersonalityGroup> MBTIPersonalityGroups { get; set; }
        public DbSet<MBTIResult> MBTIResults { get; set; }
        public DbSet<MBTICelebrity> MBTICelebrities { get; set; }

        //TODO: Remove
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
        public DbSet<Information> Information { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer_MBTI> Answer_MBTI { get; set; }
        public DbSet<Result_MBTI> Result_MBTI { get; set; }
        public DbSet<FinalResultHOLLAND> FinalResultHOLLAND { get; set; }
        public DbSet<FinalResultMBTI> FinalResultMBTI { get; set; }
        public DbSet<FunctionalFactors_MBTI> FunctionalFactors_MBTI { get; set; }
        public DbSet<DichotomousPair_MBTI> DichotomousPair_MBTI { get; set; }
        public DbSet<HobbyGroup_HOLLAND> HobbyGroup_HOLLAND { get; set; }
        public DbSet<HobbyGroup_HOLLAND_Question> HobbyGroup_HOLLAND_Question { get; set; }
        public DbSet<PersonalityGroup_MBTI> PersonalityGroup_MBTI { get; set; }
        public DbSet<SurveyMethod> SurveyMethod { get; set; }
        public DbSet<Images_HOLLAND> Images_HOLLAND { get; set; }
        public DbSet<Images_MBTI> Images_MBTI { get; set; }
    }
}

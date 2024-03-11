using HieuVeBan.Models.Entities.OldEntities;

namespace HieuVeBan.Contracts.Services
{
    public interface IAdminService
    {
        TaiKhoan LoginAdmin(string email);
        Task<int> UpdateAccount(TaiKhoan userAccount);
        Task<int> AddAccount(TaiKhoan userAccount);
        Task<int> DeleteAccount(TaiKhoan userAccount);
        TaiKhoan GetAccountByEmail(string email);
        TaiKhoan GetAccount(int uid);
        (List<TaiKhoan>, int) GetAccountsPagination(string search, int limit, int offset, string sortColumn, string sortColumnDir);
        (List<Information>, int) GetInfosPagination(string search, int limit, int offset, string sortColumn, string sortColumnDir, string fromDt, string toDt);
        Task<List<Information>> ExportExcelInfos(string fromDt, string toDt);
        List<Question> GetQuestions(int method);
        void AddInfo(Information information);
        List<Answer_MBTI> GetAnswersMBTI();
        List<Result_MBTI> GetResultMBTI();
        List<HobbyGroup_HOLLAND_Question> GetHobbyGroupHollandQuestions();
        PersonalityGroup_MBTI GetPersonalityGroup_MBTIs(string symbol);
        List<FinalResultMBTI> GetFinalResultMBTIs(int personanlityGroupId);
        List<Images_MBTI> GetImagesMBTI(int personanlityGroupId);
        HobbyGroup_HOLLAND GetHobbyGroupHOLLAND(string symbol);
        List<FinalResultHOLLAND> GetFinalResultHOLLAND();
        List<Images_HOLLAND> GetImagesHOLLAND(int hobbyGroupHOLLANDId);
    }
}

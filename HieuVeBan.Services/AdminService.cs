using AutoMapper;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Data;
using HieuVeBan.Models.Entities.OldEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HieuVeBan.Services
{
    //TODO: Refactor
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AdminService> _logger;
        private readonly IMapper _mapper;

        public AdminService(
            ApplicationDbContext applicationDbContext,
            ILogger<AdminService> logger,
            IMapper mapper)
        {
            _context = applicationDbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public TaiKhoan GetAccount(int uid)
        {
            try
            {
                return _context.TaiKhoan.SingleOrDefault(u => u.Uid.Equals(uid));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public TaiKhoan GetAccountByEmail(string email)
        {
            try
            {
                return _context.TaiKhoan.SingleOrDefault(u => u.Email.Equals(email));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public (List<TaiKhoan>, int) GetAccountsPagination(string search, int limit, int offset, string sortColumn, string sortColumnDir)
        {
            try
            {
                var query = _context.TaiKhoan.AsQueryable();

                if (!string.IsNullOrEmpty(search))
                {
                    string searchLower = search.ToLower();
                    query = query.Where(a => a.HoTen.ToLower().Contains(searchLower)
                                            || a.Email.ToLower().Contains(searchLower)
                                            || a.MaQuanLy.ToLower().Contains(searchLower));
                }

                if (sortColumnDir.ToLower() == "desc")
                    query = query.OrderByDescending(sortColumn);
                else
                    query = query.OrderBy(sortColumn);

                int totalCount = query.Count();
                if (limit != -1)
                    query = query.Skip(offset).Take(limit);

                return (query.ToList(), totalCount);
            }
            catch (Exception e)
            {
                return (new List<TaiKhoan>(), 0);
            }
        }

        public (List<Information>, int) GetInfosPagination(string search, int limit, int offset, string sortColumn, string sortColumnDir, string fromDt, string toDt)
        {
            try
            {
                var query = _context.Information
                    .Where(p => p.Created_At >= DateTime.ParseExact(fromDt, "dd/MM/yyyy", null)
                    && p.Created_At <= DateTime.ParseExact(toDt, "dd/MM/yyyy", null)).AsQueryable();

                if (!string.IsNullOrEmpty(search))
                {
                    string searchLower = search.ToLower();
                    query = query.Where(p => p.Email.ToLower().Contains(searchLower)
                                          || p.Name.ToLower().Contains(searchLower)
                                          || p.PhoneNumber!.ToLower().Contains(searchLower));
                }

                if (string.IsNullOrEmpty(sortColumn) || string.IsNullOrEmpty(sortColumnDir))
                {
                    query = query.OrderByDescending(p => p.Created_At);
                }
                else
                {
                    if (sortColumnDir.ToLower() == "desc")
                        query = query.OrderByDescending(x => x.Id);
                    else
                        query = query.OrderBy(x => x.Id);
                }

                int totalCount = query.Count();
                if (limit != -1)
                    query = query.Skip(offset).Take(limit);

                return (query.ToList(), totalCount);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return (new List<Information>(), 0);
            }
        }
        public async Task<List<Information>> ExportExcelInfos(string fromDt, string toDt)
        {
            try
            {
                return await _context.Information.Where(p => p.Created_At >= DateTime.ParseExact(fromDt, "dd/MM/yyyy", null) && p.Created_At <= DateTime.ParseExact(toDt, "dd/MM/yyyy", null)).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null;
            }
        }

        public List<Question> GetQuestions(int method)
        {
            try
            {
                return _context.Question.Where(p => p.SurveyMethod_Id == method).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void AddInfo(Information information)
        {
            try
            {
                _context.Information.Add(information);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }

        public List<Answer_MBTI> GetAnswersMBTI()
        {
            try
            {
                return _context.Answer_MBTI.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Result_MBTI> GetResultMBTI()
        {
            try
            {
                return _context.Result_MBTI.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public List<HobbyGroup_HOLLAND_Question> GetHobbyGroupHollandQuestions()
        {
            try
            {
                return _context.HobbyGroup_HOLLAND_Question.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public PersonalityGroup_MBTI GetPersonalityGroup_MBTIs(string symbol)
        {
            try
            {
                return _context.PersonalityGroup_MBTI.FirstOrDefault(x => x.Symbol == symbol);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<FinalResultMBTI> GetFinalResultMBTIs(int personanlityGroupId)
        {
            try
            {
                return _context.FinalResultMBTI.Where(x => x.PersonalityGroup_MBTI_Id == personanlityGroupId).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Images_MBTI> GetImagesMBTI(int personanlityGroupId)
        {
            try
            {
                return _context.Images_MBTI.Where(x => x.PersonalityGroup_MBTI_Id == personanlityGroupId).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public HobbyGroup_HOLLAND GetHobbyGroupHOLLAND(string symbol)
        {
            try
            {
                return _context.HobbyGroup_HOLLAND.FirstOrDefault(x => x.Symbol == symbol);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<Images_HOLLAND> GetImagesHOLLAND(int hobbyGroupHOLLANDId)
        {
            try
            {
                return _context.Images_HOLLAND.Where(p => p.HobbyGroup_HOLLAND_Id == hobbyGroupHOLLANDId).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<FinalResultHOLLAND> GetFinalResultHOLLAND()
        {
            try
            {
                return _context.FinalResultHOLLAND.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public TaiKhoan LoginAdmin(string email)
        {
            try
            {
                return _context.TaiKhoan.SingleOrDefault(p => p.Email.Equals(email.ToLower()) && p.Role.Equals("admin"));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public (List<TaiKhoan>, int) GetUserAccountsPagination(string search, int limit, int offset, string sortColumn, string sortColumnDir)
        {
            try
            {
                IQueryable<TaiKhoan> model;
                if (!string.IsNullOrEmpty(search))
                {
                    model = _context.TaiKhoan.Where(a => a.HoTen.ToLower().Contains(search.ToLower())
                    || a.Email.ToLower().Contains(search.ToLower())
                    || a.MaQuanLy.ToLower().Contains(search.ToLower())
                    ).AsQueryable();
                    if (limit == -1)
                    {
                        return (model.OrderBy(sortColumn + " " + sortColumnDir).Skip(offset).ToList(), model.Count());
                    }
                    else
                    {
                        return (model.OrderBy(sortColumn + " " + sortColumnDir).Skip(offset).Take(limit).ToList(), model.Count());
                    }
                }
                else
                {
                    model = _context.TaiKhoan.AsQueryable();
                    if (limit == -1)
                    {
                        return (model.OrderBy(sortColumn + " " + sortColumnDir).Skip(offset).ToList(), model.Count());
                    }
                    else
                    {
                        return (model.OrderBy(sortColumn + " " + sortColumnDir).Skip(offset).Take(limit).ToList(), model.Count());
                    }
                }
            }
            catch (Exception e)
            {
                return (new List<TaiKhoan>(), 0);
            }
        }

        public async Task<int> UpdateAccount(TaiKhoan userAccount)
        {
            try
            {
                _context.TaiKhoan.Update(userAccount);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<int> AddAccount(TaiKhoan userAccount)
        {
            try
            {
                _context.TaiKhoan.Add(userAccount);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<int> DeleteAccount(TaiKhoan userAccount)
        {
            try
            {
                _context.TaiKhoan.Remove(userAccount);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
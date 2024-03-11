using HieuVeBan.Contracts.Services;
using HieuVeBan.Models.Entities.OldEntities;
using HieuVeBan.Models.OldModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HieuVeBan.Controllers
{
    //TODO: Refactor
    public class MethodController : Controller
    {
        private readonly IAdminService _adminService;

        public MethodController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Route("phuong-phap-dinh-huong-nghe-nghiep/holland")]
        public IActionResult Holland(int page = 1)
        {
            List<Question> questions = _adminService.GetQuestions(1);
            const int pageSize = 10;
            if (page < 1)
            {
                page = 1;
            }
            if (Request.Cookies["answers_holland"] != null)
            {
                JObject answers = JObject.Parse(Request.Cookies["answers_holland"]);
                if (answers.Count < 10)
                {
                    page = 1;
                }
                else if (answers.Count < 20)
                {
                    page = 2;
                }
                else if (answers.Count < 30)
                {
                    page = 3;
                }
                else if (answers.Count < 40)
                {
                    page = 4;
                }
                else if (answers.Count < 50)
                {
                    page = 5;
                }
                else
                {
                    page = 6;
                }
            }
            else
            {
                page = 1;
            }
            int count = questions.Count();
            var pager = new Pager(count, page, pageSize);
            int skip = (page - 1) * pageSize;
            var data = questions.Skip(skip).Take(pager.PageSize).ToList();
            ViewBag.Pager = pager;
            return View(data);
        }

        [Route("phuong-phap-dinh-huong-nghe-nghiep/mbti")]
        public IActionResult Mbti(int page = 1)
        {
            List<Question> questions = _adminService.GetQuestions(2);
            const int pageSize = 10;
            if (page < 1)
            {
                page = 1;
            }
            if (Request.Cookies["answers_mbti"] != null)
            {
                JObject answers = JObject.Parse(Request.Cookies["answers_mbti"]);
                if (answers.Count < 10)
                {
                    page = 1;
                }
                else if (answers.Count < 20)
                {
                    page = 2;
                }
                else if (answers.Count < 30)
                {
                    page = 3;
                }
                else if (answers.Count < 40)
                {
                    page = 4;
                }
                else
                {
                    page = 5;
                }
            }
            else
            {
                page = 1;
            }
            int count = questions.Count();
            var pager = new Pager(count, page, pageSize);
            int skip = (page - 1) * pageSize;
            var data = questions.Skip(skip).Take(pager.PageSize).ToList();
            ViewBag.Pager = pager;
            ViewBag.MBTI = _adminService.GetAnswersMBTI();
            return View(data);
        }

        [HttpPost]
        public JsonResult Result(string data, int type)
        {
            JObject answers = JObject.Parse(data);
            string result = "";
            if (type == 2)
            {
                int E = 0, I = 0, S = 0, N = 0, T = 0, F = 0, J = 0, P = 0;
                List<Result_MBTI> result_MBTIs = _adminService.GetResultMBTI();
                foreach (var answer in answers)
                {
                    Result_MBTI result_MBTI = result_MBTIs.Where(p => p.Question_Id == int.Parse(answer.Key)).Where(p => p.Answer_MBTI_Id == (int)answer.Value).FirstOrDefault();
                    if (result_MBTI.FunctionalFactors_MBTI_Id == 1)
                    {
                        E += result_MBTI.Mark;
                    }
                    else if (result_MBTI.FunctionalFactors_MBTI_Id == 2)
                    {
                        I += result_MBTI.Mark;
                    }
                    else if (result_MBTI.FunctionalFactors_MBTI_Id == 3)
                    {
                        S += result_MBTI.Mark;
                    }
                    else if (result_MBTI.FunctionalFactors_MBTI_Id == 4)
                    {
                        N += result_MBTI.Mark;
                    }
                    else if (result_MBTI.FunctionalFactors_MBTI_Id == 5)
                    {
                        T += result_MBTI.Mark;
                    }
                    else if (result_MBTI.FunctionalFactors_MBTI_Id == 6)
                    {
                        F += result_MBTI.Mark;
                    }
                    else if (result_MBTI.FunctionalFactors_MBTI_Id == 7)
                    {
                        J += result_MBTI.Mark;
                    }
                    else
                    {
                        P += result_MBTI.Mark;
                    }
                }
                if (E > I)
                {
                    result += "E";
                }
                else
                {
                    result += "I";
                }
                if (S > N)
                {
                    result += "S";
                }
                else
                {
                    result += "N";
                }
                if (T > F)
                {
                    result += "T";
                }
                else
                {
                    result += "F";
                }
                if (J > P)
                {
                    result += "J";
                }
                else
                {
                    result += "P";
                }
                return Json(new { result = result });
            }
            else
            {
                int R = 0, I = 0, A = 0, S = 0, E = 0, C = 0;

                List<Result_Holland> result_Hollands = new List<Result_Holland>();
                List<HobbyGroup_HOLLAND_Question> hobbyGroup_HOLLAND_Questions = _adminService.GetHobbyGroupHollandQuestions();
                foreach (var answer in answers)
                {
                    HobbyGroup_HOLLAND_Question result_Holland = hobbyGroup_HOLLAND_Questions.Where(p => p.Question_Id == int.Parse(answer.Key)).FirstOrDefault();
                    if (result_Holland.HobbyGroup_HOLLAND_Id == 1)
                    {
                        if ((int)answer.Value == 2)
                        {
                            R += 1;
                        }
                        else if ((int)answer.Value == 3)
                        {
                            R += 2;
                        }
                        else if ((int)answer.Value == 4)
                        {
                            R += 3;
                        }
                        else if ((int)answer.Value == 5)
                        {
                            R += 4;
                        }
                    }
                    else if (result_Holland.HobbyGroup_HOLLAND_Id == 2)
                    {
                        if ((int)answer.Value == 2)
                        {
                            I += 1;
                        }
                        else if ((int)answer.Value == 3)
                        {
                            I += 2;
                        }
                        else if ((int)answer.Value == 4)
                        {
                            I += 3;
                        }
                        else if ((int)answer.Value == 5)
                        {
                            I += 4;
                        }
                    }
                    else if (result_Holland.HobbyGroup_HOLLAND_Id == 3)
                    {
                        if ((int)answer.Value == 2)
                        {
                            A += 1;
                        }
                        else if ((int)answer.Value == 3)
                        {
                            A += 2;
                        }
                        else if ((int)answer.Value == 4)
                        {
                            A += 3;
                        }
                        else if ((int)answer.Value == 5)
                        {
                            A += 4;
                        }
                    }
                    else if (result_Holland.HobbyGroup_HOLLAND_Id == 4)
                    {
                        if ((int)answer.Value == 2)
                        {
                            S += 1;
                        }
                        else if ((int)answer.Value == 3)
                        {
                            S += 2;
                        }
                        else if ((int)answer.Value == 4)
                        {
                            S += 3;
                        }
                        else if ((int)answer.Value == 5)
                        {
                            S += 4;
                        }
                    }
                    else if (result_Holland.HobbyGroup_HOLLAND_Id == 5)
                    {
                        if ((int)answer.Value == 2)
                        {
                            E += 1;
                        }
                        else if ((int)answer.Value == 3)
                        {
                            E += 2;
                        }
                        else if ((int)answer.Value == 4)
                        {
                            E += 3;
                        }
                        else if ((int)answer.Value == 5)
                        {
                            E += 4;
                        }
                    }
                    else if (result_Holland.HobbyGroup_HOLLAND_Id == 6)
                    {
                        if ((int)answer.Value == 2)
                        {
                            C += 1;
                        }
                        else if ((int)answer.Value == 3)
                        {
                            C += 2;
                        }
                        else if ((int)answer.Value == 4)
                        {
                            C += 3;
                        }
                        else if ((int)answer.Value == 5)
                        {
                            C += 4;
                        }
                    }
                }
                result_Hollands.Add(new Result_Holland("R", R));
                result_Hollands.Add(new Result_Holland("I", I));
                result_Hollands.Add(new Result_Holland("A", A));
                result_Hollands.Add(new Result_Holland("S", S));
                result_Hollands.Add(new Result_Holland("E", E));
                result_Hollands.Add(new Result_Holland("C", C));
                var lstResultHolland = result_Hollands.OrderByDescending(p => p.Total).GroupBy(p => p.Total).Take(1).ToList();
                foreach (var rs in lstResultHolland)
                {
                    foreach (var hollandItem in rs)
                    {
                        result += hollandItem.JobType;
                    }
                }
                return Json(new { result = result });
            }
        }

        [Route("/cap-nhat-thong-tin/")]
        public IActionResult Information()
        {
            return View();
        }

        [Route("/ket-qua-mbti/")]
        public IActionResult ResultMBTI()
        {
            if (Request.Cookies["result_mbti"] != null)
            {
                var personality = _adminService.GetPersonalityGroup_MBTIs(Request.Cookies["result_mbti"]);
                ViewBag.personality = personality;
                ViewBag.finalResultMBTIs = _adminService.GetFinalResultMBTIs(personality.Id);
                ViewBag.images_MBTIs = _adminService.GetImagesMBTI(personality.Id);
            }
            return View();
        }

        [Route("/ket-qua-holland/")]
        public IActionResult ResultHolland()
        {
            if (Request.Cookies["result_holland"] != null)
            {
                string result_holland = Request.Cookies["result_holland"];
                List<HobbyGroup_HOLLAND> hobbyGroup_HOLLANDs = new List<HobbyGroup_HOLLAND>();
                for (int i = 0; i < result_holland.Length; i++)
                {
                    HobbyGroup_HOLLAND hobbyGroup_HOLLAND = _adminService.GetHobbyGroupHOLLAND(result_holland[i].ToString());
                    hobbyGroup_HOLLANDs.Add(hobbyGroup_HOLLAND);
                }
                ViewBag.hobbyGroup_HOLLANDs = hobbyGroup_HOLLANDs;
                List<FinalResultHOLLAND> finalResultHOLLANDs = new List<FinalResultHOLLAND>();
                List<FinalResultHOLLAND> finalResultHOLLANDs_1 = _adminService.GetFinalResultHOLLAND();
                List<Images_HOLLAND> images_HOLLANDs = new List<Images_HOLLAND>();
                foreach (var item in result_holland.ToCharArray())
                {
                    images_HOLLANDs.AddRange(_adminService.GetImagesHOLLAND(_adminService.GetHobbyGroupHOLLAND(item.ToString()).Id));
                }
                foreach (var hobbyGroup_HOLLAND in hobbyGroup_HOLLANDs)
                {
                    foreach (var finalResultHOLLAND in finalResultHOLLANDs_1)
                    {
                        if (finalResultHOLLAND.HobbyGroup_HOLLAND_Id == hobbyGroup_HOLLAND.Id)
                        {
                            finalResultHOLLANDs.Add(finalResultHOLLAND);
                        }
                    }
                }
                ViewBag.Symbol = _adminService.GetHobbyGroupHOLLAND(result_holland[0].ToString()).Symbol;
                ViewBag.images_HOLLANDs = images_HOLLANDs;
                ViewBag.finalResultHOLLANDs = finalResultHOLLANDs;

            }
            return View();
        }

        public JsonResult SaveInformation(string hoten, string ngaysinh, string email, string sdt, string thpt, string tinh, string type)
        {
            if (hoten != null && ngaysinh != null && email != null && thpt != null && tinh != null && type != null)
            {
                Information info = new Information();
                info.Name = hoten;
                info.BirthDay = ngaysinh;
                info.Email = email;
                info.PhoneNumber = sdt;
                info.Thpt = thpt;
                info.City = tinh;
                info.Type = type;
                info.Created_At = DateTime.Now;
                _adminService.AddInfo(info);
            }
            return Json(new { result = true });
        }

    }
}

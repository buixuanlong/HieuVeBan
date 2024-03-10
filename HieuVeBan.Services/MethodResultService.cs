using AutoMapper;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Data;
using HieuVeBan.Models.Commands;
using HieuVeBan.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace HieuVeBan.Services
{
    public class MethodResultService : IMethodResultService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMethodService _methodService;
        private readonly IMapper _mapper;

        public MethodResultService(
            ApplicationDbContext applicationDbContext,
            IMethodService methodService,
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _methodService = methodService;
            _mapper = mapper;
        }

        private async Task<string> CalculateResult(SurveyResultModel model)
        {
            var method = await _methodService.GetMethodAsync(model.MethodId);

            if (method is null) return string.Empty;

            var result = "";

            switch (method.Type)
            {
                case MethodType.MBTI:
                    var mbtiResults = await _applicationDbContext.MBTIResults.ToListAsync();

                    Dictionary<string, int> scoringResults = new Dictionary<string, int>();

                    var mbtiSymbols = await _applicationDbContext.MBTIFunctionalFactors.Select(x => x.Symbol).ToListAsync();

                    foreach (string symbol in mbtiSymbols)
                    {
                        scoringResults[symbol] = 0;
                    }

                    foreach (var item in model.Results)
                    {
                        var mbtiResult = mbtiResults.Where(x => x.MBTIAnswerId == item.AnswerId
                            && x.PersonalityAssessmentQuestionId == item.QuestionId).FirstOrDefault();

                        if (mbtiResult == null) return null;

                        if (scoringResults.ContainsKey(mbtiResult.MBTIFunctionalFactor.Symbol))
                        {
                            scoringResults[mbtiResult.MBTIFunctionalFactor.Symbol] += mbtiResult.Mark;
                        }
                    }

                    if (scoringResults["E"] > scoringResults["I"])
                        result += "E";
                    else
                        result += "I";

                    if (scoringResults["S"] > scoringResults["N"])
                        result += "S";
                    else
                        result += "N";

                    if (scoringResults["T"] > scoringResults["F"])
                        result += "T";
                    else
                        result += "F";

                    if (scoringResults["J"] > scoringResults["P"])
                        result += "J";
                    else
                        result += "P";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}

using HieuVeBan.Models.Commands.QueryParams;
using HieuVeBan.Models.DTOs;

namespace HieuVeBan.Contracts.Services
{
    public interface IQuestionService
    {
        Task<PagedList<MBTIQuestionModel>> GetMBTIQuestionsAsync(QuestionQueryParams queryParams, CancellationToken cancellationToken = default);
        Task<PagedList<QuestionModel>> GetHollandQuestionsAsync(QuestionQueryParams queryParams, CancellationToken cancellationToken = default);
        Task<IEnumerable<HollandAnswerModel>> GetHollandAnswersAsync(CancellationToken cancellationToken = default);
    }
}

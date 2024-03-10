using Asp.Versioning;
using HieuVeBan.Abstraction.Security;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Models.Commands.QueryParams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HieuVeBan.Controllers
{
    [Authorize(Policy = SecurityConstant.Policies.ExternalPolicy)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/questions")]
    public class QuestionsController : Controller
    {
        private readonly IQuestionService _personalityAssessmentQuestionService;

        public QuestionsController(IQuestionService personalityAssessmentQuestionService)
        {
            _personalityAssessmentQuestionService = personalityAssessmentQuestionService;
        }

        [HttpGet("mbti")]
        public async Task<IActionResult> GetMBTIQuestions([FromQuery] QuestionQueryParams query, CancellationToken cancellationToken)
        {
            var res = await _personalityAssessmentQuestionService.GetMBTIQuestionsAsync(query, cancellationToken);
            return Ok(res);
        }

        [HttpGet("holland")]
        public async Task<IActionResult> GetHollandQuestions([FromQuery] QuestionQueryParams query, CancellationToken cancellationToken)
        {
            var res = await _personalityAssessmentQuestionService.GetHollandQuestionsAsync(query, cancellationToken);
            return Ok(res);
        }

        [HttpGet("holland/answers")]
        public async Task<IActionResult> GetHollandAnswers(CancellationToken cancellationToken)
        {
            var res = await _personalityAssessmentQuestionService.GetHollandAnswersAsync(cancellationToken);
            return Ok(res);
        }
    }
}

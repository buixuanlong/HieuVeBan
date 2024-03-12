using AutoMapper;
using AutoMapper.QueryableExtensions;
using HieuVeBan.Abstraction.Exceptions;
using HieuVeBan.Contracts.Services;
using HieuVeBan.Data;
using HieuVeBan.Models.Commands.QueryParams;
using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.Entities;
using HieuVeBan.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace HieuVeBan.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public QuestionService(
            ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<PagedList<MBTIQuestionModel>> GetMBTIQuestionsAsync(QuestionQueryParams queryParams, CancellationToken cancellationToken = default)
        {
            var method = await _applicationDbContext.PersonalityAssessmentMethods
                .Where(x => x.Type == MethodType.MBTI).FirstOrDefaultAsync()
                ?? throw new NotFoundException(nameof(PersonalityAssessmentMethod));

            var query = _applicationDbContext.PersonalityAssessmentQuestions
                .Where(x => x.PersonalityAssessmentMethodId == method.Id)
                .AsQueryable();

            query = query.OrderBy(x => x.QuestionNumber);

            var res = await query.ToPagedListAsync<PersonalityAssessmentQuestion, MBTIQuestionModel>(queryParams, _mapper.ConfigurationProvider, cancellationToken);

            foreach (var item in res.Data)
            {
                item.Answers = await _applicationDbContext.MBTIAnswers
                    .Where(x => x.PersonalityAssessmentQuestionId == item.Id)
                    .ProjectTo<MBTIAnswerModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }

            return res;
        }

        public async Task<PagedList<QuestionModel>> GetHollandQuestionsAsync(QuestionQueryParams queryParams, CancellationToken cancellationToken = default)
        {
            var method = await _applicationDbContext.PersonalityAssessmentMethods
                .Where(x => x.Type == MethodType.Holland).FirstOrDefaultAsync()
                ?? throw new NotFoundException(nameof(PersonalityAssessmentMethod));

            var query = _applicationDbContext.PersonalityAssessmentQuestions
                .Where(x => x.PersonalityAssessmentMethodId == method.Id)
                .AsQueryable();

            query = query.OrderBy(x => x.QuestionNumber);

            return await query.ToPagedListAsync<PersonalityAssessmentQuestion, QuestionModel>(queryParams, _mapper.ConfigurationProvider, cancellationToken);
        }

        public async Task<IEnumerable<HollandAnswerModel>> GetHollandAnswersAsync(CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.HollandAnswers
                    .OrderBy(x => x.Mark)
                    .ProjectTo<HollandAnswerModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
        }
    }
}

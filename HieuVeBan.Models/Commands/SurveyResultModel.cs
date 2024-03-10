namespace HieuVeBan.Models.Commands
{
    public class SurveyResultModel
    {
        public Guid MethodId { get; set; }
        public IEnumerable<SurveyResultDetailModel> Results { get; set; } = Enumerable.Empty<SurveyResultDetailModel>();
    }

    public class SurveyResultDetailModel
    {
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }
    }
}

namespace HieuVeBan.Models.DTOs
{
    public class MBTIQuestionModel : QuestionModel
    {
        public IEnumerable<MBTIAnswerModel> Answers { get; set; } = new List<MBTIAnswerModel>();
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("Question")]
    public partial class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int SurveyMethod_Id { get; set; }
    }
}

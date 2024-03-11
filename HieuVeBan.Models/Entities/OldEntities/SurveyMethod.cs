using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("SurveyMethod")]
    public partial class SurveyMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
    }
}

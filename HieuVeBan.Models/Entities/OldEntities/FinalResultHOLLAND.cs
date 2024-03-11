using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("FinalResultHOLLAND")]
    public class FinalResultHOLLAND
    {
        public int Id { get; set; }
        public int HobbyGroup_HOLLAND_Id { get; set; }
        public string SuitableOccupationalGroup { get; set; }
        public string EducationProgram_VN { get; set; }
        public string EducationProgram_UEH { get; set; }
        public string EducationProgram_VB2DHCQ { get; set; }
        public string EducationProgram_LTCDDHCQ { get; set; }
        public string EducationProgram_VB1VLVH { get; set; }
        public string EducationProgram_VB2VLVH { get; set; }
        public string EducationProgram_LTCDVLVH { get; set; }
        public string EducationProgram_LTTCVLVH { get; set; }
        public string EducationProgram_ThacSi { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("Images_HOLLAND")]
    public class Images_HOLLAND
    {
        public int Id { get; set; }
        public int HobbyGroup_HOLLAND_Id { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string ImageInfo { get; set; }
    }
}

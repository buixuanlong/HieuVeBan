using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("HobbyGroup_HOLLAND")]
    public partial class HobbyGroup_HOLLAND
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

        public string Description { get; set; }
        public string DisplayText { get; set; }
    }
}

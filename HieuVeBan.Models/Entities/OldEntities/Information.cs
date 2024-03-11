using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("Information")]
    public partial class Information
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthDay { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Thpt { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
        public DateTime Created_At { get; set; }
    }
}


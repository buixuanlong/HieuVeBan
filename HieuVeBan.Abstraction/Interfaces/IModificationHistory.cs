namespace HieuVeBan.Abstraction.Interfaces
{
    public interface IModificationHistory
    {
        public DateTime? UpdatedDateTime { get; set; }
        public Guid? UpdatedUserId { get; set; }
    }
}

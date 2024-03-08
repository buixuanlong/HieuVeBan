namespace HieuVeBan.Abstraction.Interfaces;

public interface IUserContext
{
    Guid GetUserId();
    string GetEmail();
}

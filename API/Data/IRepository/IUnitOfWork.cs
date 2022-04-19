
namespace API.Data.IRepository
{
    public interface IUnitOfWork
    {
        ITeamRepository Teams { get; }
        Task<bool> Save();
    }
}
namespace API.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ITeamRepository Teams { get; }
        Task<bool> Save();
    }
}
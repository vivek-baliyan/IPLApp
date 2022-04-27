namespace API.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ITeamRepository TeamRepository { get; }
        IMatchRepository MatchRepository { get; }
        Task<bool> Save();
    }
}
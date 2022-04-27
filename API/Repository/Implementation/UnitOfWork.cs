using API.Data;
using API.Repository.Interfaces;

namespace API.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _db;
        public UnitOfWork(DataContext db)
        {
            _db = db;
            TeamRepository = new TeamRepository(_db);
            MatchRepository = new MatchRepository(_db);
        }
        public ITeamRepository TeamRepository { get; private set; }
        public IMatchRepository MatchRepository { get; private set; }
        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
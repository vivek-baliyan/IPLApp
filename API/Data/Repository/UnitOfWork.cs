
using API.Data.IRepository;

namespace API.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _db;

        public UnitOfWork(DataContext db)
        {
            _db = db;
            Teams = new TeamRepository(_db);
        }
        public ITeamRepository Teams {get; private set;}
        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
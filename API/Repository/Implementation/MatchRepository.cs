using API.Data;
using API.Entities;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Implementation
{
    public class MatchRepository : Repository<Match>, IMatchRepository
    {
        private readonly DataContext _db;

        public MatchRepository(DataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Match match)
        {
            _db.Update(match);
        }
    }
}
using API.Data;
using API.Entities;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Implementation
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        private readonly DataContext _db;

        public TeamRepository(DataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Team team)
        {
            _db.Update(team);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.IRepository;
using API.Entities;

namespace API.Data.Repository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(DataContext db) : base(db)
        {
        }
    }
}
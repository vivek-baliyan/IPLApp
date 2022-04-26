using API.Entities;

namespace API.Repository.Interfaces
{
    public interface ITeamRepository : IRepository<Team>
    {
        void Update(Team team);
    }
}
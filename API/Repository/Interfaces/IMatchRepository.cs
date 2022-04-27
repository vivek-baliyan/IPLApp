using API.Entities;

namespace API.Repository.Interfaces
{
    public interface IMatchRepository : IRepository<Match>
    {
        void Update(Match match);
    }
}
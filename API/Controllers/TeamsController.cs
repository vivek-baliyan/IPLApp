using API.Data.IRepository;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TeamsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeamsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            return await _unitOfWork.Teams.GetAll();
        }
        [HttpPost("save")]
        public async Task<ActionResult<Team>> SaveTeamAsync(Team team)
        {
            if (String.IsNullOrEmpty(team.Name))
                return BadRequest("Team name is required");
            _unitOfWork.Teams.Add(team);
            if (await _unitOfWork.Save())
                return Ok(team);
            return BadRequest("Failed to save team");
        }
    }
}
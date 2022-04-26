using API.DTOs;
using API.Entities;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TeamsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;

        public TeamsController(IUnitOfWork unitOfWork, IPhotoService photoService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _photoService = photoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TeamDto>> GetTeamsAsync()
        {
            var teams = await _unitOfWork.Teams.GetAllAsync();
            return _mapper.Map<IEnumerable<TeamDto>>(teams);
        }

        [HttpPost("save")]
        public async Task<ActionResult<TeamDto>> SaveTeamAsync(TeamDto teamDto)
        {
            if (String.IsNullOrEmpty(teamDto.TeamName))
                return BadRequest("Team name is required");
            var team = new Team
            {
                TeamName = teamDto.TeamName,
                ShortName = teamDto.ShortName,
                Owner = teamDto.Owner,
                Venue = teamDto.Venue,
                Coach = teamDto.Coach,
                Captain = teamDto.Captain,
                Year = teamDto.Year,
            };
            _unitOfWork.Teams.Add(team);
            if (await _unitOfWork.Save())
                return Ok(_mapper.Map<TeamDto>(team));
            return BadRequest("Failed to save team");
        }

        [HttpPost("add-photo")]
        public async Task<ActionResult<TeamLogoDto>> AddPhoto(IFormFile file, int teamId)
        {
            var team = await _unitOfWork.Teams.GetFirstOrDefaultAsync(x => x.Id == teamId);

            if (team == null) return BadRequest("Team not found");

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);

            team.Logo = new TeamLogo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            _unitOfWork.Teams.Update(team);

            if (await _unitOfWork.Save())
            {
                return CreatedAtRoute("GetTeam", team);
            }
            return BadRequest("Problem adding photo");
        }
    }
}
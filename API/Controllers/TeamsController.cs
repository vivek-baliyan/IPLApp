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
            var teams = await _unitOfWork.TeamRepository.GetAllAsync(includeroperties: "Logo");
            return _mapper.Map<IEnumerable<TeamDto>>(teams);
        }
        [HttpGet("{id}", Name = "GetTeam")]
        public async Task<TeamDto> GetTeamAsync(int id)
        {
            var team = await _unitOfWork.TeamRepository.GetFirstOrDefaultAsync(x => x.Id == id, includeroperties: "Logo");
            return _mapper.Map<TeamDto>(team);
        }
        [HttpPost]
        public async Task<ActionResult<TeamDto>> SaveTeam(TeamDto teamDto)
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
            _unitOfWork.TeamRepository.Add(team);
            if (await _unitOfWork.Save())
                return Ok(_mapper.Map<TeamDto>(team));
            return BadRequest("Failed to save team");
        }
        [HttpPut]
        public async Task<ActionResult> UpdateTeam(TeamDto teamUpdateDto)
        {
            var team = await _unitOfWork.TeamRepository.GetFirstOrDefaultAsync(x => x.Id == teamUpdateDto.Id);

            if (team == null) return BadRequest("Team not found");

            _mapper.Map(teamUpdateDto, team);
            _unitOfWork.TeamRepository.Update(team);
            if (await _unitOfWork.Save()) return NoContent();
            return BadRequest("Failed to update user");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeam(int id)
        {
            var team = await _unitOfWork.TeamRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            if (team == null) return BadRequest("Team not found");

            _unitOfWork.TeamRepository.Remove(team);

            if (await _unitOfWork.Save()) return Ok();
            return BadRequest("Failed to delete user");
        }
        [HttpPost("add-photo")]
        public async Task<ActionResult<TeamLogoDto>> AddPhoto(IFormFile file, int teamId)
        {
            var team = await _unitOfWork.TeamRepository.GetFirstOrDefaultAsync(x => x.Id == teamId);

            if (team == null) return BadRequest("Team not found");

            var result = await _photoService.AddPhotoAsync(file, 396, 396);

            if (result.Error != null) return BadRequest(result.Error.Message);

            team.Logo = new TeamLogo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            _unitOfWork.TeamRepository.Update(team);

            if (await _unitOfWork.Save())
            {
                return CreatedAtRoute("GetTeam", new { id = team.Id }, _mapper.Map<TeamLogoDto>(team.Logo));
            }
            return BadRequest("Problem adding photo");
        }
    }
}
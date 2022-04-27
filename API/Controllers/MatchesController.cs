using API.DTOs;
using API.Entities;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MatchesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MatchesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<MatchDto>> GetMatchesAsync()
        {
            var Matches = await _unitOfWork.MatchRepository.GetAllAsync(includeroperties: "MatchDetails");
            return _mapper.Map<IEnumerable<MatchDto>>(Matches);
        }
        [HttpGet("{id}", Name = "GetMatch")]
        public async Task<MatchDto> GetMatchAsync(int id)
        {
            var Match = await _unitOfWork.MatchRepository.GetFirstOrDefaultAsync(x => x.Id == id, includeroperties: "MatchDetails");
            return _mapper.Map<MatchDto>(Match);
        }
        [HttpPost]
        public async Task<ActionResult<MatchDto>> SaveMatch(MatchDto matchDto)
        {
            if (matchDto.MatchNo <= 0)
                return BadRequest("Match no is required");

            List<MatchDetails> matchDetails = new();
            if (matchDto.MatchDetails != null)
            {
                foreach (var item in matchDto.MatchDetails)
                {
                    matchDetails.Add(new MatchDetails
                    {
                        IsMatchWon = item.IsMatchWon,
                        IsTossWon = item.IsTossWon,
                        RunsScored = item.RunsScored,
                        WicketsTaken = item.WicketsTaken,
                        TeamId = item.TeamId
                    });
                }
            }
            var match = new Match
            {
                MatchNo = matchDto.MatchNo,
                MatchDate = matchDto.MatchDate,
                Venue = matchDto.Venue,
                MatchDetails = matchDetails
            };
            _unitOfWork.MatchRepository.Add(match);
            if (await _unitOfWork.Save())
                return Ok(_mapper.Map<MatchDto>(match));
            return BadRequest("Failed to save Match");
        }
        [HttpPut]
        public async Task<ActionResult> UpdateMatch(MatchDto matchUpdateDto)
        {
            var match = await _unitOfWork.MatchRepository.GetFirstOrDefaultAsync(x => x.Id == matchUpdateDto.Id);

            if (match == null) return BadRequest("Match not found");

            _mapper.Map(matchUpdateDto, match);
            _unitOfWork.MatchRepository.Update(match);
            if (await _unitOfWork.Save()) return NoContent();
            return BadRequest("Failed to update user");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMatch(int id)
        {
            var Match = await _unitOfWork.MatchRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            if (Match == null) return BadRequest("Match not found");

            _unitOfWork.MatchRepository.Remove(Match);

            if (await _unitOfWork.Save()) return Ok();
            return BadRequest("Failed to delete user");
        }
    }
}
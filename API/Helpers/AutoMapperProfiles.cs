using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Team, TeamDto>();
            CreateMap<TeamLogo, TeamLogoDto>();
            CreateMap<TeamDto, Team>();
            CreateMap<Match, MatchDto>();
            CreateMap<MatchDetails, MatchDetailsDto>();
        }
    }
}
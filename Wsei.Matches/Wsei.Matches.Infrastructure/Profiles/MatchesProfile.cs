using AutoMapper;
using Wsei.Matches.Core.DbModel;

namespace Wsei.Matches.Application.Dtos
{
    public class MatchesProfile : Profile
    {
        public MatchesProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<League, LeagueDto>();
            CreateMap<Match, MatchDto>();
            CreateMap<Stadium, StadiumDto>();
            CreateMap<Team, TeamDto>();
        }
    }
}
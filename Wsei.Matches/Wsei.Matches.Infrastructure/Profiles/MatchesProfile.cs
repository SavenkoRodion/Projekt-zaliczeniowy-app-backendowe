using AutoMapper;
using Wsei.Matches.Core.DbModel;

namespace Wsei.Matches.Application.Dtos
{
    public class MatchesProfile : Profile
    {
        public MatchesProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<League, LeagueDto>().ReverseMap();
            CreateMap<Match, MatchDto>().ReverseMap();
            CreateMap<Stadium, StadiumDto>().ReverseMap();
            CreateMap<Team, TeamDto>().ReverseMap();
        }
    }
}
using AutoMapper;
using Wsei.Matches.Core.DbModel;
using Wsei.Matches.Web.Dtos;
namespace Wsei.Matches.Web.Profiles
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
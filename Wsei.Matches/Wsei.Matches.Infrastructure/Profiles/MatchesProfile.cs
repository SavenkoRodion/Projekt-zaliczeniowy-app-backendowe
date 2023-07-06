using AutoMapper;
using Wsei.Matches.Application.Dtos.Requests;
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

            CreateMap<LeagueDtoRequest, League>().ForPath(dest => dest.Country.Id, act => act.MapFrom(src => src.CountryId));
            //.ForMember(dest => dest.FullName, act => act.MapFrom(src => src.Name))
        }
    }
}
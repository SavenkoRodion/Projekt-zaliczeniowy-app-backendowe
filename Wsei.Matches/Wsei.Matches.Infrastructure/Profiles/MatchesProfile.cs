using AutoMapper;
using Wsei.Matches.Application.Dtos.Requests;
using Wsei.Matches.Application.Dtos.Responses;
using Wsei.Matches.Core.DbModel;

namespace Wsei.Matches.Application.Dtos
{
    public class MatchesProfile : Profile
    {
        public MatchesProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<League, LeagueDtoResponse>().ReverseMap();
            CreateMap<Match, MatchDtoResponse>().ReverseMap();
            CreateMap<Stadium, StadiumDto>().ReverseMap();
            CreateMap<Team, TeamDtoResponse>().ReverseMap();

            CreateMap<LeagueDtoRequest, League>()
                .ForPath(dest => dest.Country.Id,
                    act => act.MapFrom(src => src.CountryId));

            CreateMap<MatchDtoRequest, Match>()
                .ForPath(dest => dest.HomeTeam,
                    act => act.MapFrom(src => src.HomeTeamId))
                .ForPath(dest => dest.GuestTeam,
                    act => act.MapFrom(src => src.GuestTeamId))
                .ForPath(dest => dest.League,
                    act => act.MapFrom(src => src.LeagueId))
                .ForPath(dest => dest.Stadium,
                    act => act.MapFrom(src => src.StadiumId));

            CreateMap<TeamDtoRequest, Team>()
                .ForPath(dest => dest.League,
                    act => act.MapFrom(src => src.LeagueId));
            //.ForMember(dest => dest.FullName, act => act.MapFrom(src => src.Name))
        }
    }
}
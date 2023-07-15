using AutoMapper;
using Wsei.Matches.Core.DbModel;
using Wsei.Matches.Infrastructure.Dtos;
using Wsei.Matches.Infrastructure.Dtos.Requests;
using Wsei.Matches.Infrastructure.Dtos.Responses;

namespace Wsei.Matches.Infrastructure.Profiles
{
    public class MatchesProfile : Profile
    {
        public MatchesProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<League, LeagueDtoResponse>().ReverseMap();
            CreateMap<Match, MatchDtoResponse>()
                .ForMember(dest => dest.HomeTeamWinRate,
                    act => act.Ignore())
                .ReverseMap();
            CreateMap<Stadium, StadiumDto>().ReverseMap();
            CreateMap<Team, TeamDtoResponse>().ReverseMap();

            CreateMap<LeagueDtoRequest, League>()
                .ForPath(dest => dest.Country.Id,
                    act => act.MapFrom(src => src.CountryId));

            CreateMap<MatchDtoRequest, Match>()
                .ForPath(dest => dest.HomeTeam.Id,
                    act => act.MapFrom(src => src.HomeTeamId))
                .ForPath(dest => dest.GuestTeam.Id,
                    act => act.MapFrom(src => src.GuestTeamId))
                .ForPath(dest => dest.League.Id,
                    act => act.MapFrom(src => src.LeagueId))
                .ForPath(dest => dest.Stadium.Id,
                    act => act.MapFrom(src => src.StadiumId));

            CreateMap<TeamDtoRequest, Team>()
                .ForPath(dest => dest.League.Id,
                    act => act.MapFrom(src => src.LeagueId));
            //.ForMember(dest => dest.FullName, act => act.MapFrom(src => src.Name))
        }
    }
}
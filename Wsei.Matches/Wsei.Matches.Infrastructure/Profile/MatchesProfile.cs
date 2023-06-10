using Wsei.Matches.Core.DbModel;

namespace Wsei.Matches.Infrastructure.Profile
{
    internal class MatchesProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Match, MatchDto>();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}

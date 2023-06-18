using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Contexts;
using Match = Wsei.Matches.Core.DbModel.Match;

namespace Wsei.Matches.Infrastructure.Repositories
{
    public class MatchRepository : IRepository<MatchDto>
    {
        private readonly MatchesDbContext _matchesDbContext;
        private readonly IMapper _mapper;

        public MatchRepository(MatchesDbContext matchesDbContext, IMapper mapper)
        {
            _matchesDbContext = matchesDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MatchDto>> GetAllAsync()
        {
            IEnumerable<Match> matchesDbModel = _matchesDbContext.Matches.ToList();

            IEnumerable<MatchDto> matchesDto = _mapper.Map<IEnumerable<MatchDto>>(matchesDbModel);

            return matchesDto;
        }

        public async Task<MatchDto?> GetByIdAsync(int id)
        {
            IEnumerable<Match> matchesDbModel = _matchesDbContext.Matches.ToList();

            Match? match = matchesDbModel.Where(match => match.Id == id).FirstOrDefault();

            MatchDto matchDto = _mapper.Map<MatchDto>(match);

            return matchDto;
        }

        public async Task AddAsync(IEnumerable<MatchDto> matches)
        {
            Match matchDbModel;
            foreach (MatchDto match in matches)
            {
                matchDbModel = _mapper.Map<Match>(match);
                await _matchesDbContext.Matches.AddAsync(matchDbModel);
            }
            await _matchesDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<int> ids)
        {
            foreach (int id in ids)
            {
                await _matchesDbContext.Matches.Where(match => match.Id == id).ExecuteDeleteAsync();
            }
        }

        public async Task UpdateAsync(IEnumerable<MatchDto> matchesToUpdate)
        {
            foreach (MatchDto matchToUpdate in matchesToUpdate)
            {
                Match mappedMatchToUpdate = _mapper.Map<Match>(matchToUpdate);
                Match countryFromDb = await _matchesDbContext.Matches.Where(match => match.Id == matchToUpdate.Id).FirstOrDefaultAsync();
                countryFromDb.TicketPrice = mappedMatchToUpdate.TicketPrice;
            }
            await _matchesDbContext.SaveChangesAsync();
        }
    }
}

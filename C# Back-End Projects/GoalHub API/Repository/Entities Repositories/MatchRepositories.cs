using Contracts.Repositories.Entities_IRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Context;
using Repository.Extensions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.Match;
using System.ComponentModel.Design;
using System.Threading;

namespace Repository.Entities_Repositories
{
    public class MatchRepository<TContext>
                : RepositoryBase<TContext, Match>, IMatchRepository
                where TContext : DbContext
    {

        private readonly Lazy<CreateRepositoryBase<TContext, Match>> _Create;
        private readonly Lazy<DeleteRepositoryBase<TContext, Match>> _Delete;
        private readonly Lazy<ReadRepositoryBase<TContext, Match>> _Read;

        public MatchRepository(TContext repositoryContext) : base(repositoryContext)
        {
            _Create = new Lazy<CreateRepositoryBase<TContext, Match>>(() => new CreateRepositoryBase<TContext, Match>(repositoryContext));
            _Delete = new Lazy<DeleteRepositoryBase<TContext, Match>>(() => new DeleteRepositoryBase<TContext, Match>(repositoryContext));
            _Read = new Lazy<ReadRepositoryBase<TContext, Match>>(() => new ReadRepositoryBase<TContext, Match>(repositoryContext));
        }
 


        public async Task CreateMatchAsync(Match Match)
        {
            _Create.Value.Create(Match);
        }

        public async Task<PagedList<Match>> GetAllMatchAsync(MatchParameters MatchsParameters, bool trackChanges)
        {
            List<Match> Matchs = _Read.Value.FindAll(trackChanges)
                              .Search(MatchsParameters)
                              .Sort(MatchsParameters.OrderBy)
                              .Include(Match => Match.Stadium)
                              .Include(Match => Match.MatchStatus)
                              .Include(Match => Match.AwayTeam)
                              .Include(Match => Match.HomeTeam)
                              .Skip((MatchsParameters.PageNumber - 1) * MatchsParameters.PageSize)
                              .Take(MatchsParameters.PageSize)
                              .ToList();

            int count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Match>(Matchs, count, MatchsParameters.PageNumber, MatchsParameters.PageSize);
        }

        public async Task<Match?> GetMatchAsync(long ID, bool trackChanges)
        {
            return await _Read.Value.FindByCondition(M => M.ID.Equals(ID), trackChanges)
                                    .Include(Match => Match.Stadium)
                                    .Include(Match => Match.MatchStatus)
                                    .Include(Match => Match.AwayTeam)
                                    .Include(Match => Match.HomeTeam)
                                    .SingleOrDefaultAsync();

        }

      
    }
}

using Contracts.Repositories.Entities_IRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Context;
using Repository.Extensions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using Shared.RequestFeatures.Player;
using System.Collections.Generic;
using System.Threading;


namespace Repository.Entities_Repositories
{
    public class TeamRepositoryv2<TContext> : ITeamRepositoryv2
        where TContext : DbContext
    {
        private readonly Lazy<ReadRepositoryBase<TContext, Team>> _Read;

        public TeamRepositoryv2(TContext repositoryContext)
        {
            _Read = new Lazy<ReadRepositoryBase<TContext, Team>>(() => new ReadRepositoryBase<TContext, Team>(repositoryContext));

        }

        public async Task<PagedList<Team>> GetAllTeamsAsync(TeamParameters TeamParameters, bool trackChanges)
        {

            List<Team> Teams = await _Read.Value.FindByCondition(Team => !Team.IsDeleted, trackChanges)
                         .Search(TeamParameters)
                         .Sort(TeamParameters.OrderBy)
                         .Include(Team => Team.Stadium)
                         .Include(Team => Team.City)
                            .ThenInclude(City => City.Country)
                         .ToListAsync();

            return PagedList<Team>
                  .ToPagedList(Teams, TeamParameters.PageNumber, TeamParameters.PageSize);
        }

        public async Task<Team?> GetTeamAsync(int TeamID, bool trackChanges)
        {
            return await _Read.Value.FindByCondition(Team => Team.ID.Equals(TeamID) && !Team.IsDeleted, trackChanges)
                .Include(Team => Team.Stadium)
                .Include(Team => Team.City)
                 .ThenInclude(City => City.Country)
                .SingleOrDefaultAsync();
        }
    }
}

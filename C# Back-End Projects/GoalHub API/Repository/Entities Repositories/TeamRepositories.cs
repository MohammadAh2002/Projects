using Contracts.Repositories.Entities_IRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Context;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using Shared.RequestFeatures.Player;


namespace Repository.Entities_Repositories
{
    public class TeamRepository<TContext>
                : RepositoryBase<TContext, Team>, ITeamRepository
                where TContext : DbContext
    {
        public TeamRepository(TContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateTeam(Team Team)
        {
           Create(Team);
        }

        public async Task DeleteTeam(Team Team)
        {
           
            Team.IsDeleted = true;

            Update(Team);

        }

        public async Task<PagedList<Team>> GetAllTeamsAsync(TeamParameters TeamParameters, bool trackChanges)
        {

            List<Team> Teams = await FindByCondition(Team => !Team.IsDeleted, trackChanges)
                                     .Include(Team => Team.Stadium)
                                     .ToListAsync();

            return PagedList<Team>
                  .ToPagedList(Teams, TeamParameters.PageNumber, TeamParameters.PageSize);
        }

        public async Task<Team?> GetTeamAsync(int TeamID, bool trackChanges)
        {
            return await FindByCondition(Team => Team.ID.Equals(TeamID) && !Team.IsDeleted, trackChanges)
                .Include(Team => Team.Stadium)
                .SingleOrDefaultAsync();
        }
    }
}

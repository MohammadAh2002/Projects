using Contracts.Repositories.Entities_IRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Context;
using Repository.Extensions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using Shared.RequestFeatures.Player;

namespace Repository.Entities_Repositories
{
    public class PlayerRepository<TContext>
                : RepositoryBase<TContext, Player>, IPlayerRepository
                where TContext : DbContext
    {
        public PlayerRepository(TContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreatePlayerAsync(Player Player)
        {
            Create(Player);
        }

        public async Task DeletePlayerAsync(Player Player)
        {
            Delete(Player);
        }

        public async Task<PagedList<Player>> GetAllPlayersAsync(PlayerParameters PlayerParameters, bool trackChanges)
        {
            IQueryable<Player> Query = FindAll(trackChanges)
                        .Search(PlayerParameters)
                        .Include(p => p.Status)
                        .Include(p => p.Person)
                        .AsQueryable();

            return PagedList<Player>
                  .ToPagedList(Query, PlayerParameters.PageNumber, PlayerParameters.PageSize);
        }

        public async Task<Player?> GetPlayerAsync(int ID, bool trackChanges)
        {
            return await FindByCondition(Player => Player.ID.Equals(ID), trackChanges)
               .Include(Player => Player.Status)
               .SingleOrDefaultAsync();
        }

        public async Task UpdatePlayer(Player Player)
        {
           Update(Player);
        }

    }
}

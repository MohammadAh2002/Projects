using Contracts.Repositories.Entities_IRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Context;

namespace Repository.Entities_Repositories
{
    public class PlayerStatusRepository<TContext> : IPlayerStatusRepository
        where TContext : DbContext
    {
        private readonly Lazy<CreateRepositoryBase<TContext, PlayerStatus>> _Create;
        private readonly Lazy<UpdateRepositoryBase<TContext, PlayerStatus>> _Update;

        public PlayerStatusRepository(TContext repositoryContext)
        {
            _Create = new Lazy<CreateRepositoryBase<TContext, PlayerStatus>>(() => new CreateRepositoryBase<TContext, PlayerStatus>(repositoryContext));
            _Update = new Lazy<UpdateRepositoryBase<TContext, PlayerStatus>>(() => new UpdateRepositoryBase<TContext, PlayerStatus>(repositoryContext));
        }

        public async Task CreatePlayerStatusAsync(PlayerStatus PlayerStatus)
        {
            _Create.Value.Create(PlayerStatus);
        }

        public async Task UpdatePlayerStatusAsync(PlayerStatus PlayerStatus)
        {
            _Update.Value.Update(PlayerStatus);
        }
    }
}

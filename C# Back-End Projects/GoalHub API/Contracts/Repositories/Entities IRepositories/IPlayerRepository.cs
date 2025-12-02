using Entities.Models;
using Shared.DataTransferObjects.City;
using Shared.RequestFeatures;
using Shared.RequestFeatures.Player;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories.Entities_IRepositories
{
    public interface IPlayerRepository
    {

        Task CreatePlayerAsync(Player Player);
        Task<Player?> GetPlayerAsync(int ID, bool trackChanges);

        Task DeletePlayerAsync(Player Player);

        Task<PagedList<Player>> GetAllPlayersAsync(PlayerParameters PlayerParameters, bool trackChanges);

        Task UpdatePlayer(Player Player);
    }
}

using Entities.Models;
using Shared.DataTransferObjects.City;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories.Entities_IRepositories
{
    public interface IPlayerStatusRepository
    {

        Task CreatePlayerStatusAsync(PlayerStatus PlayerStatus);

        Task UpdatePlayerStatusAsync(PlayerStatus PlayerStatus);
        
    }
}

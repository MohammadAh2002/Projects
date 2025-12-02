using Entities.Models;
using Shared.RequestFeatures;
using Shared.RequestFeatures.Player;


namespace Contracts.Repositories.Entities_IRepositories
{
    public interface ITeamRepositoryv2
    {

        Task<PagedList<Team>> GetAllTeamsAsync(TeamParameters TeamParameters, bool trackChanges);

        Task<Team?> GetTeamAsync(int TeamID, bool trackChanges);

    }
}

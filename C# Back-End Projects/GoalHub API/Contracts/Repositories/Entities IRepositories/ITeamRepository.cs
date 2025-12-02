using Entities.Models;
using Shared.RequestFeatures;
using Shared.RequestFeatures.Player;


namespace Contracts.Repositories.Entities_IRepositories
{
    public interface ITeamRepository
    {

        Task<PagedList<Team>> GetAllTeamsAsync(TeamParameters TeamParameters, bool trackChanges);

        Task<Team?> GetTeamAsync(int TeamID, bool trackChanges);

        Task CreateTeam(Team Team);

        Task DeleteTeam(Team Team);

    }
}

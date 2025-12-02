using Entities.Models;
using Shared.RequestFeatures;
using Shared.RequestFeatures.Match;

namespace Contracts.Repositories.Entities_IRepositories
{
    public interface IMatchRepository
    {

        Task CreateMatchAsync(Match Match);
        Task<Match?> GetMatchAsync(long ID, bool trackChanges);

        Task<PagedList<Match>> GetAllMatchAsync(MatchParameters MatchsParameters, bool trackChanges);

    }
}

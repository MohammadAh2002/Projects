using Contracts.Repositories.Entities_IRepositories;
using Entities.Models;


namespace Contracts.Repositories.IRepositories
{
    public interface IRepositoryManager
    {

        ICountryRepository Country { get; }
        ICityRepository City { get; }

        IPersonRepository Person { get; }

        ITeamRepository Team { get; }
        ITeamRepositoryv2 Teamv2 { get; }

        IPlayerRepository Player { get; }

        IPlayerStatusRepository PlayerStatus { get; }

        IMatchRepository Match { get; }

        Task SaveAsync();
    }
}

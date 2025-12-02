using Entities.Models;
using Entities.Responses;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Country;
using Shared.DataTransferObjects.Match;
using Shared.DataTransferObjects.Person;
using Shared.DataTransferObjects.Player;
using Shared.RequestFeatures;
using Shared.RequestFeatures.Match;
using System.Dynamic;

namespace Contracts.IServices.Entities_IServices
{
    public interface IMatchService
    {

        Task<(IEnumerable<ExpandoObject> Matchs, MetaData MetaData)> GetAllMatchsAsync(MatchParameters MatchsParameters, bool trackChanges);

        Task<ApiBaseResponse> GetMatchAsync(long MatchID, bool trackChanges);

        Task<ApiBaseResponse> CreateMatchAsync(MatchCreationDTO Match, bool trackChanges);

        Task<(MatchForPatchDTO MatchToPatch, Match MatchEntity)> GetMatchForPatchAsync(
                                                                long MtachID, bool empTrackChanges);
        Task SaveChangesForPatchAsync(MatchForPatchDTO MatchToPatch, Match MatchEntity);

    }
}

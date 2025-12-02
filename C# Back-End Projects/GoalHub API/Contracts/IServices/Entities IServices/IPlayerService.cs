using Entities.Models;
using Entities.Responses;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Country;
using Shared.DataTransferObjects.Person;
using Shared.DataTransferObjects.Player;
using Shared.RequestFeatures;
using Shared.RequestFeatures.Player;
using System.Dynamic;

namespace Contracts.IServices.Entities_IServices
{
    public interface IPlayerService
    {

        Task<(IEnumerable<ExpandoObject> Players, MetaData MetaData)> GetAllPlayersAsync(PlayerParameters PlayerParameters, bool trackChanges);

        Task<ApiBaseResponse> GetPlayerAsync(int PlayerID, bool trackChanges);

        Task<ApiBaseResponse> CreatePlayerAsync(PlayerCreationDTO Player, bool trackChanges);

        Task DeletePlayerAsync(int PlayerID, bool trackChanges);

        Task UpdatePlayerAsync(int PlayerID, PlayerForUpdateDTO Player, bool trackChanges);

        Task<(PlayerForUpdateDTO PlayerToPatch, Player PlayerEntity)> GetPlayerForPatchAsync(
                                                                int PlayerID, bool empTrackChanges);
        Task SaveChangesForPatchAsync(PlayerForUpdateDTO PlayerToPatch, Player PlayerEntity);

        Task UpdatePlayerStatusAsync(int PlayerID, PlayerStatusDTO PlayerStatus, bool trackChanges);

    }
}

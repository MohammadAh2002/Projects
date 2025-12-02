using Entities.Models;
using Entities.Responses;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Team;
using Shared.RequestFeatures;
using Shared.RequestFeatures.Player;
using System.Dynamic;

namespace Contracts.IServices.Entities_IServices
{
    public interface ITeamService
    {

        Task<(IEnumerable<ExpandoObject> Teams, MetaData MetaData)> GetAllTeamsAsync(TeamParameters TeamParameters, bool trackChanges);

        Task<ApiBaseResponse> GetTeamAsync(int TeamID, bool trackChanges);

        Task<ApiBaseResponse> CreateTeamAsync(TeamCreationDTO Team);

        Task<ApiBaseResponse> DeleteTeamAsync(int TeamID, bool trackChanges);

        Task<(TeamForUpdateDto TeamToPatch, Team TeamEntity)> GetTeamForPatchAsync(
        int TeamID, bool empTrackChanges);

        Task SaveChangesForPatchAsync(TeamForUpdateDto TeamToPatch, Team TeamEntity);

        Task<ApiBaseResponse> UpdateTeamLogoAsync(int ID, IFormFile Logo);
    }
}

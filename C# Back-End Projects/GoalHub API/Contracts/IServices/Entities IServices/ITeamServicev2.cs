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
    public interface ITeamServicev2
    {

        Task<(IEnumerable<ExpandoObject> Teams, MetaData MetaData)> GetAllTeamsAsync(TeamParameters TeamParameters, bool trackChanges);

        Task<ApiBaseResponse> GetTeamAsync(int TeamID, bool trackChanges);

    }
}

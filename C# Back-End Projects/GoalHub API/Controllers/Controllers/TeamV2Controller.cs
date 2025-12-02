using Contracts.IServices;
using Controllers.ActionFilters;
using Controllers.Infrastructure;
using Entities.Models;
using Entities.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Shared.DataTransferObjects.Team;
using Shared.RequestFeatures;
using Shared.RequestFeatures.Player;
using System.Dynamic;
using System.Text.Json;

namespace Controllers.Controllers
{
    [ApiVersion("2.0")]
    [Route("Teams")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class TeamV2Controller : ApiControllerBase
    {
        private readonly IServiceManager _Service;
        public TeamV2Controller(IServiceManager Service)
        {

            _Service = Service;

        }

        [HttpGet("{ID}", Name = "TeamByID")]
        [EnableRateLimiting("GetByIDPolicy")]
        [AllowAnonymous]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTeam(int ID)
        {
            ApiBaseResponse BaseResult = await _Service.TeamServicev2.GetTeamAsync(ID, trackChanges: false);

            if (!BaseResult.Success)
                return ProcessError(BaseResult);

            TeamDTOv2 Team = BaseResult.GetResult<TeamDTOv2>();

            return Ok(Team);
        }

        [HttpGet(Name = "GetTeams")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTeams([FromQuery] TeamParameters TeamParameters)
        {

            (IEnumerable<ExpandoObject> Teams, MetaData MetaData) PagedResult = await _Service.TeamServicev2.GetAllTeamsAsync(TeamParameters, trackChanges: false);

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(PagedResult.MetaData));

            return Ok(PagedResult.Teams);

        }


        [HttpOptions]
        public IActionResult GetTeamsOptions()
        {
            Response.Headers.Append("Allow", "GET, OPTIONS");
            return Ok();
        }
    }
}

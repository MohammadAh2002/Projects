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
    [ApiVersion("1.0", Deprecated = true)]
    [Route("Teams")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class TeamController : ApiControllerBase
    {
        private readonly IServiceManager _Service;
        public TeamController(IServiceManager Service)
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
            ApiBaseResponse BaseResult = await _Service.TeamService.GetTeamAsync(ID, trackChanges: false);

            if (!BaseResult.Success)
                return ProcessError(BaseResult);

            TeamDTO Team = BaseResult.GetResult<TeamDTO>();

            return Ok(Team);
        }

        [HttpGet(Name = "GetTeams")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTeams([FromQuery] TeamParameters TeamParameters)
        {

            (IEnumerable<ExpandoObject> Teams, MetaData MetaData) PagedResult = await _Service.TeamService.GetAllTeamsAsync(TeamParameters, trackChanges: false);

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(PagedResult.MetaData));

            return Ok(PagedResult.Teams);

        }

        [HttpPost(Name = "CreatedTeam")]
        [Authorize(Roles = "Team Manager,Manager")]
        [ServiceFilter(typeof(ValidateNotNullIActionFilter))]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateTeam([FromBody] TeamCreationDTO Team)
        {

            ApiBaseResponse BaseResult = await _Service.TeamService.CreateTeamAsync(Team);

            return CreatedAtRoute("TeamByID", new { BaseResult.GetResult<TeamDTO>().ID }, BaseResult.GetResult<TeamDTO>());

        }

        [HttpDelete("{ID}", Name = "DeleteTeam")]
        [Authorize(Roles = "Team Manager,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCountries(int ID)
        {
            await _Service.TeamService.DeleteTeamAsync(ID, trackChanges: false);

            return NoContent();
        }

        [HttpPatch("{ID}")]
        [Authorize(Roles = "Team Manager,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> PartiallyUpdateCity(int ID,
                                  [FromBody] JsonPatchDocument<TeamForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            (TeamForUpdateDto TeamToPatch, Team TeamEntity) Result = await _Service.TeamService.GetTeamForPatchAsync(ID, true);

            patchDoc.ApplyTo(Result.TeamToPatch, ModelState);

            TryValidateModel(Result.TeamToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _Service.TeamService.SaveChangesForPatchAsync(Result.TeamToPatch, Result.TeamEntity);

            return NoContent();
        }

        [HttpPatch("{ID:int}/Logo")]
        [Authorize(Roles = "Team Manager,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTeamLogo(int ID, IFormFile Logo)
        {

            ApiBaseResponse BaseResult = await _Service.TeamService.UpdateTeamLogoAsync(ID, Logo);

            if (BaseResult is ApiOkResponse<bool> okResponse)
            {
                if (okResponse.Result)
                    return NoContent();

                return BadRequest("Failed to update team logo.");
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected error occurred.");

        }

        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetTeamsOptions()
        {
            Response.Headers.Append("Allow", "GET, OPTIONS, POST, Delete, Patch");
            return Ok();
        }
    }
}

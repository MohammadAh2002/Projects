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
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Match;
using Shared.DataTransferObjects.Player;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using Shared.RequestFeatures.Match;
using System.Dynamic;
using System.Text.Json;


namespace Controllers.Controllers
{
    [Route("Matchs")]
    [ApiController]
    public class MatchController : ApiControllerBase
    {
        private readonly IServiceManager _Service;
        public MatchController(IServiceManager Service)
        {

            _Service = Service;

        }

        [HttpPost(Name = "CreatedMatch")]
        [Authorize(Roles = "Match Manager,Manager")]
        [ServiceFilter(typeof(ValidateNotNullIActionFilter))]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateMatch([FromBody] MatchCreationDTO Match)
        {

           ApiBaseResponse BaseResult = await _Service.MatchService.CreateMatchAsync(Match, false);

            return CreatedAtRoute("MatchByID", new { BaseResult.GetResult<MatchDTO>().ID }, BaseResult.GetResult<MatchDTO>());

        }

        [HttpGet("{ID:long}", Name = "MatchByID")]
        [EnableRateLimiting("GetByIDPolicy")]
        [Authorize(Roles = "Match Viewer,Match Manager,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlayer(long ID)
        {
            ApiBaseResponse BaseResult = await _Service.MatchService.GetMatchAsync(ID, trackChanges: false);

            if (!BaseResult.Success)
                return ProcessError(BaseResult);

            MatchDTO Match = BaseResult.GetResult<MatchDTO>();

            return Ok(Match);
        }

        [HttpGet(Name = "GetMatchs")]
        [Authorize(Roles = "Match Viewer,Match Manager,Manager")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMatchs([FromQuery] MatchParameters MatchParameters)
        {

            (IEnumerable<ExpandoObject> Matchs, MetaData MetaData) pagedResult = await _Service.MatchService.GetAllMatchsAsync(MatchParameters, trackChanges: false);       

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok(pagedResult.Matchs);
        }             

        [HttpPatch("{ID}")]
        [Authorize(Roles = "Match Manager,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> PartiallyUpdateCity(int ID,
                                          [FromBody] JsonPatchDocument<MatchForPatchDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            (MatchForPatchDTO MatchToPatch, Match MatchEntity) Result = await _Service.MatchService.GetMatchForPatchAsync(ID, true);

            patchDoc.ApplyTo(Result.MatchToPatch, ModelState);

            TryValidateModel(Result.MatchToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _Service.MatchService.SaveChangesForPatchAsync(Result.MatchToPatch, Result.MatchEntity);

            return NoContent();
        }


        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetPlayersOptions()
        {
            Response.Headers.Append("Allow", "GET, OPTIONS, POST, Patch");
            return Ok();
        }

    }
}

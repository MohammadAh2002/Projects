using Contracts.IServices;
using Controllers.ActionFilters;
using Controllers.Infrastructure;
using Entities.Models;
using Entities.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.RateLimiting;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Person;
using Shared.DataTransferObjects.Player;
using Shared.DataTransferObjects.Team;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using Shared.RequestFeatures.Player;
using System.Dynamic;
using System.Text.Json;

namespace Controllers.Controllers
{
    [Route("Players")]
    [ApiController]
    public class PlayerController : ApiControllerBase
    {
        private readonly IServiceManager _Service;
        public PlayerController(IServiceManager Service)
        {

            _Service = Service;

        }

        [HttpPost(Name = "CreatedPlayer")]
        [Authorize(Roles = "Player Manager,Manager")]
        [ServiceFilter(typeof(ValidateNotNullIActionFilter))]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayerCreationDTO Player)
        {

           ApiBaseResponse BaseResult = await _Service.PlayerService.CreatePlayerAsync(Player, false);

            return CreatedAtRoute("PlayerByID", new { BaseResult.GetResult<PlayerDTO>().ID }, BaseResult.GetResult<PlayerDTO>());

        }

        [HttpGet("{ID}", Name = "PlayerByID")]
        [EnableRateLimiting("GetByIDPolicy")]
        [AllowAnonymous]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlayer(int ID)
        {
            ApiBaseResponse BaseResult = await _Service.PlayerService.GetPlayerAsync(ID, trackChanges: false);

            if (!BaseResult.Success)
                return ProcessError(BaseResult);

            PlayerDTO Player = BaseResult.GetResult<PlayerDTO>();

            return Ok(Player);
        }

        [HttpGet(Name = "GetPlayers")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlayers([FromQuery] PlayerParameters PlayerParameters)
        {

            (IEnumerable<ExpandoObject> Players, MetaData MetaData) PagedResult = await _Service.PlayerService.GetAllPlayersAsync(PlayerParameters, trackChanges: false);       

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(PagedResult.MetaData));

            return Ok(PagedResult.Players);

        }         

        [HttpDelete("{ID}", Name = "DeletePlayer")]
        [Authorize(Roles = "Player Manager,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePlayer(int ID)
        {
            await _Service.PlayerService.DeletePlayerAsync(ID, trackChanges: false);

            return NoContent();

        }

        [HttpPut("{ID}", Name = "UpdatePlayer")]
        [Authorize(Roles = "Player Manager,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePlayer(int ID, [FromBody] PlayerForUpdateDTO UpdatedPlayer)
        {
            await _Service.PlayerService.UpdatePlayerAsync(ID, UpdatedPlayer, trackChanges: true);

            return NoContent();

        }

        [HttpPut("{ID}/Status", Name = "UpdateStatus")]
        [Authorize(Roles = "Player Manager,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStatus(int ID, [FromBody] PlayerStatusDTO UpdatedPlayer)
        {
            await _Service.PlayerService.UpdatePlayerStatusAsync(ID, UpdatedPlayer, trackChanges: true);

            return NoContent();

        }

        [HttpPatch("{ID}")]
        [Authorize(Roles = "Player Manager,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> PartiallyUpdateCity(int ID,
                                          [FromBody] JsonPatchDocument<PlayerForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            (PlayerForUpdateDTO PlayerToPatch, Player PlayerEntity) Result = await _Service.PlayerService.GetPlayerForPatchAsync(ID, true);

            patchDoc.ApplyTo(Result.PlayerToPatch, ModelState);

            TryValidateModel(Result.PlayerToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _Service.PlayerService.SaveChangesForPatchAsync(Result.PlayerToPatch, Result.PlayerEntity);

            return NoContent();
        }


        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetPlayersOptions()
        {
            Response.Headers.Append("Allow", "GET, OPTIONS, POST, Patch, Delete, Put");
            return Ok();
        }

    }
}

using Contracts.IServices;
using Controllers.ActionFilters;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Shared.DataTransferObjects.City;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using System.Dynamic;
using System.Text.Json;

namespace Controllers.Controllers
{
    [Route("Cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IServiceManager _Service;
        public CityController(IServiceManager Service)
        {

            _Service = Service;

        }

        /// <summary>
        /// Create New City
        /// </summary>
        /// <returns>New Item Created At Route</returns>
        [HttpPost("{ID}", Name = "CreatedCity")]
        [Authorize(Roles = "Administrator,Manager")]
        [ServiceFilter(typeof(ValidateNotNullIActionFilter))]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateCity(short ID, [FromBody] CityCreationDTO City)
        {

            CityDTO CreatedCity = await _Service.CityService.CreateCityAsync(ID, City, false);

            return CreatedAtRoute("CityByID", new { CreatedCity.ID }, CreatedCity);

        }

        [HttpGet("{ID}", Name = "CityByID")]
        [EnableRateLimiting("GetByIDPolicy")]
        [AllowAnonymous]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCity(short ID)
        {
            CityDTO? City = await _Service.CityService.GetCityAsync(ID, trackChanges: false);

            return Ok(City);
        }

        [HttpGet(Name = "GetCities")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCities([FromQuery] CityParameters CityParameters)
        {

            (IEnumerable<ExpandoObject> Cities, MetaData MetaData) pagedResult = await _Service.CityService.GetAllCitiesAsync(CityParameters, trackChanges: false);


            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok(pagedResult.Cities);

        }         

        [HttpDelete("{ID}", Name = "DeleteCity")]
        [Authorize(Roles = "Administrator,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCity(short ID)
        {
            await _Service.CityService.DeleteCityAsync(ID, trackChanges: false);

            return NoContent();

        }

        [HttpPatch("{ID}")]
        [Authorize(Roles = "Administrator,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> PartiallyUpdateCity(short ID,
                                          [FromBody] JsonPatchDocument<CityForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            (CityForUpdateDto CityToPatch, City CityEntity) Result = await _Service.CityService.GetCityForPatchAsync(ID, true);

            patchDoc.ApplyTo(Result.CityToPatch, ModelState);

            TryValidateModel(Result.CityToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _Service.CityService.SaveChangesForPatchAsync(Result.CityToPatch, Result.CityEntity);

            return NoContent();
        }


        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetCitiesOptions()
        {
            Response.Headers.Append("Allow", "GET, OPTIONS, POST, Patch, Delete");
            return Ok();
        }

    }
}

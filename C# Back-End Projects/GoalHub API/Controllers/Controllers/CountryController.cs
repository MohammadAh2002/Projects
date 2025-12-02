using Contracts.IServices;
using Controllers.ActionFilters;
using Controllers.Infrastructure;
using Entities.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.RateLimiting;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Country;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using Shared.RequestFeatures.Country;
using System.Dynamic;
using System.Text.Json;

namespace Controllers.Controllers
{
    [Route("Countries")]
    [ApiController]
    public class CountryController : ApiControllerBase
    {
        private readonly IServiceManager _Service;
        public CountryController(IServiceManager Service)
        {

            _Service = Service;

        }

        [HttpGet("{ID}", Name = "CountryByID")]
        [AllowAnonymous]
        [EnableRateLimiting("GetByIDPolicy")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCountry(short ID)
        {
            ApiBaseResponse BaseResult = await _Service.CountryService.GetCountryAsync(ID, trackChanges: false);

            if (!BaseResult.Success)
                return ProcessError(BaseResult);

            CountryDTO Country = BaseResult.GetResult<CountryDTO>();

            return Ok(Country);
        }

        [HttpGet(Name = "GetCountries")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCountries([FromQuery] CountryParameters CountryParameters)
        {

            (IEnumerable<ExpandoObject> Countries, MetaData MetaData) PagedResult = await _Service.CountryService.GetAllCountriesAsync(CountryParameters, trackChanges: false);

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(PagedResult.MetaData));

            return Ok(PagedResult.Countries);

        }

        [HttpPost(Name = "CreatedCountry")]
        [Authorize(Roles = "Administrator,Manager")]
        [ServiceFilter(typeof(ValidateNotNullIActionFilter))]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateCountry([FromBody] CountryCreationDTO Country)
        {

            CountryDTO CreatedCountry = await _Service.CountryService.CreateCountryAsync(Country);

            return CreatedAtRoute("CountryByID", new { ID = CreatedCountry.ID }, CreatedCountry);

        }

        [HttpDelete("{ID}", Name = "DeleteCountry")]
        [Authorize(Roles = "Administrator,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCountries(short ID)
        {
            await _Service.CountryService.DeleteCountryAsync(ID, trackChanges: false);

            return NoContent();
        }

        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetCountriesOptions()
        {
            Response.Headers.Append("Allow", "GET, OPTIONS, POST, Delete");
            return Ok();
        }
    }
}

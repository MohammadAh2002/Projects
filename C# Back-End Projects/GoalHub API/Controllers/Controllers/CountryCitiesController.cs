using Contracts.IServices;
using Controllers.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Country;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Controllers.Controllers
{
    [ApiController]
    [Route("Countries/{CountryID}/Cities")]
    public class CountryCitiesController : ControllerBase
    {

        private readonly IServiceManager _Service;
        public CountryCitiesController(IServiceManager Service)
        {

            _Service = Service;

        }

        [HttpPost(Name = "CreatedCountryCity")]
        [Authorize(Roles = "Administrator,Manager")]
        [ServiceFilter(typeof(ValidateNotNullIActionFilter))]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateCity(short CountryID, [FromBody] CityCreationDTO City)
        {

            CityDTO CreatedCity = await _Service.CityService.CreateCityAsync(CountryID, City, false);

            return CreatedAtRoute("CityByID", new { CreatedCity.ID }, CreatedCity);

        }

        [HttpGet(Name = "GetCountryCities")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCountryCities(short CountryID, [FromQuery] CityParameters CityParameters)
        {

            (IEnumerable<ExpandoObject> Cities, MetaData MetaData) pagedResult = await _Service.CityService.GetAllCitiesAsync(CountryID, CityParameters, trackChanges: false);

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok(pagedResult.Cities);

        }


    }
}

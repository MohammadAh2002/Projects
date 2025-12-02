using Contracts.IServices;
using Controllers.ActionFilters;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Person;

namespace Controllers.Controllers
{
    [Route("People")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IServiceManager _Service;
        public PersonController(IServiceManager Service)
        {

            _Service = Service;

        }

        [HttpPost(Name = "CreatedPerson")]
        [Authorize(Roles = "Administrator,Manager")]
        [ServiceFilter(typeof(ValidateNotNullIActionFilter))]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreatePerson([FromForm] PersonCreationDTO Person)
        {

            PersonDTO CreatedPerson = await _Service.PersonService.CreatePersonAsync(Person, false);

            return Created();

        }

        [HttpPatch("{ID:int}")]
        [Authorize(Roles = "Administrator,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> PartiallyUpdatePerson(int ID,
                                          [FromBody] JsonPatchDocument<PlayerForUpdateDTO> patchDoc)
        {

            bool Result =  await _Service.PersonService.PatchPersonAsync(ID, patchDoc);

            return Result? NoContent() : BadRequest();

        }

        [HttpPatch("{ID:int}/Photo")]
        [Authorize(Roles = "Administrator,Manager")]
        [ServiceFilter(typeof(ValidateIDActionFilter))]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePersonPhoto(int ID, IFormFile photo)
        {

            await _Service.PersonService.UpdatePersonPhotoAsync(ID, photo);

            return NoContent();

        }

        [HttpOptions]
        public IActionResult GetPersonOptions()
        {
            Response.Headers.Append("Allow", "OPTIONS, POST, Patch");
            return Ok();
        }
    }
}

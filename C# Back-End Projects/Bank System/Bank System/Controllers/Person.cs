using Business_Logic_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Layer.Controllers
{
    [Route("api/Person")]
    [ApiController]
    [RequireLoggedInUser]
    [Produces("application/json")]
    public class Person : ControllerBase
    {

        /// <summary>
        /// Find an existing Person.
        /// </summary>
        [HttpGet("Find/{ID:long}", Name = "FindPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PersonShowDTO> FindPerson(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID)
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            PersonBLL? Person = PersonBLL.Find(ID);

            if (Person == null)
                return NotFound("Person not Found");

            return Ok(Person.PSDTO);

        }

        /// <summary>
        /// Adds new Person.
        /// </summary>
        [HttpPost("Add", Name = "AddPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult AddPerson([FromForm] PersonAddDTO NewPerson)
        {

            if((DateTime.Now.Year - NewPerson.DateOfBirth.Year) < 16)
                return BadRequest("Age Must be Older Than 16");

            if (!CountryBLL.IsExist(NewPerson.CountryID))
                return BadRequest("Country dose not Exist");

            PersonBLL Person = new PersonBLL(NewPerson);

            Person.Add();

            if (Person.ID == -1)
                return NotFound("Failed to Add Person");

            return CreatedAtRoute("FindPerson", new { id = Person.ID }, Person.PDTO);

        }

        /// <summary>
        /// Update Person Info (FirstName, SecondName, ThirdName, LastName, Email, PhoneNumber, Address, Country).
        /// </summary>
        [HttpPut("Update", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdatePerson([FromForm] PersonUpdateDTO UpdatedPerson)
        {

            if (!PersonBLL.IsExist(UpdatedPerson.ID))
                return NotFound("Person Dose not Exist");

            PersonBLL Person = new PersonBLL(UpdatedPerson);

            if (Person.Update())
                return Ok("Person Updated Successfully");

            return NotFound("Failed to Update Person");

        }

        /// <summary>
        /// Delete an Existing Person.
        /// </summary>
        [HttpDelete("Delete/{ID:long}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> DeletePerson(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid");

            if (!PersonBLL.IsExist(ID))
                return NotFound("Person Dose not Exist");

            if (!PersonBLL.DeletePerson(ID))
                return NotFound("Failed to Delete Person");

            return Ok("Person Deleted Successfully");

        }

        /// <summary>
        /// Check if an Person Exists.
        /// </summary>
        [HttpGet("IsExist/{ID:long}", Name = "IsExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsExist(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid");

            if (!PersonBLL.IsExist(ID))
                return NotFound(false);

            return Ok(true);

        }

        /// <summary>
        /// Get All People.
        /// </summary>
        [HttpGet("GetAll", Name = "GetAllPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<PersonShowDTO>> GetAll()
        {

            List<PersonShowDTO> People = PersonBLL.GetAll();

            if (People == null || People.Count <= 0)
                return NotFound("No People Found");

            return Ok(People);

        }

        /// <summary>
        /// Get All Deleted People.
        /// </summary>
        [HttpGet("GetAllDeleted", Name = "GetAllDeletedPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<PersonShowDTO>> GetAllDeleted()
        {

            List<PersonShowDTO> People = PersonBLL.GetAllDeleted();

            if (People == null || People.Count <= 0)
                return NotFound("No People Found");

            return Ok(People);

        }

    }
}

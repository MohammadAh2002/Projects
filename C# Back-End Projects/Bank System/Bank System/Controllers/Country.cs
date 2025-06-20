using Business_Logic_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace API_Layer.Controllers
{
    [Route("api/Country")]
    [RequireLoggedInUser]
    [ApiController]
    [Produces("application/json")]
    public class Country : ControllerBase
    {
        /// <summary>
        /// Find an existing Country By ID.
        /// </summary>
        [HttpGet("FindCountryByID/{ID:long}", Name = "FindCountryByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CountryDTO> FindCountryByID(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            CountryBLL? Country = CountryBLL.Find(ID);

            if (Country == null)
                return NotFound("Country not Found");

            return Ok(Country.CDTO);

        }

        /// <summary>
        /// Find an existing Country By Name.
        /// </summary>
        [HttpGet("FindCountryByName/{Name}", Name = "FindCountryByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CountryDTO> FindCountryByName(
               [StringLength(100, MinimumLength = 1, ErrorMessage = "Country Name must be between 1 and 100 characters.")] string Name
            )
        {

            if (string.IsNullOrEmpty(Name) || Name.Length > 100)
                return BadRequest("Name Cannot be Empty or More than 100 character");

            CountryBLL? Country = CountryBLL.Find(Name);

            if (Country == null)
                return NotFound("Country not Found");

            return Ok(Country.CDTO);

        }

        /// <summary>
        /// Add New Country.
        /// </summary>
        [HttpPost("Add/{Name}", Name = "AddCountry")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Add(
               [StringLength(100, MinimumLength = 1, ErrorMessage = "Country Name must be between 1 and 100 characters.")] string Name
            )
        {

            if (string.IsNullOrEmpty(Name) || Name.Length > 100)
                return BadRequest("Name Cannot be Empty or More than 100 character");

            if( CountryBLL.IsExist(Name))
                return BadRequest("Country Already Exists");

            CountryBLL Country = new CountryBLL(Name);

            Country.Add();

            if (Country.ID == -1)
                return NotFound("Failed to Add Country");

            return CreatedAtRoute("FindCountryByID", new { id = Country.ID }, Country.CDTO);

        }

        /// <summary>
        /// Update the Name of an Existing Country.
        /// </summary>
        [HttpPut("Update", Name = "Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update([FromForm] CountryDTO CountryDTO)
        {
            if (CountryDTO.ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (string.IsNullOrEmpty(CountryDTO.Name) || CountryDTO.Name.Length > 100)
                return BadRequest("Name Cannot be Empty or More than 100 character");

            if (!CountryBLL.IsExist(CountryDTO.ID))
                return NotFound("Country Dose not Exist");

            if (CountryBLL.IsExist(CountryDTO.Name))
                return BadRequest("Country New Name Already Exists");

            CountryBLL Country = new CountryBLL(CountryDTO);

            if (!Country.Update())
                return NotFound("Failed to Update Country");

            return Ok("Country Updates Successfully");

        }

        /// <summary>
        /// Get all Existing Countries.
        /// </summary>
        [HttpGet("GetAll", Name = "GetAllCountries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CountryDTO>?> GetAllCountries()
        {

            List<CountryDTO>? Countries = CountryBLL.GetAllCountries();

            if (Countries == null || Countries.Count <= 0)
                return NotFound("No Country Found");

            return Ok(Countries);

        }

        /// <summary>
        /// Delete an Existing Country By ID.
        /// </summary>
        [HttpDelete("DeleteByID/{ID:long}", Name = "DeleteByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteByID(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!CountryBLL.IsExist(ID))
                return NotFound("Country Dose not Exist");

            if (CountryBLL.Delete(ID))
                return Ok("Country Delete Successfully");

            return NotFound("Failed to Delete Country");
        }

        /// <summary>
        /// Delete an Existing Country By Name.
        /// </summary>
        [HttpDelete("DeleteByName/{Name}", Name = "DeleteByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteByName(
               [StringLength(100, MinimumLength = 1, ErrorMessage = "Country Name must be between 1 and 100 characters.")] string Name
            )
        {

            if (string.IsNullOrEmpty(Name) || Name.Length > 100)
                return BadRequest("Name Cannot be Empty or More than 100 character");

            if (!CountryBLL.IsExist(Name))
                return NotFound("Country Dose not Exist");

            if (CountryBLL.Delete(Name))
                return Ok("Country Delete Successfully");

            return NotFound("Failed to Delete Country");

        }

        /// <summary>
        /// Check if an Country Exists By ID.
        /// </summary>
        [HttpGet("IsExistByID/{ID:long}", Name = "IsCountryExistByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult IsExistByID(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (CountryBLL.IsExist(ID))
                return Ok(true);

            return NotFound(false);
        }


        /// <summary>
        /// Check if an Country Exists By Name.
        /// </summary>
        [HttpGet("IsExistByName/{Name}", Name = "IsCountryExistByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult IsExistByName(
               [StringLength(100, MinimumLength = 1, ErrorMessage = "Country Name must be between 1 and 100 characters.")] string Name
            )
        {

            if (string.IsNullOrEmpty(Name) || Name.Length > 100)
                return BadRequest("Name Cannot be Empty or More than 100 character");

            if (CountryBLL.IsExist(Name))
                return Ok(true);

            return NotFound(false);

        }

        /// <summary>
        /// Get All Countries With Details.
        /// </summary>
        [HttpGet("CountriesDetails", Name = "CountriesDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CountryDetails>?> CountriesDetails()
        {

            List<CountryDetails>? CountriesDetailsList = CountryBLL.CountriesDetails();

            if (CountriesDetailsList == null || CountriesDetailsList.Count <= 0)
                return NotFound("no Countries Found");

            return Ok(CountriesDetailsList);

        }

        /// <summary>
        /// Get Specific Country Details.
        /// </summary>
        [HttpGet("CountryDetails/{ID:long}", Name = "CountryDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CountryDetails>? CountryDetails(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {
            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!CountryBLL.IsExist(ID))
                return NotFound("Country Dose not Exist");

            CountryDetails? CountryDetails = CountryBLL.CountryDetails(ID);

            if (CountryDetails == null)
                return NotFound("Country not Found");

            return Ok(CountryDetails);

        }

    }
}

using Business_Logic_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Layer.Controllers
{
    [Route("api/AccountStatuses")]
    [ApiController]
    [RequireLoggedInUser]
    [Produces("application/json")]
    public class AccountStatuses : ControllerBase
    {
        /// <summary>
        /// Find an existing Account Statuses By ID.
        /// </summary>
        [HttpGet("FindByID/{ID:long}", Name = "FindAccountStatusByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AccountStatusesDTO> Find(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            AccountStatusesBLL? AccountStatus = AccountStatusesBLL.Find(ID);

            if (AccountStatus == null)
                return NotFound("Account Status Type not Found");

            return Ok(AccountStatus.ASDTO);

        }

        /// <summary>
        /// Find an existing Account Statuses By Name.
        /// </summary>
        [HttpGet("FindByName/{Name}", Name = "FindAccountStatusByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AccountStatusesDTO> Find(
               [StringLength(30, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters.")] string Name
            )
        {

            if (string.IsNullOrEmpty(Name) || Name.Length > 50)
                return BadRequest("Name Cannot be Empty or More Than 50 character");

            AccountStatusesBLL? AccountStatus = AccountStatusesBLL.Find(Name);

            if (AccountStatus == null)
                return NotFound("Account Status Type not Found");

            return Ok(AccountStatus.ASDTO);

        }

        /// <summary>
        /// Adds a new Account Status.
        /// </summary>
        [HttpPost("Add", Name = "AddAccountStatus")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Add([FromForm] AccountStatusesAddDTO AccountStatusDTO)
        {

            AccountStatusesBLL AccountStatus = new AccountStatusesBLL(AccountStatusDTO);

            AccountStatus.Add();

            if (AccountStatus.ID == 0)
                return NotFound("Failed to Add Account Status");

            return CreatedAtRoute("FindAccountStatusByID", new { AccountStatus.ID }, AccountStatus.ASDTO);

        }

        /// <summary>
        /// Update the Description of an Existing Account Status.
        /// </summary>
        [HttpPut("UpdateDescription/{ID:long}/{Description}", Name = "UpdateAccountStatusDescription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateDescription(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID,
             [StringLength(300, ErrorMessage = "Description must be Less Than 300 characters.")] string Description
            )
        {

            if (string.IsNullOrEmpty(Description) || Description.Length > 300)
                return BadRequest("Description Cannot be Empty or More than 300 character");

            AccountStatusesBLL? AccountStatus = AccountStatusesBLL.Find(ID);

            if (AccountStatus == null)
                return NotFound("Account Status not Found");

            AccountStatus.Description = Description;

            if (!AccountStatus.UpdateDescription())
                return NotFound("Failed to Update Account Status Description");

            return Ok("Account Status Description Updated Successfully");

        }

        /// <summary>
        /// Delete an Existing Account Status.
        /// </summary>
        [HttpDelete("Delete/{ID:long}", Name = "DeleteAccountStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!AccountStatusesBLL.IsExist(ID))
                return Ok("Account Status Dose not Exist to Delete it.");

            if (AccountStatusesBLL.Delete(ID))
                return Ok("Account Status Deleted Successfully");

            return NotFound("Failed to Delete Account Status");

        }

        /// <summary>
        /// Check if an Account Status Exists by ID.
        /// </summary>
        [HttpGet("IsExist/{ID:long}", Name = "IsExistAccountStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult IsExist(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (AccountStatusesBLL.IsExist(ID))
                return Ok(true);

            return NotFound(false);

        }

        /// <summary>
        /// Get all Account Statuses.
        /// </summary>
        [HttpGet("All", Name = "GetAllAccountStatuses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<AccountStatusesDTO>?> GetAll()
        {

            List<AccountStatusesDTO>? AccountStatusesList = AccountStatusesBLL.GetAll();

            if (AccountStatusesList == null || AccountStatusesList.Count <= 0)
                return NotFound("no Account Statuses Type Found");

            return Ok(AccountStatusesList);

        }
    }
}

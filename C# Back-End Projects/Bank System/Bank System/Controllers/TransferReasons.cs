using Business_Logic_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Layer.Controllers
{
    [Route("api/TransferReasons")]
    [ApiController]
    [RequireLoggedInUser]
    [Produces("application/json")]
    public class TransferReasons : ControllerBase
    {

        /// <summary>
        /// Find an existing Transfer Reasons By ID.
        /// </summary>
        [HttpGet("FindByID/{ID:long}", Name = "FindTransferReasonsByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TransferReasonDTO> Find(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            TransferReasonBLL? TransferReason = TransferReasonBLL.Find(ID);

            if (TransferReason == null)
                return NotFound("Transfer Reasons not Found");

            return Ok(TransferReason.TRDTO);

        }

        /// <summary>
        /// Find an existing Transfer Reasons By Name.
        /// </summary>
        [HttpGet("FindByName/{Name}", Name = "FindTransferReasonsByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TransferReasonDTO> Find(
            [StringLength(50, MinimumLength = 1, ErrorMessage = "Transfer Reason Name must be between 1 and 50 characters.")] string Name)
        {

            if (string.IsNullOrEmpty(Name) || Name.Length > 50)
                return BadRequest("Name Cannot be Empty or More Than 50 character");

            TransferReasonBLL? TransferReason = TransferReasonBLL.Find(Name);

            if (TransferReason == null)
                return NotFound("Transfer Reasons not Found");

            return Ok(TransferReason.TRDTO);

        }

        /// <summary>
        /// Adds a new Transfer Reason.
        /// </summary>
        [HttpPost("Add", Name = "AddTransferReason")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Add([FromForm] TransferReasonAddDTO TransferReasonDTO)
        {

            TransferReasonBLL? TransferReason = new TransferReasonBLL(TransferReasonDTO);

            TransferReason.Add();

            if (TransferReason.ID == 0)
                return NotFound("Failed to Add Transfer Reason");

            return CreatedAtRoute("FindTransferReasonsByID", new { TransferReason.ID }, TransferReason.TRDTO);

        }

        /// <summary>
        /// Update the Description of an Existing Transfer Reason.
        /// </summary>
        [HttpPut("UpdateDescription/{ID:long}/{Description}", Name = "UpdateTransferReasonDescription")]
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

            TransferReasonBLL? TransferReason = TransferReasonBLL.Find(ID);

            if (TransferReason == null)
                return NotFound("no Transfer Reason Found to Update");

            if (!TransferReason.UpdateDescription(Description))
                return NotFound("Failed to Update Transfer Reason Description");

            return Ok("Transfer Reason Description Updated Successfully");

        }

        /// <summary>
        /// Delete an Existing Transfer Reason.
        /// </summary>
        [HttpDelete("Delete/{ID:long}", Name = "DeleteTransferReason")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!TransferReasonBLL.IsExist(ID))
                return Ok("Transfer Reason Dose not Exist to Delete it.");

            if (TransferReasonBLL.Delete(ID))
                return Ok("Transfer Reason Deleted Successfully");

            return NotFound("Failed to Delete Transfer Reason");

        }

        /// <summary>
        /// Check if an Transfer Reason Exists.
        /// </summary>
        [HttpGet("IsExist/{ID:long}", Name = "IsExistTransferReason")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult IsExist(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (TransferReasonBLL.IsExist(ID))
                return Ok(true);

            return NotFound(false);

        }

        /// <summary>
        /// Get all Transfer Reasons.
        /// </summary>
        [HttpGet("All", Name = "GetAllTransferReasons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<TransferReasonDTO>?> GetAll()
        {

            List<TransferReasonDTO>? AccountStatusesList = TransferReasonBLL.GetAll();

            if (AccountStatusesList == null || AccountStatusesList.Count <= 0)
                return NotFound("no Transfer Reasons Found");

            return Ok(AccountStatusesList);

        }

    }
}

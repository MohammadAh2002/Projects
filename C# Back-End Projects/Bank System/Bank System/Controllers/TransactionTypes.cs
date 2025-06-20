using Business_Logic_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static DTO_Layer.TransactionTypeDTO;

namespace API_Layer.Controllers
{
    [Route("api/TransactionTypes")]
    [ApiController]
    [RequireLoggedInUser]
    [Produces("application/json")]
    public class TransactionTypes : ControllerBase
    {

        /// <summary>
        /// Find an existing Transaction Type By ID.
        /// </summary>
        [HttpGet("FindByID/{ID:long}", Name = "FindTransactionTypeByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TransactionTypeDTO> Find(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID)
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            TransactionTypesBLL? TransactionType = TransactionTypesBLL.Find(ID);

            if (TransactionType == null)
                return NotFound("Transaction Type not Found");

            return Ok(TransactionType.TTDTO);

        }

        /// <summary>
        /// Find an existing Transaction Type By Name.
        /// </summary>
        [HttpGet("FindByName/{Name}", Name = "FindTransactionTypeByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TransactionTypeDTO> Find(
               [StringLength(30, MinimumLength = 1, ErrorMessage = "Transaction Name must be between 1 and 30 characters.")] string Name
            )
        {

            if (string.IsNullOrEmpty(Name) || Name.Length > 30)
                return BadRequest("Name Cannot be Empty or More Than 30 character");

            TransactionTypesBLL? TransactionType = TransactionTypesBLL.Find(Name);

            if (TransactionType == null)
                return NotFound("Transaction Type not Found");

            return Ok(TransactionType.TTDTO);

        }

        /// <summary>
        /// Adds a new Transaction Type.
        /// </summary>
        [HttpPost("Add", Name = "AddTransactionType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Add([FromForm] TransactionTypeAddDTO TransactionTypeDTO)
        {

            TransactionTypesBLL TransactionType = new TransactionTypesBLL(TransactionTypeDTO);

            TransactionType.Add();

            if (TransactionType.ID == 0)
                return NotFound("Failed to Add TransactionType");

            return CreatedAtRoute("FindTransactionTypeByID", new { TransactionType.ID }, TransactionType.TTDTO);

        }

        /// <summary>
        /// Update the Description of an Existing Transaction Type.
        /// </summary>
        [HttpPut("UpdateDescription/{ID:long}/{Description}", Name = "UpdateTransactionTypeDescription")]
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

            TransactionTypesBLL? TransactionType = TransactionTypesBLL.Find(ID);

            if (TransactionType == null)
                return NotFound("no Transaction Type Found to Update");

            TransactionType.Description = Description;

            if (!TransactionType.UpdateDescription(Description))
                return NotFound("Failed to Update Transaction Type Description");

            return Ok("Transaction Type Description Updated Successfully");

        }

        /// <summary>
        /// Delete an Existing Transaction Type.
        /// </summary>
        [HttpDelete("Delete/{ID:long}", Name = "DeleteTransactionType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!TransactionTypesBLL.IsExist(ID))
                return Ok("Transaction Type Dose not Exist to Delete it.");

            if (TransactionTypesBLL.Delete(ID))
                return Ok("Transaction Type Deleted Successfully");

            return NotFound("Failed to Delete Transaction Type");

        }

        /// <summary>
        /// Check if an Transaction Type Exists by ID.
        /// </summary>
        [HttpGet("IsExist/{ID:long}", Name = "IsExistTransactionType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult IsExist(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (TransactionTypesBLL.IsExist(ID))
                return Ok(true);

            return NotFound(false);

        }

        /// <summary>
        /// Get all Transaction Types.
        /// </summary>
        [HttpGet("All", Name = "GetAllTransactionTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<TransactionTypeDTO>> GetAll()
        {

            List<TransactionTypeDTO> TransactionType = TransactionTypesBLL.GetAll();

            if (TransactionType == null || TransactionType.Count <= 0)
                return NotFound("no Transaction Type Found");

            return Ok(TransactionType);

        }


    }
}

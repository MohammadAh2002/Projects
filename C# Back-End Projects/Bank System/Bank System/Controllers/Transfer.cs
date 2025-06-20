using Business_Logic_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Layer.Controllers
{
    [Route("api/Transfer")]
    [ApiController]
    [Produces("application/json")]
    [RequireLoggedInUser]
    public class Transfer : ControllerBase
    {

        /// <summary>
        /// Transfers Money from One Account to Another.
        /// </summary>
        [HttpPut("Transfer", Name = "Transfer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult TransferMoney([FromForm] TransferDTO TransferDTO)
        {

            if (TransferDTO.Amount <= 0)
                return BadRequest("the Deposit Amount Can't be Less or Equal than 0");
            
            if (TransferDTO.DestinationAccountID < 1 || TransferDTO.SourceAccountID < 1)
                return BadRequest("the Accounts IDs is not Valid Must Be Bigger than 0");

            if (!AccountBLL.IsExist(TransferDTO.DestinationAccountID) || !AccountBLL.IsExist(TransferDTO.SourceAccountID))
                return NotFound("One of the Accounts not Found");

            if (!TransferBLL.Transfer(TransferDTO))
                return NotFound("Failed to Transfer Money");

            return Ok("Transfer Done Successfully");

        }

        /// <summary>
        /// Get All Transfers History for Specific Account. 
        /// </summary>
        [HttpGet("AccountTransfersHistory/{AccountID:long}", Name = "AccountTransfersHistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<TransferShowDTO>?> AccountTransfersHistory(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long AccountID
            )
        {
            if (AccountID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!AccountBLL.IsExist(AccountID))
                return NotFound("Account not Found");

            List<TransferShowDTO>? Transfers = TransferBLL.AccountTransfersHistory(AccountID);

            if (Transfers == null || Transfers.Count <= 0)
                return NotFound("No Transfers Found to this Account");

            return Ok(Transfers);

        }
    }
}

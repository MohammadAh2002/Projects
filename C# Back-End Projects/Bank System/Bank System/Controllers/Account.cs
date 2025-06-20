using Business_Logic_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static Business_Logic_Layer.TransactionBLL;

namespace API_Layer.Controllers
{
    [Route("api/Account")]
    [RequireLoggedInUser]
    [ApiController]
    [Produces("application/json")]
    public class Account : ControllerBase
    {

        /// <summary>
        /// Find an existing Account.
        /// </summary>
        [HttpGet("Find/{ID:long}", Name = "FindAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AccountShowDTO> FindAccount(
                [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            AccountBLL? Account = AccountBLL.Find(ID);

            if (Account == null || Account.Customer == null)
                return NotFound("Account not Found");

            return Ok(Account.ADTO);

        }

        /// <summary>
        /// Adds new account for an existing customer.
        /// </summary>
        [HttpPost("Add", Name = "AddAccount")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult AddAccount([FromForm] AccountAddDTO AccountDTO)
        {

            if(AccountDTO.Balance < 0)
                return BadRequest("Balance Must Be Greater or Equal 0");

            if (!CustomerBLL.IsExist(AccountDTO.CustomerID))
                return NotFound("Customer Dose not Exist");

            AccountBLL Account = new AccountBLL(AccountDTO);

            if (Account.Add())
                return CreatedAtRoute("FindAccount", new { Account.ID }, Account.ADTO);

            return NotFound("Failed to Add Account");

        }

        /// <summary>
        /// Open Account, Change Account Status From Closed or Suspended to Opened.
        /// </summary>
        [HttpPatch("Open/{ID:long}", Name = "OpenAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult OpenAccount(
                [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if(!AccountBLL.IsClosed(ID))
                return BadRequest("You Can't Open Closed Account onlu Suspended");

            if (AccountBLL.Open(ID))
                return Ok("Account Opened Successfully");

            return NotFound("Failed to Open Account");

        }

        /// <summary>
        /// Close Account, Change Account Status to Closed.
        /// </summary>
        [HttpPatch("Close/{ID:long}", Name = "CloseAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CloseAccount(
                [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if(!AccountBLL.IsExist(ID))
                return NotFound("Account not Found");


            if (AccountBLL.Close(ID))
                return Ok("Account Closed Successfully");

            return NotFound("Failed to Close Account");

        }

        /// <summary>
        /// Suspend Account, Change Account Status to Suspend.
        /// </summary>
        [HttpPatch("Suspend/{ID:long}", Name = "SuspendAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult SuspendAccount(
                [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!AccountBLL.IsExist(ID))
                return NotFound("Account not Found");

            if (AccountBLL.Suspend(ID))
                return Ok("Account Suspended Successfully");

            return NotFound("Failed to Suspend Account");

        }

        /// <summary>
        /// Delete an Existing Account.
        /// </summary>
        [HttpDelete("Delete/{ID:long}", Name = "DeleteAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteAccount(
                [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {
            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!AccountBLL.IsExist(ID))
                return NotFound("Account Dose not Exist");

            if (AccountBLL.Delete(ID))
                return Ok("Account Deleted Successfully");

            return NotFound("Failed to Delete Account");

        }

        /// <summary>
        /// Check if an Account Exists.
        /// </summary>
        [HttpGet("IsExist/{ID:long}", Name = "IsAccountExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult IsAccountExist(
                [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (AccountBLL.IsExist(ID))
                return Ok(true);

            return NotFound(false);

        }

        /// <summary>
        /// Get all Existing Accounts.
        /// </summary>
        [HttpGet("All", Name = "GetAllAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<AccountShowDTO>?> GetAllAccounts()
        {
            List<AccountShowDTO>? AccountsList = AccountBLL.GetAll();

            if (AccountsList == null || AccountsList.Count <= 0)
                return NotFound("No Accounts Found");

            return Ok(AccountsList);

        }

        /// <summary>
        /// Get All Accounts for a Specific Customer.
        /// </summary>
        [HttpGet("CustomerAllAccounts/{CustomerID:long}", Name = "GetCustomerAllAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<AccountShowDTO>?> CustomerAllAccounts(
                [Range(1, long.MaxValue, ErrorMessage = "Customer ID must be greater than 0")] long CustomerID
            )
        {
            if (CustomerID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if(!CustomerBLL.IsExist(CustomerID))
                return NotFound("Customer not Found");

            List<AccountShowDTO>? AccountsList = AccountBLL.CustomerAllAccounts(CustomerID);

            if (AccountsList == null || AccountsList.Count == 0)
                return NotFound("No Accounts Found For Customer");

            return Ok(AccountsList);

        }

        /// <summary>
        /// Do Transaction on an Account (Deposit = 1, Withdrawal = 2, Overdraft = 3).
        /// </summary>
        [HttpPut("Transact", Name = "Transact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Transact(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long AccountID,
            [DataType(DataType.Currency)] [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")] decimal Amount,
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long TransactionTypeID)
        {

            if (AccountID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");
                
            AccountBLL? Account = AccountBLL.Find(AccountID);

            if (Account == null)
                return NotFound("Account not Found");

            if (Account.Balance < Amount && TransactionTypeID == (long)enTransactionType.Withdrawal)
                return BadRequest("You can't Withdrawal More than Your Balance");

            if (Account.Transact(Amount, TransactionTypeID))
                return Ok("Transaction Done Successfully");

            return NotFound("Failed to do Transaction");

        }       

    }
}

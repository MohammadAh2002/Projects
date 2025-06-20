using Business_Logic_Layer;
using Data_Access_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static Business_Logic_Layer.TransactionBLL;

namespace API_Layer.Controllers
{
    [Route("api/Transaction")]
    [RequireLoggedInUser]
    [ApiController]
    [Produces("application/json")]
    public class Transaction : ControllerBase
    {

        /// <summary>
        /// Deposits Money into an Account.
        /// </summary>
        [HttpPut("Deposit", Name = "Deposit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Deposit(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long AccountID,
            [DataType(DataType.Currency)][Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")] decimal Amount)
        {

            if (AccountID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (Amount < 1)
                return BadRequest("the Deposit Amount Can't be Less than 1");

            if (!AccountBLL.IsExist(AccountID))
                return NotFound("Account not Found");

            TransactionDTO Transaction = new TransactionDTO(AccountID, (byte)enTransactionType.Deposit, Amount, DateTime.Now);

            if (TransactionBLL.Transact(Transaction))
                return Ok("Deposit Done Successfully");

            return NotFound("Failed to do Deposit");

        }

        /// <summary>
        /// Withdraws Money from an Account.
        /// </summary>
        [HttpPut("Withdrawal", Name = "Withdrawal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Withdrawal(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long AccountID,
            [DataType(DataType.Currency)][Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")] decimal Amount)

        {

            if (AccountID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            AccountBLL? Account = AccountBLL.Find(AccountID);

            if (Account == null)
                return NotFound("Account not Found");

            if(Account.Balance < Amount)
                return BadRequest("You can't Withdrawal More than Your Balance");

            TransactionDTO Transaction = new TransactionDTO(AccountID, (byte)enTransactionType.Withdrawal, Amount, DateTime.Now);

            if (TransactionBLL.Transact(Transaction))
                return Ok("Withdrawal Done Successfully");

            return NotFound("Failed to do Withdrawal");
        }

        /// <summary>
        /// Withdraws money from an account, allowing the balance to go negative.
        /// </summary>
        [HttpPut("Overdraft", Name = "Overdraft")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Overdraft(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long AccountID,
            [DataType(DataType.Currency)][Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")] decimal Amount)
        {

            if (AccountID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!AccountBLL.IsExist(AccountID))
                return NotFound("Account not Found");

            TransactionDTO Transaction = new TransactionDTO(AccountID, (byte)enTransactionType.Overdraft, Amount, DateTime.Now);

            if (TransactionBLL.Transact(Transaction))
                return Ok("Overdraft Done Successfully");

            return NotFound("Failed to do Overdraft");
        }

        /// <summary>
        /// Get All Transactions History for a Specific Account.
        /// </summary>
        [HttpGet("AccountTransactionsHistory/{AccountID:long}", Name = "AccountTransactionsHistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<TransactionDTO>?> AccountTransactionsHistory(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long AccountID
            )
        {
            if (AccountID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!AccountBLL.IsExist(AccountID))
                return NotFound("Account not Found");

            List<TransactionDTO>? Transactions = TransactionBLL.AccountTransactionsHistory(AccountID);

            if (Transactions == null || Transactions.Count <= 0)
                return NotFound("No Transactions Found to this Account");

            return Ok(Transactions);

        }
    }
}

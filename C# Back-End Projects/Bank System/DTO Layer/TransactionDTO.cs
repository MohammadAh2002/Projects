
using System.ComponentModel.DataAnnotations;

namespace DTO_Layer
{
    public class TransactionDTO
    {
        [Required(ErrorMessage = "Account ID is required.")]
        public long AccountID { get; set; }

        [Required(ErrorMessage = "Transaction Type is required.")]
        public long TransactionTypeID { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Hire Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        DateTime TransactionDate;

        public TransactionDTO(long AccountID, long TransactionTypeID, decimal Amount, DateTime TransactionDate)
        {
            this.AccountID = AccountID;
            this.TransactionTypeID = TransactionTypeID;
            this.Amount = Amount;
            this.TransactionDate = TransactionDate;
        }
        public TransactionDTO() { }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DTO_Layer
{
    public class TransferDTO
    {
        [Required(ErrorMessage = "Source Account ID is required.")]
        public long SourceAccountID { get; set; }

        [Required(ErrorMessage = "Destination Account ID is required.")]
        public long DestinationAccountID { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Transfer Reason ID is required.")]
        public long TransferReasonID { get; set; }

        public TransferDTO(long sourceAccountID, long destinationAccountID,
                           decimal amount, long transferReasonID)
        {
            SourceAccountID = sourceAccountID;
            DestinationAccountID = destinationAccountID;
            Amount = amount;
            TransferReasonID = transferReasonID;
        }

        public TransferDTO() { }
    }

    public class TransferShowDTO
    {

        public long SourceAccountID { get; set; }

        public long DestinationAccountID { get; set; }

        public decimal Amount { get; set; }

        public long TransferReasonID { get; set; }

        DateTime TransferDate { get; set; }

        public TransferShowDTO(long sourceAccountID, long destinationAccountID,
                           decimal amount, long transferReasonID, DateTime transferDate)
        {
            SourceAccountID = sourceAccountID;
            DestinationAccountID = destinationAccountID;
            Amount = amount;
            TransferReasonID = transferReasonID;
            TransferDate = transferDate;
        }

    }
}

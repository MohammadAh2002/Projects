using System.ComponentModel.DataAnnotations;

namespace DTO_Layer
{
    public class AccountDTO
    {
        
        public long ID { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public long StatusID { get; set; }
        public long CustomerID { get; set; }

        public AccountDTO(long iD, decimal balance, DateTime dateOpened,
                          DateTime? dateClosed, long statusID, long customerID)
        {
            ID = iD;
            Balance = balance;
            DateOpened = dateOpened;
            DateClosed = dateClosed;
            StatusID = statusID;
            CustomerID = customerID;
        }
    }

    public class AccountAddDTO
    {

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Balance is required.")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Customer ID must be a non-negative number.")]
        public long CustomerID { get; set; }

        public AccountAddDTO(decimal balance, long customerID)
        {
            Balance = balance;
            CustomerID = customerID;
        }
        public AccountAddDTO() { }
    }

    public class AccountShowDTO
    {
        public long ID { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        
        public long StatusID { get; set; }

        public string CustomerName { get; set; }

        public AccountShowDTO(long iD, decimal balance, DateTime dateOpened,
                          DateTime? dateClosed, long statusID, string customerName)
        {
            ID = iD;
            Balance = balance;
            DateOpened = dateOpened;
            DateClosed = dateClosed;
            StatusID = statusID;
            CustomerName = customerName;
        }
    }

}

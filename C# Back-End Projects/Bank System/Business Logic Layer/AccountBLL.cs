using Data_Access_Layer;
using DTO_Layer;

namespace Business_Logic_Layer
{
    public class AccountBLL
    {

        public enum enStatus { Open = 1, Suspended = 2, Closed = 3, Pending = 4 }

        public long ID {  get; set; }
        public decimal Balance { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public enStatus Status { get; set; }
        public CustomerBLL? Customer { get; set; }

        AccountBLL(AccountDTO AccountDTO)
        {
            ID = AccountDTO.ID;
            Balance = AccountDTO.Balance;
            DateOpened = AccountDTO.DateOpened;
            DateClosed = AccountDTO.DateClosed;
            
            Status = (enStatus)AccountDTO.StatusID;
            Customer = CustomerBLL.Find(AccountDTO.CustomerID);

        }
        public AccountBLL(AccountAddDTO AccountDTO)
        {
            ID = -1;
            Balance = AccountDTO.Balance;
            DateOpened = DateTime.Now;
            DateClosed = null;

            Status = enStatus.Open;
            Customer = CustomerBLL.Find(AccountDTO.CustomerID);

        }
        public AccountBLL(long CustomerID, decimal Balance)
        {
            ID = -1;
            this.Balance = Balance;
            DateOpened = DateTime.Now;
            DateClosed = null;

            Status = enStatus.Open;
            Customer = CustomerBLL.Find(CustomerID);

        }

        public AccountDTO ADTO {
            get {
                return new AccountDTO(ID, Balance, DateOpened, DateClosed,
                                     (long)Status, Customer.ID);
            } 
        }
        public AccountShowDTO ASDTO
        {
            get
            {
                return new AccountShowDTO(ID, Balance, DateOpened, DateClosed,
                                     (long)Status, Customer.Person.FullName);
            }
        }

        public static AccountBLL? Find(long ID)
        {

            AccountDTO? Account = AccountDAL.Find(ID);

            if (Account == null)
                return null;

            return new AccountBLL(Account);

        }

        public static decimal AccountBalance(long ID)
        {
            return AccountDAL.AccountBalance(ID);
        }

        public bool Add()
        {

            ID = AccountDAL.Add(ADTO);

            return ID != -1;

        }

        public bool Open()
        {
            return AccountDAL.Open(ID);
        }
        public static bool Open(long ID)
        {
            return AccountDAL.Open(ID);
        }

        public bool Close()
        {
            return AccountDAL.Close(ID);
        }
        public static bool Close(long ID)
        {
            return AccountDAL.Close(ID);
        }

        public static bool IsClosed(long ID)
        {
            return AccountDAL.IsClosed(ID);

        }
        public bool IsClosed()
        {
            return IsClosed(ID);
        }

        public bool Suspend()
        {
            return AccountDAL.Suspend(ID);
        }
        public static bool Suspend(long ID)
        {
            return AccountDAL.Suspend(ID);
        }

        public bool Delete()
        {
            return Delete(ID);
        }
        public static bool Delete(long ID)
        {
            return AccountDAL.Delete(ID);
        }

        public bool IsExist()
        {
            return IsExist(ID);
        }
        public static bool IsExist(long ID)
        {
            return AccountDAL.IsExist(ID);

        }

        public static List<AccountShowDTO> GetAll()
        {
            return AccountDAL.GetAll();
        }

        public static List<AccountShowDTO> CustomerAllAccounts(long CustomerID)
        {
            return AccountDAL.CustomerAllAccounts(CustomerID);
        }

        public List<TransactionDTO>? AccountTransactionsHistory()
        {
            return TransactionDAL.AccountTransactionsHistory(ID);
        }

        public bool Transact(decimal Amount, long TransactionTypeID)
        {
            return TransactionBLL.Transact(new TransactionDTO(ID, TransactionTypeID, Amount, DateTime.Now));
        }

        public List<TransferShowDTO>? Transfer()
        {
            return TransferDAL.AccountTransfersHistory(ID);
        }

    }
}

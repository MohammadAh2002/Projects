using Data_Access_Layer;
using DTO_Layer;

namespace Business_Logic_Layer
{
    public class TransactionBLL
    {
        public enum enTransactionType { Deposit = 1, Withdrawal = 2, Overdraft = 3 }

        public static bool Transact(TransactionDTO TransactionDTO)
        {
            switch ((enTransactionType)TransactionDTO.TransactionTypeID)
            {
                case enTransactionType.Deposit:
                    return Deposit(TransactionDTO.AccountID, TransactionDTO.Amount);

                case enTransactionType.Withdrawal:
                    return Withdrawal(TransactionDTO.AccountID, TransactionDTO.Amount);

                case enTransactionType.Overdraft:
                    return Overdraft(TransactionDTO.AccountID, TransactionDTO.Amount);
            }

            return false;
        }
        private static bool Withdrawal(long AccountID, decimal Amount)
        {                   
            return TransactionDAL.Withdrawal(AccountID,  Amount);
        }
        private static bool Deposit(long AccountID, decimal Amount)
        {
            return TransactionDAL.Deposit(AccountID, Amount);
        }
        private static bool Overdraft(long AccountID, decimal Amount)
        {
            return TransactionDAL.Overdraft(AccountID, Amount);
        }

        public static List<TransactionDTO>? AccountTransactionsHistory(long AccountID)
        {
            return TransactionDAL.AccountTransactionsHistory(AccountID);
        }







    }
}

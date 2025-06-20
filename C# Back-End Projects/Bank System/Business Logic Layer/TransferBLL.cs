using Data_Access_Layer;
using DTO_Layer;

namespace Business_Logic_Layer
{
    public class TransferBLL
    {

        public static bool Transfer(TransferDTO TransferDTO)
        {
            return TransferDAL.Transfer(TransferDTO);
        }

        public static List<TransferShowDTO>? AccountTransfersHistory(long AccountID)
        {
            return TransferDAL.AccountTransfersHistory(AccountID);
        }
    }
}

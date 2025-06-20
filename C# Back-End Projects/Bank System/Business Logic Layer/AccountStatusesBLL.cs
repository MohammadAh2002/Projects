using Data_Access_Layer;
using DTO_Layer;

namespace Business_Logic_Layer
{
    public class AccountStatusesBLL
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public AccountStatusesBLL(AccountStatusesDTO TransactionTypeDTO)
        {

            ID = TransactionTypeDTO.ID;
            Name = TransactionTypeDTO.Name;
            Description = TransactionTypeDTO.Description;

        }
        public AccountStatusesBLL(AccountStatusesAddDTO TransactionTypeDTO)
        {

            ID = 0;
            Name = TransactionTypeDTO.Name;
            Description = TransactionTypeDTO.Description;

        }

        public AccountStatusesDTO ASDTO
        {
            get
            {
                return new AccountStatusesDTO(ID, Name, Description);
            }
        }
        public AccountStatusesAddDTO ASADTO
        {
            get
            {
                return new AccountStatusesAddDTO(Name, Description);
            }
        }

        public static AccountStatusesBLL? Find(long ID)
        {

            AccountStatusesDTO? AccountStatusesDTO = AccountStatusesDAL.Find(ID);

            if (AccountStatusesDTO == null)
                return null;

            return new AccountStatusesBLL(AccountStatusesDTO);

        }

        public static AccountStatusesBLL? Find(string Name)
        {

            AccountStatusesDTO? AccountStatusesDTO = AccountStatusesDAL.Find(Name);

            if (AccountStatusesDTO == null)
                return null;

            return new AccountStatusesBLL(AccountStatusesDTO);

        }

        public bool Add()
        {
            ID = AccountStatusesDAL.Add(ASADTO);

            return ID > 0;
        }

        public bool UpdateDescription()
        {
            return AccountStatusesDAL.UpdateDescription(ID, Description);
        }
        public bool UpdateDescription(string Description)
        {
            return AccountStatusesDAL.UpdateDescription(ID, Description);
        }

        public static bool Delete(long ID)
        {
            return AccountStatusesDAL.Delete(ID);
        }

        public static bool IsExist(long ID)
        {
            return AccountStatusesDAL.IsExist(ID);
        }

        public static List<AccountStatusesDTO>? GetAll()
        {

            return AccountStatusesDAL.GetAll();

        }
    }
}

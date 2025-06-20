using Data_Access_Layer;
using DTO_Layer;
using static DTO_Layer.TransactionTypeDTO;

namespace Business_Logic_Layer
{
    public class TransactionTypesBLL
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public TransactionTypesBLL(TransactionTypeDTO TransactionTypeDTO)
        {

            ID = TransactionTypeDTO.ID;
            Name = TransactionTypeDTO.Name;
            Description = TransactionTypeDTO.Description;

        }
        public TransactionTypesBLL(TransactionTypeAddDTO TransactionTypeDTO)
        {

            ID = 0;
            Name = TransactionTypeDTO.Name;
            Description = TransactionTypeDTO.Description;

        }

        public TransactionTypeDTO TTDTO
        {
            get
            {
                return new TransactionTypeDTO(ID, Name, Description);
            }
        }
        public TransactionTypeAddDTO TTADTO
        {
            get
            {
                return new TransactionTypeAddDTO(Name, Description);
            }
        }

        public static TransactionTypesBLL? Find(long ID)
        {

            TransactionTypeDTO? TransactionTypeDTO = TransactionTypesDAL.Find(ID);

            if (TransactionTypeDTO == null)
                return null;

            return new TransactionTypesBLL(TransactionTypeDTO);

        }

        public static TransactionTypesBLL? Find(string Name)
        {

            TransactionTypeDTO? TransactionTypeDTO = TransactionTypesDAL.Find(Name);

            if (TransactionTypeDTO == null)
                return null;

            return new TransactionTypesBLL(TransactionTypeDTO);

        }

        public bool Add()
        {
            ID = TransactionTypesDAL.Add(TTADTO);

            return ID > 0;
        }

        public bool UpdateDescription()
        {
            return TransactionTypesDAL.UpdateDescription(ID, Description);
        }
        public bool UpdateDescription(string Description)
        {
            return TransactionTypesDAL.UpdateDescription(ID, Description);
        }

        public static bool Delete(long ID)
        {
            return TransactionTypesDAL.Delete(ID);
        }

        public static bool IsExist(long ID)
        {
            return TransactionTypesDAL.IsExist(ID);
        }

        public static List<TransactionTypeDTO> GetAll()
        {

            return TransactionTypesDAL.GetAll();

        }
    }
}

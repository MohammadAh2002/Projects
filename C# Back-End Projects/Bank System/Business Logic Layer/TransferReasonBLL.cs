using Data_Access_Layer;
using DTO_Layer;

namespace Business_Logic_Layer
{
    public class TransferReasonBLL
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public TransferReasonBLL(TransferReasonDTO TransferReasonDTO)
        {

            ID = TransferReasonDTO.ID;
            Name = TransferReasonDTO.Name;
            Description = TransferReasonDTO.Description;

        }
        public TransferReasonBLL(TransferReasonAddDTO TransferReasonDTO)
        {

            ID = 0;
            Name = TransferReasonDTO.Name;
            Description = TransferReasonDTO.Description;

        }

        public TransferReasonDTO TRDTO
        {
            get
            {
                return new TransferReasonDTO(ID, Name, Description);
            }
        }
        public TransferReasonAddDTO TRADTO
        {
            get
            {
                return new TransferReasonAddDTO(Name, Description);
            }
        }

        public static TransferReasonBLL? Find(long ID)
        {

            TransferReasonDTO? TransferReasonDTO = TransferReasonDAL.Find(ID);

            if (TransferReasonDTO == null)
                return null;

            return new TransferReasonBLL(TransferReasonDTO);

        }

        public static TransferReasonBLL? Find(string Name)
        {

            TransferReasonDTO? TransferReasonDTO = TransferReasonDAL.Find(Name);

            if (TransferReasonDTO == null)
                return null;

            return new TransferReasonBLL(TransferReasonDTO);

        }

        public bool Add()
        {
            ID = TransferReasonDAL.Add(TRADTO);

            return ID > 0;
        }

        public bool UpdateDescription()
        {
            return TransferReasonDAL.UpdateDescription(ID, Description);
        }
        public bool UpdateDescription(string Description)
        {
            return TransferReasonDAL.UpdateDescription(ID, Description);
        }

        public static bool Delete(long ID)
        {
            return TransferReasonDAL.Delete(ID);
        }

        public static bool IsExist(long ID)
        {
            return TransferReasonDAL.IsExist(ID);
        }

        public static List<TransferReasonDTO>? GetAll()
        {

            return TransferReasonDAL.GetAll();

        }
    }
}

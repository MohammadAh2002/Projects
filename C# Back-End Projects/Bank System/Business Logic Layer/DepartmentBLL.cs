using Data_Access_Layer;
using DTO_Layer;

namespace Business_Logic_Layer
{
    public class DepartmentBLL
    {

        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DepartmentBLL(DepartmentDTO DepartmentDTO)
        {

            ID = DepartmentDTO.ID;
            Name = DepartmentDTO.Name;
            Description = DepartmentDTO.Description;

        }
        public DepartmentBLL(DepartmentAddDTO DepartmentDTO)
        {

            ID = 0;
            Name = DepartmentDTO.Name;
            Description = DepartmentDTO.Description;

        }

        public DepartmentDTO DDTO
        {
            get
            {
                return new DepartmentDTO(ID, Name, Description);
            }
        }
        public DepartmentAddDTO DADTO
        {
            get
            {
                return new DepartmentAddDTO(Name, Description);
            }
        }

        public static DepartmentBLL? Find(long ID)
        {

            DepartmentDTO? DepartmentDTO = DepartmentDAL.Find(ID);

            if (DepartmentDTO == null)
                return null;

            return new DepartmentBLL(DepartmentDTO);

        }

        public static DepartmentBLL? Find(string Name)
        {

            DepartmentDTO? DepartmentDTO = DepartmentDAL.Find(Name);

            if (DepartmentDTO == null)
                return null;

            return new DepartmentBLL(DepartmentDTO);

        }

        public bool Add()
        {
            ID = DepartmentDAL.Add(DADTO);

            return ID > 0;
        }

        public bool UpdateDescription()
        {
            return DepartmentDAL.UpdateDescription(ID, Description);
        }
        public bool UpdateDescription(string Description)
        {
            return DepartmentDAL.UpdateDescription(ID, Description);
        }

        public static bool Delete(long ID)
        {
            return DepartmentDAL.Delete(ID);
        }

        public static bool IsExist(long ID)
        {
            return DepartmentDAL.IsExist(ID);
        }

        public static List<DepartmentDTO> GetAll()
        {

            return DepartmentDAL.GetAll();

        }

        public stDepartmentDetails? DepartmentDetails()
        {
            return DepartmentDetails(ID);

        }
        public static stDepartmentDetails? DepartmentDetails(long ID)
        {

            return DepartmentDAL.DepartmentDetails(ID);
        }

    }
}

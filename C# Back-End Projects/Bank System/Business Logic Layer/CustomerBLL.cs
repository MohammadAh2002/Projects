using Data_Access_Layer;
using DTO_Layer;

namespace Business_Logic_Layer
{
    public class CustomerBLL
    {

        public long ID { get; set; }
        public string PinCode { get; set; }
        public bool IsActive { get; set; }
        public PersonBLL? Person { get; set; }
        DateTime CreationDate { get; set; }

        enum enMode { Add = 1, Update = 2 }
        enMode Mode;

        public CustomerBLL(CustomerDTO CustomerDTO)
        {
            ID = CustomerDTO.ID;
            PinCode = CustomerDTO.PinCode;
            IsActive = CustomerDTO.IsActive;
            Person = PersonBLL.Find(CustomerDTO.PersonID);
            CreationDate = CustomerDTO.CreationDate;

            Mode = enMode.Update;

        }
        public CustomerBLL(CustomerAddDTO CustomerDTO)
        {
            ID = -1;

            IsActive = true;

            PinCode = CustomerDTO.PinCode;
            Person = PersonBLL.Find(CustomerDTO.PersonID);
            CreationDate = DateTime.Now;

            Mode = enMode.Add;

        }

        public CustomerDTO CDTO
        {
            get
            {
                return new CustomerDTO(ID, PinCode, IsActive, CreationDate, Person.ID);
            }
        }
        public CustomerAddDTO CADTO
        {
            get
            {
                return new CustomerAddDTO(PinCode, Person.ID);
            }
        }
        public CustomerShowDTO CSDTO
        {
            get
            {
                return new CustomerShowDTO(ID, Person.ID, Person.NationalNumber, Person.FullName,
                                           Person.Gender, Person.Email, Person.PhoneNumber, Person.Address,
                                           Person.DateOfBirth, Person.Country.Name, IsActive, CreationDate);
            }
        }

        public static CustomerBLL? Find(long ID)
        {

            CustomerDTO? CustomerDTO = CustomerDAL.Find(ID);

            if (CustomerDTO == null)
                return null;

            return new CustomerBLL(CustomerDTO);

        }
        public static CustomerBLL? FindByPersonID(long ID)
        {

            CustomerDTO? CustomerDTO = CustomerDAL.FindByPersonID(ID);

            if (CustomerDTO == null)
                return null;

            return new CustomerBLL(CustomerDTO);

        }

        public static bool Delete(long ID)
        {

            return CustomerDAL.Delete(ID);

        }

        public static bool IsExist(long ID)
        {

            return CustomerDAL.IsExist(ID);

        }

        public static bool IsExistByPersonID(long ID)
        {

            return CustomerDAL.IsExistByPersonID(ID);

        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.Add:
                    return Add();

                case enMode.Update:
                    return Update();

            }

            return false;

        }

        bool Add()
        {
            ID = CustomerDAL.Add(CADTO);

            if (ID != 0)
            {
                Mode = enMode.Update;
                return true;
            }

            return false;

        }

        bool Update()
        {
            return CustomerDAL.Update(ID, PinCode);

        }

        public static bool Update(long ID, string PinCode)
        {
            return CustomerDAL.Update(ID, PinCode);

        }

        public static List<CustomerShowDTO>? GetAll()
        {
            return CustomerDAL.GetAll();
        }

        public List<AccountShowDTO> CustomerAllAccounts()
        {
            return AccountDAL.CustomerAllAccounts(ID);
        }

        public bool DeActivate()
        {
            return DeActivate(ID);
        }
        public static bool DeActivate(long ID)
        {
            return CustomerDAL.DeActivate(ID);
        }

        public bool Activate()
        {
            return Activate(ID);
        }
        public static bool Activate(long ID)
        {
            return CustomerDAL.Activate(ID);
        }
    }
}

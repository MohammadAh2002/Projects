using Data_Access_Layer;
using DTO_Layer;

namespace Business_Logic_Layer
{
    public class UserBLL
    {

        enum enMode { Add = 1, Update = 2 }
        enMode Mode;

        public long ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public EmployeeBLL? Employee { get; set; }


        UserBLL(UserDTO User)
        {

            ID = User.ID;
            Username = User.Username;
            Password = User.Password;
            IsActive = User.IsActive;

            Employee = EmployeeBLL.Find(User.EmployeeID);

            Mode = enMode.Update;

        }
        public UserBLL(UserAddDTO User)
        {

            ID = -1;
            Username = User.Username;
            Password = User.Password;
            IsActive = true;

            Employee = EmployeeBLL.Find(User.EmployeeID);

            Mode = enMode.Add;

        }
        public UserBLL(UserUpdateDTO UserDTO)
        {

            UserBLL? User = Find(UserDTO.ID);

            ID = UserDTO.ID;
            Username = UserDTO.Username;
            Password = UserDTO.Password;
            IsActive = true;
            Employee = EmployeeBLL.Find(User.Employee.ID);

            Mode = enMode.Update;

        }

        public UserDTO UDTO
        {
            get
            {

                return new UserDTO(ID, Username, Password, IsActive, Employee.ID);

            }
        }
        public UserShowDTO USDTO
        {
            get
            {

                return new UserShowDTO(ID, Employee.Person.FullName, Employee.Salary,
                                       Employee.HireDate, Employee.LeaveDate, Employee.Department.Name,
                                       Employee.Person.Gender, Employee.Person.Email, Employee.Person.PhoneNumber,
                                       Employee.Person.Address, Employee.Person.DateOfBirth,
                                       Employee.Person.Country.Name, Username, IsActive);

            }
        }

        public static UserBLL? Find(long ID)
        {

            UserDTO? User = UserDAL.Find(ID);

            if (User == null)
                return null;

            return new UserBLL(User);

        }
        public static UserBLL? Find(string Username, string Password)
        {
            UserDTO? User = UserDAL.Find(Username, Password);

            if (User == null)
                return null;

            return new UserBLL(User);

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

        public bool Delete()
        {
            return Delete(ID);
        }
        public static bool Delete(long ID)
        {
            return UserDAL.Delete(ID);
        }

        public static bool IsExist(long ID)
        {
            return UserDAL.IsExist(ID);

        }

        public static bool IsExist(string Username)
        {
            return UserDAL.IsExist(Username);

        }

        public static List<UserShowDTO>? GetAll()
        {
            return UserDAL.GetAll();
        }

        public bool DeActivate()
        {
            return DeActivate(ID);
        }
        public static bool DeActivate(long ID)
        {
            return UserDAL.DeActivate(ID);
        }

        public bool Activate()
        {
            return Activate(ID);
        }
        public static bool Activate(long ID)
        {
            return UserDAL.Activate(ID);
        }

        bool Add()
        {
            ID = UserDAL.Add(UDTO);

            if (ID != 0)
            {
                Mode = enMode.Update;
                return true;
            }

            return false;

        }

        bool Update()
        {
            return UserDAL.Update(UDTO);
        }

    }

}

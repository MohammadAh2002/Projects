using Data_Access_Layer;
using DTO_Layer;

namespace Business_Logic_Layer
{
    public class EmployeeBLL
    {

        public long ID { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public DepartmentBLL? Department { get; set; }
        public PersonBLL? Person { get; set; }

        public EmployeeBLL(long id, decimal salary, bool isActive, DateTime hireDate,
                           DateTime leaveDate, long personId, long departmentID)
        {

            ID = id;
            Salary = salary;
            IsActive = isActive;
            HireDate = hireDate;
            LeaveDate = leaveDate;
            Department = DepartmentBLL.Find(departmentID);
            Person = PersonBLL.Find(personId);

        }

        EmployeeBLL(EmployeeDTO? EmployeeDTO)
        {
            ID = EmployeeDTO.ID;
            Salary = EmployeeDTO.Salary;
            IsActive = EmployeeDTO.IsActive;
            HireDate = EmployeeDTO.HireDate;
            LeaveDate = EmployeeDTO.LeaveDate;
            Department = DepartmentBLL.Find(EmployeeDTO.DepartmentID);

            Person = PersonBLL.Find(EmployeeDTO.PersonID);

        }
        public EmployeeBLL(EmployeeAddDTO? EmployeeDTO)
        {
            ID = -1;
            Salary = EmployeeDTO.Salary;
            IsActive = true;
            HireDate = EmployeeDTO.HireDate;
            LeaveDate = null;
            Department = DepartmentBLL.Find(EmployeeDTO.DepartmentID);
            Person = PersonBLL.Find(EmployeeDTO.PersonID);

        }
        public EmployeeBLL(EmployeeUpdateDTO? EmployeeDTO)
        {

            EmployeeBLL? Employee = Find(EmployeeDTO.ID);

            ID = EmployeeDTO.ID;

            Salary = EmployeeDTO.Salary;
            IsActive = Employee.IsActive;

            HireDate = Employee.HireDate;
            LeaveDate = Employee.LeaveDate;

            Department = DepartmentBLL.Find(EmployeeDTO.DepartmentID);
            Person = PersonBLL.Find(Employee.Person.ID);

        }

        public EmployeeDTO EDTO
        {
            get
            {
                return new EmployeeDTO(ID, Salary, IsActive, HireDate,
                                       LeaveDate, Person.ID, Department.ID);
            }
        }
        public EmployeeShowDTO ESDTO
        {
            get
            {
                return new EmployeeShowDTO(ID, Person.FullName, Salary, HireDate,
                                           LeaveDate, Department.Name, Person.Gender, Person.Email,
                                           Person.PhoneNumber, Person.Address, Person.DateOfBirth, Person.Country.Name);
            }
        }

        public static EmployeeBLL? Find(long ID)
        {

            EmployeeDTO? EmployeeDTO = EmployeeDAL.Find(ID);

            if (EmployeeDTO == null)
                return null;

            return new EmployeeBLL(EmployeeDTO);

        }
        public static EmployeeBLL? FindByPersonID(long PersonID)
        {
            EmployeeDTO? EmployeeDTO = EmployeeDAL.FindByPersonID(PersonID);

            if (EmployeeDTO == null)
                return null;

            return new EmployeeBLL(EmployeeDTO);

        }

        public bool Add(EmployeeAddDTO EmployeeDTO)
        {

            ID = EmployeeDAL.Add(EmployeeDTO);

            return ID != -1;

        }

        public bool Update()
        {

            return EmployeeDAL.Update(EDTO) > 0;

        }

        public static bool Delete(long ID)
        {

            return EmployeeDAL.Delete(ID);

        }

        public static bool IsExist(long ID)
        {

            return EmployeeDAL.IsExist(ID);

        }

        public static List<EmployeeShowDTO>? GetAll()
        {

            return EmployeeDAL.GetAll();

        }

        public bool DeActivate()
        {
            return DeActivate(ID);
        }
        public static bool DeActivate(long ID)
        {
            return EmployeeDAL.DeActivate(ID);
        }

        public bool Activate()
        {
            return Activate(ID);
        }
        public static bool Activate(long ID)
        {
            return EmployeeDAL.Activate(ID);
        }

        public static decimal TotalSalaries()
        {
            return EmployeeDAL.TotalSalaries();
        }

    }
}

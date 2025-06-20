using System.ComponentModel.DataAnnotations;

namespace DTO_Layer
{
    public class EmployeeDTO
    {
        public long ID { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public long DepartmentID { get; set; }
        public long PersonID { get; set; }

        public EmployeeDTO(long id, decimal salary, bool isActive, DateTime hireDate,
                           DateTime? leaveDate,long personId, long departmentID)
        {

            ID = id;
            Salary = salary;
            IsActive = isActive;
            HireDate = hireDate;
            LeaveDate = leaveDate;
            DepartmentID = departmentID;
            PersonID = personId;

        }

    }

    public class EmployeeAddDTO
    {

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be 0 or Bigger")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Hire Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Person ID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Person ID must be a non-negative number.")]
        public long PersonID { get; set; }

        [Required(ErrorMessage = "Department ID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Department ID must be a non-negative number.")]
        public long DepartmentID { get; set; }

        public EmployeeAddDTO(decimal salary, DateTime hireDate,
                              long personId, long departmentID)
        {

            Salary = salary;
            HireDate = hireDate;
            DepartmentID = departmentID;
            PersonID = personId;

        }
        public EmployeeAddDTO() { }

    }

    public class EmployeeUpdateDTO
    {
        [Required(ErrorMessage = "ID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Person ID must be a non-negative number.")]
        public long ID { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be 0 or Bigger")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Department ID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Department ID must be a non-negative number.")]
        public long DepartmentID { get; set; }

        public EmployeeUpdateDTO(long id, decimal salary, long departmentID)
        {
            ID = id;
            Salary = salary;
            DepartmentID = departmentID;

        }
        public EmployeeUpdateDTO() { }

    }

    public class EmployeeShowDTO
    {
        public long ID { get; set; }
        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public long Age { get; set; }
        public string Country { get; set; }

        public EmployeeShowDTO(long id, string fullName, decimal salary, DateTime hireDate, DateTime? leaveDate,
                               string department, string gender, string email, string phoneNumber,
                               string address, DateTime DateOfBirth, string country)
        {

            ID = id;
            FullName = fullName;
            Salary = salary;
            HireDate = hireDate;
            LeaveDate = leaveDate;
            Department = department;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Age = DateTime.Now.Year - DateOfBirth.Year;
            Country = country;

        }


    }

}

using System.ComponentModel.DataAnnotations;

namespace DTO_Layer
{
    public class UserDTO
    {

        public long ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public long EmployeeID { get; set; }

        public UserDTO(long ID, string Username, string Password, bool IsActive, long EmployeeID)
        {

            this.ID = ID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
            this.EmployeeID = EmployeeID;

        }

    }

    public class UserShowDTO
    {

        public long ID { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
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

        public UserShowDTO(long id, string fullName, decimal salary, DateTime hireDate, DateTime? leaveDate,
                           string department, string gender, string email, string phoneNumber,
                           string address, DateTime DateOfBirth, string country, string username, bool isactive)
        {

            ID = id;
            Username = username;
            IsActive = isactive;
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

    public class UserAddDTO
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Username must be between 1 and 50 characters.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(18, MinimumLength = 1, ErrorMessage = "Password must be between 1 and 50 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Employee ID must be a non-negative number.")]
        public long EmployeeID { get; set; }

        public UserAddDTO(string Username, string Password, long EmployeeID)
        {

            this.Username = Username;
            this.Password = Password;
            this.EmployeeID = EmployeeID;

        }

        public UserAddDTO() { }

    }

    public class UserUpdateDTO
    {
        [Required(ErrorMessage = "User ID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "User ID must be a non-negative number.")]
        public long ID { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Username must be between 1 and 15 characters.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(18, MinimumLength = 1, ErrorMessage = "Password must be between 1 and 18 characters.")]
        public string Password { get; set; }

        public UserUpdateDTO() { }

        public UserUpdateDTO(long ID, string Username, string Password)
        {
            this.ID = ID;
            this.Username = Username;
            this.Password = Password;

        }

    }

}

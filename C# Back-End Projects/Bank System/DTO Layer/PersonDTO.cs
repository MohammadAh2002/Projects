using System.ComponentModel.DataAnnotations;
using Helper_Layer;
using Microsoft.AspNetCore.Http;

namespace DTO_Layer
{
    public class PersonDTO
    {
        public long ID { get; set; }
        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? ThirdName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set; }
        public long CountryID { get; set; }

        public PersonDTO(long ID, string NationalNumber, string FirstName, string SecondName,
                         string? ThirdName, string LastName, string Gender,
                         string Email, string PhoneNumber, string Address, DateTime DateOfBirth,
                         bool IsDeleted, long CountryID)
        {

            this.ID = ID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;         
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.IsDeleted = IsDeleted;
            this.NationalNumber = NationalNumber;
            this.CountryID = CountryID;

        }
      
    }

    public class PersonShowDTO
    {
        public long ID { get; set; }
        public string NationalNumber { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long Age { get; set; }
        public string Country { get; set; }

        public PersonShowDTO(long ID, string NationalNumber, string FullName, string Gender,
                            string Email, string PhoneNumber, string Address, DateTime DateOfBirth, string Country)
        {

            this.ID = ID;
            this.FullName = FullName;
            this.Gender = Gender;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.NationalNumber = NationalNumber;
            this.Country = Country;
            Age = DateTime.Now.Year - DateOfBirth.Year;

        }


    }

    public class PersonAddDTO
    {
        [Required(ErrorMessage = "National Number is required.")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "National Number must be exactly 9 characters.")]
        public string NationalNumber { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "First Name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Second Name is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Second Name must be between 2 and 50 characters.")]
        public string SecondName { get; set; }

        [StringLength(25, MinimumLength = 1, ErrorMessage = "Third Name must be between 2 and 50 characters.")]
        public string? ThirdName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Last Name must be between 2 and 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [GenderCharValidation(ErrorMessage = "Gender must be either 'M' or 'F'.")]
        public char Gender { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid email format.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Phone Number must be exactly 9 characters.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Address must be Between 0 and 100")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Date Of Birth is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Country ID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Country ID must be a non-negative number.")]
        public long CountryID { get; set; }

        public PersonAddDTO(string NationalNumber, string FirstName, string SecondName,
                            string? ThirdName, string LastName, char Gender, string Email,
                            string PhoneNumber, string Address, DateTime DateOfBirth,
                            long CountryID)
        {

            this.NationalNumber = NationalNumber;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;

        }

        public PersonAddDTO(){
        
        }
    
    }

    public class PersonUpdateDTO
    {

        [Required(ErrorMessage = "Person ID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Person ID must be a non-negative number.")]
        public long ID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "First Name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Second Name is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Second Name must be between 2 and 50 characters.")]
        public string SecondName { get; set; }

        [StringLength(25, MinimumLength = 1, ErrorMessage = "Third Name must be between 2 and 50 characters.")]
        public string? ThirdName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Last Name must be between 2 and 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid email format.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Phone Number must be exactly 9 characters.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Address must be Between 0 and 100")]
        public string Address { get; set; }

        [Required(ErrorMessage = "CountryID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "CountryID must be a non-negative number.")]     
        public long CountryID { get; set; }

        public PersonUpdateDTO(string firstname, string secondname, string? thirdname,
                               string lastname, string email, string phoneNumber,
                               string address, long countryID)
        {

            FirstName = firstname;
            SecondName = secondname;
            ThirdName = thirdname;
            LastName = lastname;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            CountryID = countryID;

        }

        public PersonUpdateDTO() { }
    }

}

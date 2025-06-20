using System.ComponentModel.DataAnnotations;

namespace DTO_Layer
{
    public class CustomerDTO
    {
        public long ID { get; set; }
        public string PinCode { get; set; }
        public bool IsActive { get; set; }
        public long PersonID { get; set; }
        public DateTime CreationDate { get; set; }

        public CustomerDTO(long ID, string PinCode, bool IsActive, DateTime CreationDate, long PersonID)
        {
            this.ID = ID;
            this.PinCode = PinCode;
            this.IsActive = IsActive;
            this.PersonID = PersonID;
            this.CreationDate = CreationDate;
        }

    }

    public class CustomerAddDTO
    {

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Pin Code is required.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Pin Code must be exactly 4 characters.")]
        public string PinCode { get; set; }


        [Required(ErrorMessage = "Person ID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Person ID must be a non-negative number.")]
        public long PersonID { get; set; }

        public CustomerAddDTO(string PinCode, long PersonID)
        {
            this.PinCode = PinCode;
            this.PersonID = PersonID;
        }
        public CustomerAddDTO() { }
    }

    public class CustomerShowDTO
    {
        public long ID { get; set; }
        public long PersonID { get; set; }  
        public string NationalNumber { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long Age { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
        DateTime CreationDate { get; set; }

        public CustomerShowDTO(long ID, long PersonID, string NationalNumber, string FullName, string Gender,
                            string Email, string PhoneNumber, string Address, DateTime DateOfBirth,
                            string Country, bool IsActive, DateTime CreationDate)
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
            this.IsActive = IsActive;
            this.CreationDate = CreationDate;
            this.PersonID = PersonID;
        }


    }
}

using System.ComponentModel.DataAnnotations;

namespace DTO_Layer
{
    public class AccountStatusesDTO
    {
        [Required(ErrorMessage = "ID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Account Statuse ID must be a non-negative number.")]
        public long ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters.")]
        public string Name { get; set; }

        [StringLength(300, ErrorMessage = "Description must be Less Than 300 characters.")]
        public string Description { get; set; }

        public AccountStatusesDTO(long iD, string name, string description)
        {
            ID = iD;
            Name = name;
            Description = description;
        }
    }
    public class AccountStatusesAddDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters.")]
        public string Name { get; set; }

        [StringLength(300, ErrorMessage = "Description must be Less Than 300 characters.")]
        public string Description { get; set; }

        public AccountStatusesAddDTO(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public AccountStatusesAddDTO() { }

    }

}


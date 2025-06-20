using System.ComponentModel.DataAnnotations;

namespace DTO_Layer
{
    public class DepartmentDTO
    {
        [Required(ErrorMessage = "ID is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Department ID must be a non-negative number.")]
        public long ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters.")]
        public string Name { get; set; }

        [StringLength(300, ErrorMessage = "Description must be Less Than 300 characters.")]
        public string Description { get; set; }

        public DepartmentDTO(long iD, string name, string description)
        {
            ID = iD;
            Name = name;
            Description = description;
        }

    }

    public class DepartmentAddDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters.")]
        public string Name { get; set; }

        [StringLength(300, ErrorMessage = "Description must be Less Than 300 characters.")]
        public string Description { get; set; }

        public DepartmentAddDTO(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public DepartmentAddDTO() { }
    }

    public struct stDepartmentDetails
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long NumberOfEmployees { get; set; }
        public decimal TotalSalaries { get; set; }
    }
}

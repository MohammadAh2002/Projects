using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects.Person
{
    public class PersonCreationDTO
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Birth date is a required field.")]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; init; }

        [Required(ErrorMessage = "Country ID is a required field.")]
        [Range(1, short.MaxValue, ErrorMessage = "Country ID must be greater than 0.")]
        public short CountryID { get; init; }

        [Required(ErrorMessage = "Photo is a required field.")]
        public IFormFile? Photo { get; set; }

        [Required(ErrorMessage = "Gender is a required field.")]
        public bool Gender { get; init; }

    }
}

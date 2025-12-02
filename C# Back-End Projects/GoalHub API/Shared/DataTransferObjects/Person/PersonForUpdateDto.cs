using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Person
{
    public record PersonForUpdateDto
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Country ID is a required field.")]
        [Range(1, short.MaxValue, ErrorMessage = "Country ID must be greater than 0.")]
        public short CountryID { get; init; }

    }
}

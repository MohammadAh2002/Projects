using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Team
{
    public record TeamForUpdateDto
    {

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(255, ErrorMessage = "Maximum length for the Name is 255 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Abbreviation is a required field.")]
        [MaxLength(10, ErrorMessage = "Maximum length for the Abbreviation is 10 characters.")]
        public string? Abbreviation { get; init; }

        [Required(ErrorMessage = "Stadium ID is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "Stadium ID must be greater than 0.")]
        public int StadiumID { get; init; }

    }
}

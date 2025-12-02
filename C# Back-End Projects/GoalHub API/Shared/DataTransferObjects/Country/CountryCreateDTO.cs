using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Country
{
    public record CountryCreationDTO
    {
        [Required(ErrorMessage = "Country Name is a Required Field.")]
        [MaxLength(100, ErrorMessage = "Maximum Length for the Name is 100 Characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Nationality is a Required Field.")]
        [MaxLength(100, ErrorMessage = "Maximum Length for the Nationality is 100 Characters.")]
        public string? Nationality { get; init; }
    }

}

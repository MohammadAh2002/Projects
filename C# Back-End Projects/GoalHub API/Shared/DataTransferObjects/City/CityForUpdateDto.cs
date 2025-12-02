using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.City
{
    public record CityForUpdateDto : CityCreationDTO
    {

        [Required(ErrorMessage = "Country ID is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "Country ID must be greater than 0.")]
        public short CountryID { get; init; }
    }
}

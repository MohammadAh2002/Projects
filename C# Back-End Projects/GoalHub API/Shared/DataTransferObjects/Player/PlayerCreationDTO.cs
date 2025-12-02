using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Player
{
    public record PlayerCreationDTO
    {

        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Position is 255 characters.")]
        public string? Position { get; init; }

        [Required(ErrorMessage = "Current Team ID is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "Current Team ID must be greater than 0.")]
        public int CurrentTeamID { get; init; }

        [Required(ErrorMessage = "Person ID is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "Person ID must be greater than 0.")]
        public int PersonID { get; init; }

        [Range(1, byte.MaxValue, ErrorMessage = "Shirt Number must be greater than 0.")]
        public byte ShirtNumber { get; init; }


    }
}

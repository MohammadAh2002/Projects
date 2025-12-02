using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Player
{
    public record MatchCreationDTO
    {

        [Required(ErrorMessage = "Home Team ID is a required field.")]
        [Range(1, long.MaxValue, ErrorMessage = "Home Team ID must be greater than 0.")]
        public long HomeTeamID { get; init; }

        [Required(ErrorMessage = "Away Team ID is a required field.")]
        [Range(1, long.MaxValue, ErrorMessage = "Away Team ID must be greater than 0.")]
        public long AwayTeamID { get; init; }

        [Required(ErrorMessage = "Kickoff time is a required field.")]
        public DateTime KickOffTime { get; init; }

        [Required(ErrorMessage = "Stadium ID is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "Stadium ID must be greater than 0.")]
        public int StadiumID { get; init; }

        [Range(0, byte.MaxValue, ErrorMessage = "Home team score must be 0 or greater.")]
        public byte HomeTeamScore { get; init; }

        [Range(0, byte.MaxValue, ErrorMessage = "Away team score must be 0 or greater.")]
        public byte AwayTeamScore { get; init; }

        [Required(ErrorMessage = "Round is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Round is 100 characters.")]
        public string? Round { get; init; }

        [Required(ErrorMessage = "Match status ID is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "Match status ID must be greater than 0.")]
        public int StatusID { get; init; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Player
{
    public record MatchForPatchDTO
    {

        [DisplayFormat(DataFormatString = "{dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime KickoffTime { get; init; }

        [Range(1, int.MaxValue, ErrorMessage = "Stadium ID must be greater than 0.")]
        public int StadiumID { get; init; }

        [Range(0, byte.MaxValue, ErrorMessage = "Home team score must be 0 or greater.")]
        public byte HomeTeamScore { get; init; }

        [Range(0, byte.MaxValue, ErrorMessage = "Away team score must be 0 or greater.")]
        public byte AwayTeamScore { get; init; }

        [Range(1, int.MaxValue, ErrorMessage = "Match status ID must be greater than 0.")]
        public int StatusID { get; init; }

    }
}

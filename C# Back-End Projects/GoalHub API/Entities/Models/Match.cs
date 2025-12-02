using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Matchs")]
    public class Match
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]

        public int HomeTeamID { get; set; }

        [ForeignKey("HomeTeamID")]
        public Team? HomeTeam { get; set; }

        [Required]
        public int AwayTeamID { get; set; }

        [ForeignKey("AwayTeamID")]
        public Team? AwayTeam { get; set; }

        public DateTime KickoffTime { get; set; }

        [Required]
        public short StadiumID { get; set; }

        [ForeignKey("StadiumID")]
        public Stadium? Stadium { get; set; }

        public byte HomeTeamScore { get; set; }
        public byte AwayTeamScore { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Round { get; set; }

        [NotMapped]
        public EnumMatchStatuses Status { get; set; } = EnumMatchStatuses.Scheduled;

        [Required]
        public short StatusID { get; set; }

        [ForeignKey("StatusID")]
        public MatchStatus? MatchStatus { get; set; }

        [NotMapped]
        public static List<string> AllowedSortProperties = new List<string> { "Status" };

    }
}

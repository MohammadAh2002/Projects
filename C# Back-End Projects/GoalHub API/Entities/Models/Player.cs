using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Players")]
    public class Player
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int PersonID { get; set; }

        [ForeignKey("PersonID")]
        public Person? Person { get; set; }

        public byte ShirtNumber { get; set; } = 0;

        [Required]
        [MaxLength(25)]
        public string? Position { get; set; }

        [Required]
        public int CurrentTeamID { get; set; }

        [ForeignKey("CurrentTeamID")]
        public Team? CurrentTeam { get; set; }

        public PlayerStatus? Status { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Abbreviation { get; set; }

        [Required]
        public short CityID { get; set; }

        [ForeignKey("CityID")]
        public City? City { get; set; }

        [Required]
        public short StadiumID { get; set; }

        [ForeignKey("StadiumID")]
        public Stadium? Stadium{ get; set; }

        [Required]
        public DateOnly FoundedDate { get; set; }

        public string? Logo { get; set; } = null;

        [Required]
        public bool IsDeleted { get; set; } = false;

        [NotMapped]
        public static List<string> AllowedSortProperties = new List<string> {"Name", "FoundedDate", "Abbreviation"};

    }
}

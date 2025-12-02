using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Cities")]
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; } 

        [Required]
        public short CountryID { get; set; }

        [ForeignKey("CountryID")]
        public Country? Country { get; set; }
    }
}

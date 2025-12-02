using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("People")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column("CountryID")]
        public short CountryID { get; set; }

        [ForeignKey("CountryID")]
        public Country? Country { get; set; }

        [Required]
        [MaxLength(255)]
        public string? ImageFileName { get; set; }

        [Required]
        public bool Gender { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.Models
{

    [Table("PlayerStatuses")]
    public class PlayerStatus
    {
        [Key]
        public int PlayerID { get; set; }

        public short? Goals { get; set; }

        public short? Assists { get; set; }

        public byte? RedCards { get; set; }

        public byte? YellowCards { get; set; }

        
        [ForeignKey("PlayerID")]
        public Player? Player { get; set; }

    }
}

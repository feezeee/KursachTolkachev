using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models
{
    [Table("access_rights")]
    public class AccessRight
    {
        [Column("access_right_id")]
        public int Id { get; set; }

        [Column("access_right_type")]
        public string Name { get; set; }

        public virtual List<Worker> Workers { get; set; } = new List<Worker>();
    }
}

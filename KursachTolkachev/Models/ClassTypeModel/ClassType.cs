using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models
{
    [Table("classes_type")]
    public class ClassType
    {
        [Column("class_type_id")]
        public int Id { get; set; }

        [Column("type_number")]
        public int Number { get; set; }


        public virtual List<Class> Classes { get; set; } = new List<Class>();
    }
}

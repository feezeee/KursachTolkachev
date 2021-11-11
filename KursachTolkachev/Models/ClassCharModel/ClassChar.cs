using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models
{
    [Table("classes_char")]
    public class ClassChar
    {
        [Column("class_char_id")]
        public int Id { get; set; }

        [Column("char_name")]
        public string CharName { get; set; }

        public virtual List<Class> Classes { get; set; } = new List<Class>();
    }
}

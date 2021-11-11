using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models
{
    [Table("subjects")]
    public class Subject
    {
        [Column("subject_id")]
        public int Id { get; set; }

        [Column("subject_name")]
        public string Name { get; set; }

        public virtual List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}

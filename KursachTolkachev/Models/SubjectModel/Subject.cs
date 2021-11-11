using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models
{
    [Table("subjects")]
    public class Subject
    {
        [Required]
        [Column("subject_id")]
        public int Id { get; set; }

        [Required]
        [Column("subject_name")]
        public string Name { get; set; }

        [Required]
        [Column("worker_id")]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        public virtual List<Schedule> Schedules { get; set; } = new List<Schedule>();
        public virtual List<Class> Classes { get; set; } = new List<Class>();
    }
}

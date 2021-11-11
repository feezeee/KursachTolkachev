using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models
{
    [Table("lessons")]
    public class Lesson
    {
        [Column("lesson_id")]
        public int Id { get; set; }


        [Column("class_id")]
        public int ClassId { get; set; }
        public Class Class { get; set; }


        [Column("subject_id")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }


        [Column("worker_id")]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }



        public virtual List<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}

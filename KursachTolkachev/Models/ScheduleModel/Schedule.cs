using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models
{
    [Table("schedules")]
    public class Schedule
    {
        [Column("schedule_id")]
        public int Id { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("start_time")]
        public DateTime StartTime { get; set; }

        [Column("end_time")]
        public DateTime EndTime { get; set; }

        [Column("lesson_id")]
        public int ClassSubjectWorkerId { get; set; }
        public Lesson ClassSubjectWorker { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursachTolkachev.Models
{
    [Table("schedules")]
    public class Schedule
    {
        [Required]
        [Column("schedule_id")]
        public int Id { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("class_id")]
        public int ClassId { get; set; }
        public Class Class { get; set; }


        [Required]
        [Column("subject_id")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}

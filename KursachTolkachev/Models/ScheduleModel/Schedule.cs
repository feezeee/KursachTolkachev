using Microsoft.AspNetCore.Mvc;
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
        [Remote(action: "CheckDate", controller: "Schedule", AdditionalFields = "ClassId", ErrorMessage = "В это врямя занятие уже проводится", HttpMethod = "POST")]
        public DateTime Date { get; set; }

        [Required]
        [Column("class_id")]
        public int ClassId { get; set; }
        public Class Class { get; set; }


        [Required]
        [Column("subject_id")]
        [Remote(action: "CheckSubject", controller: "Schedule", AdditionalFields = "Date", ErrorMessage = "Данное занятие в это время проводится у другого класса", HttpMethod = "POST")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}

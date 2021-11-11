using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models
{
    [Table("classes")]
    public class Class
    {
        [Column("class_id")]
        public int Id { get; set; }

        [Column("class_name")]
        public string Name { get; set; }


        [Column("classroom_teacher_worker_id")]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        [Column("class_type_id")]
        public int ClassTypeId { get; set; }
        public ClassType ClassType { get; set; }


        


        public virtual List<Student> Students { get; set; } = new List<Student>();

        public virtual List<Lesson> Lessons { get; set; } = new List<Lesson>();

    }
}

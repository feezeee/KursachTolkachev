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


        [Column("classroom_teacher_worker_id")]
        public int ClassroomTeacherId { get; set; }
        public Worker ClassroomTeacher { get; set; }


        [Column("class_type_id")]
        public int ClassTypeId { get; set; }
        public ClassType ClassType { get; set; }


        [Column("class_char_id")]
        public int ClassCharId { get; set; }
        public ClassChar ClassChar { get; set; }




        public virtual List<Student> Students { get; set; } = new List<Student>();
        public virtual List<Schedule> Schedules { get; set; } = new List<Schedule>();

    }
}

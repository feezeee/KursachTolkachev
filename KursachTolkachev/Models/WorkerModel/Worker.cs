using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models
{
    [Table("workers")]
    public class Worker
    {       

        [Column("worker_id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }


        [Column("middle_name")]
        public string MiddleName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }


        [Column("phone_number")]
        public string PhoneNumber { get; set; }


        [Column("email")]
        public string? Email { get; set; }


        [Column("password")]
        public string Password { get; set; }


        [Column("position_id")]
        public int PositionId { get; set; }
        public Position Position { get; set; }


        [Column("access_right_id")]
        public int AccessRightId { get; set; }
        public AccessRight AccessRight { get; set; }


        [Column("qualification_id")]
        public int QualificationId { get; set; }
        public Qualification Qualification { get; set; }




        public virtual List<Class> Classes { get; set; } = new List<Class>();

        public virtual List<Subject> Lessons { get; set; } = new List<Subject>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models
{
    public class Strudent
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [Column("access_right_id")]
        public int AccessRightId { get; set; }
        public AccessRight AccessRight { get; set; }


        [Column("qualification_id")]
        public int ClassId { get; set; }
        public Class Qualification { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models.ClassTypeModel
{
    [Table("classes_type")]
    public class ClassType
    {
        [Column("class_type_id")]
        public int Id { get; set; }

        [Column("type_name")]
        public string Name { get; set; }
    }
}

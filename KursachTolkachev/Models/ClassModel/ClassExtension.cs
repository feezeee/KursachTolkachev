using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models
{
    public static class ClassExtension
    {
        public static string ClassInfo(this Class myClass)
        {
            return myClass.ClassType.Number.ToString() + "(" + myClass.ClassChar.CharName + ")";
        }
    }
}

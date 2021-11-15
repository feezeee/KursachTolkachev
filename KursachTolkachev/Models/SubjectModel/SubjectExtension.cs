using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursachTolkachev.Models
{
    public static class SubjectExtension
    {
        public static string SubjectInfo(this Subject subject)
        {
            return subject.Name + "(" + $"{subject.Worker?.LastName} {subject.Worker?.FirstName}" + ")";
        }
    }
}

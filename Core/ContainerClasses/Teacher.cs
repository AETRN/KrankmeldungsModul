using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrankmeldungsModul.Core.ContainerClasses
{
    public class Teacher : Person
    {
        private List<string> _class;
        public List<string> CLASS { get => _class; set => _class = value; }
    }
}

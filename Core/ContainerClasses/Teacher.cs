using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrankmeldungsModul.Core.ContainerClasses
{
    public class Teacher : Person
    {
        private string _id;
        public string ID { get => _id; set => _id = value; }
    }
}

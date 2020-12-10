using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrankmeldungsModul.Core.ContainerClasses
{
    public class Person
    {
        private string _firstname, _surname;
        public string FIRSTNAME { get => _firstname; set => _firstname = value; }
        public string SURNAME { get => _surname; set => _surname = value; }
    }
}

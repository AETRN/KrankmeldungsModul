using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrankmeldungsModul.Core.ContainerClasses
{
    public class Krankmeldung
    {
        private string _id,
                        _optmsg;
        private Teacher _teacher;
        private Student _student;
        private bool _medcert;
        private List<string> _informedmail;

        public string ID { get => _id; set => _id = value; }
        public string OPTMSG { get => _optmsg; set => _optmsg = value; }
        public Teacher TEACHER { get => _teacher; set => _teacher = value; }
        public Student STUDENT { get => _student; set => _student = value; }
        public bool MEDCERT { get => _medcert; set => _medcert = value; }
        public List<string> INFORMEDMAIL { get => _informedmail; set => _informedmail = value; }

        public Krankmeldung(string id = null, string optmsg = null, Teacher teacher = null, Student student = null, bool medcert = false, List<string> informedmail = null)
        {
            ID = id ?? CreateNewID();
            OPTMSG = optmsg ?? string.Empty;
            TEACHER = teacher ?? new Teacher();
            STUDENT = student ?? new Student();
            MEDCERT = medcert;
            INFORMEDMAIL = informedmail ?? new List<string>();
        }
        //
        //CreateNewID()
        //
    }
}

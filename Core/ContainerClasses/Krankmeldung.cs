using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            STUDENT = student ?? new Student();
            ID = id ?? _CreateNewID();
            OPTMSG = optmsg ?? string.Empty;
            TEACHER = teacher ?? new Teacher();
            MEDCERT = medcert;
            INFORMEDMAIL = informedmail ?? new List<string>();
        }
        /// <summary>
        /// Erstellt aus den ersten 3 Zeichen des Vor-, Nachnamen und der
        /// aktuellen Zeit einen Hash mit dem SHA256-Algorithmus
        /// </summary>
        /// <returns>32 Zeichen langer generierter Hash als String</returns>
        private string _CreateNewID()
        {
            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(STUDENT.FIRSTNAME.Substring(0,3) + STUDENT.SURNAME.Substring(0,3) + DateTime.Now.Ticks.ToString()));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++) { sBuilder.Append(data[i].ToString("x2")); }
            return sBuilder.ToString().Substring(0,32);
        }
    }
}

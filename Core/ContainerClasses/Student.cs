namespace KrankmeldungsModul.Core.ContainerClasses
{
    public class Student : Person
    {
        private string _class;
        public string CLASS { get => _class; set => _class = value; }
    }
}
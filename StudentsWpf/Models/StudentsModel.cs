using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsWpf
{
    public class StudentsModel
    {
        public ObservableCollection<Student> Students { get; private set; } = new ObservableCollection<Student>();
        public StudentsModel()
        {
            Students.Add(new Student("Kowalski", "Henryk", 12, "1T1"));
            Students.Add(new Student("Nowak", "Adam", 12, "2T3"));
            Students.Add(new Student("Abacki", "Jan", 12, "2T2"));
        }
    }
}

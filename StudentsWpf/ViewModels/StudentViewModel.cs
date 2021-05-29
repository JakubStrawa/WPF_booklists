using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsWpf.MVVM;

namespace StudentsWpf.ViewModels
{
    public class StudentViewModel : MVVM.IViewModel
    {
        private StudentsModel StudentsModel { get; }
        private Student Student { get; }
        public Action Close { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public uint Index { get; set; }
        public string Group { get; set; }

        public RelayCommand<StudentViewModel> OkCommand { get; } = new RelayCommand<StudentViewModel>
            (
                (studentViewModel) => { studentViewModel.Ok(); }
            );
        public RelayCommand<StudentViewModel> CancelCommand { get; } = new RelayCommand<StudentViewModel>
            (
                (studentViewModel) => { studentViewModel.Cancel(); }
            );

        public StudentViewModel(StudentsModel studentsModel, Student student)
        {
            StudentsModel = studentsModel;
            Student = student;
            if (Student != null)
            {
                Name = Student.Name;
                Surname = Student.Surname;
                Index = Student.Index;
                Group = Student.Group;
            }
        }

        public void Ok()
        {
            if (Student == null)
            {
                Student student = new Student(Surname, Name, Index, Group);
                StudentsModel.Students.Add(student);
            }
            else
            {
                Student.Name = Name;
                Student.Surname = Surname;
                Student.Index = Index;
                Student.Group = Group;
            }
            Close?.Invoke();
        }
        public void Cancel() => Close?.Invoke();
    }
}

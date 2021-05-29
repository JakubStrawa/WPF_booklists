using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using StudentsWpf.MVVM;

namespace StudentsWpf.ViewModels
{
    public class StudentsViewModel : IViewModel, INotifyPropertyChanged
    {
        private StudentsModel StudentsModel { get; }
        private readonly CollectionViewSource collectionViewSource;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICollectionView Students { get; }

        private Student selectedStudent;
        
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                EditCommand.NotifyCanExecuteChanged();
                DeleteCommand.NotifyCanExecuteChanged();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedStudent)));
            }
        }

        private string filterText = "";
        public string FilterText
        {
            get
            {
                return filterText;
            }
            set 
            {
                filterText = value;
                UpdateFilter();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilterText)));
            }
        }
        private void UpdateFilter()
        {
            collectionViewSource.View.Refresh();
        }
        bool FilterStudent(Student student)
        {
            return student.Surname.Contains(FilterText) || student.Name.Contains(FilterText);
        }
          
        public Action Close { get; set; }
        private RelayCommand<object> addCommand;
        public RelayCommand<object> AddCommand => (addCommand = addCommand?? new RelayCommand<object>(o=>AddStudent()));
        private RelayCommand<object> editCommand;
        public RelayCommand<object> EditCommand => (editCommand = editCommand ?? new RelayCommand<object>(o => EditStudent(SelectedStudent), o => SelectedStudent != null));
        private RelayCommand<object> deleteCommand;
        public RelayCommand<object> DeleteCommand => (deleteCommand = deleteCommand ?? new RelayCommand<object>(o => DeleteStudent(SelectedStudent), o => SelectedStudent != null));

        private RelayCommand<object> newWindowCommand;
        public RelayCommand<object> NewWindowCommand => (newWindowCommand = newWindowCommand ?? new RelayCommand<object>(o => NewWindow()));


        public StudentsViewModel(StudentsModel studentsModel)
        {
            StudentsModel = studentsModel;
            collectionViewSource = new CollectionViewSource
            {
                Source = StudentsModel.Students
            };
            collectionViewSource.View.Filter = (o) => FilterStudent((Student)o);
            Students = collectionViewSource.View;
        }

        public void NewWindow()
        {
            StudentsViewModel studentsViewModel = new StudentsViewModel(StudentsModel);
            ((App)Application.Current).WindowService.Show(studentsViewModel);
        }

        public void AddStudent()
        {
            StudentViewModel studentViewModel = new StudentViewModel(StudentsModel, null);
            ((App)Application.Current).WindowService.ShowDialog(studentViewModel);
        }

        public void EditStudent(Student student)
        {
            if (student != null)
            {
                StudentViewModel studentViewModel = new StudentViewModel(StudentsModel, student);
                ((App)Application.Current).WindowService.ShowDialog(studentViewModel);
            }
        }
        public void DeleteStudent(Student student)
        {
            if( student != null )
                StudentsModel.Students.Remove(student);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MVVM.IWindowService WindowService { get; } = new MVVM.WindowService();
        private StudentsModel StudentsModel { get; } = new StudentsModel();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            StudentsWpf.ViewModels.StudentsViewModel studentsViewModel = new StudentsWpf.ViewModels.StudentsViewModel(StudentsModel);
            WindowService.Show(studentsViewModel);
        }
    }
}

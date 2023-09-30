using System.Windows;
using ManageStaffDbApp.ViewModel;

namespace ManageStaffDbApp.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
            DataContext = new DataManagerVM();
        }
    }
}



using ManageStaffDbApp.Model;
using ManageStaffDbApp.View;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ManageStaffDbApp.ViewModel
{
    public class DataManagerVM : INotifyPropertyChanged
    {
        private List<Department> _allDepartments = DataWorker.GetAllDepartments();
        private List<Position> _allPositions = DataWorker.GetAllPositions();
        private List<User> _allUsers = DataWorker.GetAllUSers();

        public List<Department> AllDepartments 
        {
            get { return _allDepartments; }
            set 
            {
                _allDepartments = value; 
                OnPropertyChanged();
            }
        }
        public List<Position> AllPositions
        {
            get { return _allPositions; }
            set
            {
                _allPositions = value;
                OnPropertyChanged();
            }
        }
        public List<User> AllUsers
        {
            get { return _allUsers; }
            set
            {
                _allUsers = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));



        private void OpenAddDepartmentWindow()
        { 
            AddNewDepartmentWindow addNewDepartmentWindow = new AddNewDepartmentWindow();
            SetCenterPositionAndOpen(addNewDepartmentWindow);
        }
        private void OpenAddPositionWindow()
        {
            AddNewPositionWindow addNewPositionWindow = new AddNewPositionWindow();
            SetCenterPositionAndOpen(addNewPositionWindow);
        }
        private void OpenAddUserWindow()
        {
            AddNewUserWindow addNewUserWindow = new AddNewUserWindow();
            SetCenterPositionAndOpen(addNewUserWindow);
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
    }
}

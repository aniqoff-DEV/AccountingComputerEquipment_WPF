using AccountingComputerEquipment.Client.Commands;
using AccountingComputerEquipment.Client.Services;
using AccountingComputerEquipment.Client.Views.AdminWindows;
using AccountingComputerEquipment.Client.Views.EmployeeWindows;
using System.Windows;
using System.Windows.Input;

namespace AccountingComputerEquipment.Client.ViewModels
{
    public class MainViewModel
    {
        public string Email {  get; set; }
        public string Password {  get; set; }

        public ICommand IsVerificationUserCommand { get; set; }

        public MainViewModel()
        {
            IsVerificationUserCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            IsVerificationUser(obj);
        }

        private void IsVerificationUser(object obj)
        {
            var user = UserService.GetUserByEmailAndPassword(Email, Password);

            if (user is null)
            {
                MessageBox.Show("Email или пароль введены неверно");
                return;
            }

            var mainWindow = obj as Window;

            if (user.AccessLevelId > 1)
            {
                OfficeEqupmentWindow equpmentWindow = new(user.Id);
                equpmentWindow.Show();
                mainWindow.Close();
            }
            else
            {
                ViewRequestsWindow requestsWindow = new();
                requestsWindow.Show();
                mainWindow.Close();
            }
        }
    }
}

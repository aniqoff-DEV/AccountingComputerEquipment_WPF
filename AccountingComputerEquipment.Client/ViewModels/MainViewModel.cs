
using AccountingComputerEquipment.Client.Commands;
using AccountingComputerEquipment.Client.Data;
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

        private async void ShowWindow(object obj)
        {
            var mainWindow = obj as Window;
            
            OfficeEqupmentWindow equpmentWindow = new();
            equpmentWindow.Show();
            mainWindow.Close();  
        }
    }
}

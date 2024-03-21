using AccountingComputerEquipment.Client.Commands;
using AccountingComputerEquipment.Client.Models;
using AccountingComputerEquipment.Client.Views.AdminWindows;
using AccountingComputerEquipment.Client.Views;
using System.Windows.Input;
using System.Windows;

namespace AccountingComputerEquipment.Client.ViewModels.AdminViewModels
{
    public class RequestsViewModel
    {
        public ICommand ShowEmployeesWindowCommand { get; set; }
        public ICommand ShowAccoutingOEWindowCommand { get; set; }

        public RequestsViewModel()
        {
            ShowEmployeesWindowCommand = new RelayCommand(ShowEmployeesWindow, CanShowWindow);
            ShowAccoutingOEWindowCommand = new RelayCommand(ShowAccoutingWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowEmployeesWindow(object obj)
        {
            var requestsWindow = obj as Window;

            ViewEmployeesWindow employeesWindow = new();
            employeesWindow.Show();
            requestsWindow.Close();
        }

        private void ShowAccoutingWindow(object obj)
        {
            var requestsWindow = obj as Window;

            AccoutingOfficeEquipmentWindow accoutingWindow = new();
            accoutingWindow.Show();
            requestsWindow.Close();
        }
    }
}

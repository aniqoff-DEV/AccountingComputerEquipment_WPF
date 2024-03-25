using AccountingComputerEquipment.Client.Commands;
using AccountingComputerEquipment.Client.Models;
using AccountingComputerEquipment.Client.Services;
using AccountingComputerEquipment.Client.Views;
using AccountingComputerEquipment.Client.Views.AdminWindows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AccountingComputerEquipment.Client.ViewModels.AdminViewModels
{
    public class RequestsViewModel
    {
        public ObservableCollection<RequestModel> Requests { get; set; }
        public RequestModel SelectedRequest { get; set; }

        public ICommand ShowEmployeesWindowCommand { get; set; }
        public ICommand ShowAccoutingOEWindowCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand ShowAddOEonUserWindowCommand { get; set; }

        public RequestsViewModel()
        {
            Requests = RequestService.LoadRequestModels();
            ShowEmployeesWindowCommand = new RelayCommand(ShowEmployeesWindow, CanShowWindow);
            ShowAccoutingOEWindowCommand = new RelayCommand(ShowAccoutingWindow, CanShowWindow);
            ShowAddOEonUserWindowCommand = new RelayCommand(ShowAddOEonUserWindow, CanShowWindow);
            ExitCommand = new RelayCommand(ExitOnWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ExitOnWindow(object obj)
        {
            var requestsWindow = obj as Window;

            MainWindow mainWindow = new MainWindow();
            requestsWindow.Close();
            mainWindow.Show();
        }

        private void ShowAddOEonUserWindow(object obj)
        {
            var employessWindow = obj as Window;

            if(SelectedRequest is null)
            {
                MessageBox.Show("Выберите запрос!");
                return;
            }

            var currentUser = UserService.GetUserById(SelectedRequest.UserId);
            var currentOfficeEquipment = OfficeEquipmentService.GetOfficeEquipmentById(SelectedRequest.OfficeEquipmentId);

            AddOfficeEqupmentOnUserWindow addOEonUserWindow = new(currentUser!, currentOfficeEquipment);
            addOEonUserWindow.Owner = employessWindow;
            addOEonUserWindow.Show();
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

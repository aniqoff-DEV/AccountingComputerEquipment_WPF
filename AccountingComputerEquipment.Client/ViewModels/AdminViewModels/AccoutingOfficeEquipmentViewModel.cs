using AccountingComputerEquipment.Client.Commands;
using AccountingComputerEquipment.Client.Views.AdminWindows;
using System.Windows.Input;
using System.Windows;

namespace AccountingComputerEquipment.Client.ViewModels.AdminViewModels
{
    public class AccoutingOfficeEquipmentViewModel
    {
        public ICommand ShowRequestWindowCommand { get; set; }

        public AccoutingOfficeEquipmentViewModel()
        {
            ShowRequestWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private async void ShowWindow(object obj)
        {
            var accoutingWindow = obj as Window;

            ViewRequestsWindow requestsWindow = new();
            requestsWindow.Show();
            accoutingWindow.Close();
        }
    }
}

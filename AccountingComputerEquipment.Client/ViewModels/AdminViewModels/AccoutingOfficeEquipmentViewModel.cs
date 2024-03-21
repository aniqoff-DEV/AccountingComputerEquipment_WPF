using AccountingComputerEquipment.Client.Commands;
using AccountingComputerEquipment.Client.Views.AdminWindows;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using AccountingComputerEquipment.Client.Models;
using AccountingComputerEquipment.Client.Services;

namespace AccountingComputerEquipment.Client.ViewModels.AdminViewModels
{
    public class AccoutingOfficeEquipmentViewModel
    {
        public ObservableCollection<OfficeEquipment> OfficeEquipments { get; set; }

        public ICommand ShowRequestWindowCommand { get; set; }
        public ICommand ShowCreateEquipmentWindowCommand { get; set; }

        public AccoutingOfficeEquipmentViewModel()
        {
            OfficeEquipments = OfficeEquipmentService.LoadOfficeEquipments();
            ShowRequestWindowCommand = new RelayCommand(ShowRequestWindow, CanShowWindow);
            ShowCreateEquipmentWindowCommand = new RelayCommand(ShowCreateOEWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private async void ShowRequestWindow(object obj)
        {
            var accoutingWindow = obj as Window;

            ViewRequestsWindow requestsWindow = new();
            requestsWindow.Show();
            accoutingWindow.Close();
        }

        private async void ShowCreateOEWindow(object obj)
        {
            var accoutingWindow = obj as Window;

            AddOfficeEquipmentWindow officeEqupmentWindow = new();
            officeEqupmentWindow.Owner = accoutingWindow;
            officeEqupmentWindow.Show();
        }
    }
}

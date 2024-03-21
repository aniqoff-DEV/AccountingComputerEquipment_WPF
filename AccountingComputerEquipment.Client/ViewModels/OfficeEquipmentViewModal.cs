using AccountingComputerEquipment.Client.Commands;
using AccountingComputerEquipment.Client.Models;
using AccountingComputerEquipment.Client.Services;
using AccountingComputerEquipment.Client.Views.EmployeeWindows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AccountingComputerEquipment.Client.ViewModels
{
    public class OfficeEquipmentViewModal
    {
        public ObservableCollection<OfficeEquipment> MyOfficeEquipments { get; set; }

        public ICommand ShowRequestWindowCommand { get; set; }

        private int UserId { get; set; }

        public OfficeEquipmentViewModal(int userId)
        {
            MyOfficeEquipments = OfficeEquipmentService.LoadCurrentOfficeEquipments(userId);
            UserId = userId;
            ShowRequestWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private async void ShowWindow(object obj)
        {
            var mainWindow = obj as Window;

            SendRequestDialogWindow sendRequestDialogWindow = new SendRequestDialogWindow(UserId);
            sendRequestDialogWindow.Owner = mainWindow;
            sendRequestDialogWindow.Show();
        }
    }
}

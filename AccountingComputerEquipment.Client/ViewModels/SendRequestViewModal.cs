using AccountingComputerEquipment.Client.Commands;
using AccountingComputerEquipment.Client.Models;
using AccountingComputerEquipment.Client.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AccountingComputerEquipment.Client.ViewModels
{
    public class SendRequestViewModal
    {
        public ObservableCollection<OfficeEquipment> OfficeEquipments { get; set; }

        public string UserDescription { get; set; }

        public ICommand SendMessage { get; set; }

        public SendRequestViewModal(int userId)
        {
            OfficeEquipments = OfficeEquipmentService.LoadCurrentOfficeEquipments(userId);
            SendMessage = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private async void ShowWindow(object obj)
        {
           
        }
    }
}

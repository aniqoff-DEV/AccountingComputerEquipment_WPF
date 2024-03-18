using AccountingComputerEquipment.Client.Commands;
using AccountingComputerEquipment.Client.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AccountingComputerEquipment.Client.ViewModels
{
    public class SendRequestViewModal
    {
        public ObservableCollection<OfficeEquipment> OfficeEquipment { get; set; }

        public string UserDescription { get; set; }

        public ICommand SendMessage { get; set; }

        public SendRequestViewModal()
        {
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

using AccountingComputerEquipment.Client.Commands;
using AccountingComputerEquipment.Client.Models;
using AccountingComputerEquipment.Client.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AccountingComputerEquipment.Client.ViewModels
{
    public class SendRequestViewModal
    {
        public ObservableCollection<OfficeEquipment> OfficeEquipments { get; set; }
        public OfficeEquipment SelectedOfficeEquipment { get; set; }
        public string Description { get; set; }

        public ICommand SendMessage { get; set; }
        private int UserId { get; set; }

        public SendRequestViewModal(int userId)
        {
            UserId = userId;
            OfficeEquipments = OfficeEquipmentService.LoadCurrentOfficeEquipments(userId);
            SendMessage = new RelayCommand(CreateRequest, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void CreateRequest(object obj)
        {
            if (!DataValidate())
            {
                MessageBox.Show("Выберите оргетхнику и опишите проблему");
                return;
            }

            RequestService.CreateOfficeEquipment(new Request()
            {
                UserId = UserId,
                OfficeEquipmentId = SelectedOfficeEquipment.Id,
                Description = Description,
            });

            MessageBox.Show("Ваш запрос успешно отправлен!");
            ClearData();

            var sendRequestWindow = obj as Window;
            sendRequestWindow!.Close();
        }

        private bool DataValidate()
        {
            if(string.IsNullOrEmpty(Description) || SelectedOfficeEquipment is null) 
                return false;
            return true;
        }

        private void ClearData()
        {
            SelectedOfficeEquipment = new();
            Description = string.Empty;
        }
    }
}

using AccountingComputerEquipment.Client.ViewModels;
using System.Windows;

namespace AccountingComputerEquipment.Client.Views.EmployeeWindows
{
    /// <summary>
    /// Диалоговое окно отправки запросу админу, должен быть listview доступной оргтехники
    /// </summary>
    public partial class SendRequestDialogWindow : Window
    {
        public SendRequestDialogWindow(int userId)
        {
            InitializeComponent();
            SendRequestViewModal sendRequestViewModal = new SendRequestViewModal(userId);
            DataContext = sendRequestViewModal;
        }
    }
}

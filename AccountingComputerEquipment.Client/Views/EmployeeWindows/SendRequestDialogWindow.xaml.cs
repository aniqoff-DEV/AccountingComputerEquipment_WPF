using AccountingComputerEquipment.Client.ViewModels;
using System.Windows;

namespace AccountingComputerEquipment.Client.Views.EmployeeWindows
{
    /// <summary>
    /// Диалоговое окно отправки запросу админу, должен быть listview доступной оргтехники
    /// </summary>
    public partial class SendRequestDialogWindow : Window
    {
        public SendRequestDialogWindow()
        {
            InitializeComponent();
            SendRequestViewModal sendRequestViewModal = new SendRequestViewModal();
            DataContext = sendRequestViewModal;
        }
    }
}

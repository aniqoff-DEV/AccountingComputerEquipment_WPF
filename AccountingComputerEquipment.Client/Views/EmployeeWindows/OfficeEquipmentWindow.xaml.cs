using AccountingComputerEquipment.Client.ViewModels;
using System.Windows;

namespace AccountingComputerEquipment.Client.Views.EmployeeWindows
{
    /// <summary>
    /// ListView привязанной к сотруднику оргтехники
    /// </summary>
    public partial class OfficeEqupmentWindow : Window
    {
        public OfficeEqupmentWindow(int userId)
        {
            InitializeComponent();
            OfficeEquipmentViewModal officeEquipmentViewModal = new OfficeEquipmentViewModal(userId);
            DataContext = officeEquipmentViewModal;
        }
    }
}

using AccountingComputerEquipment.Client.ViewModels.AdminViewModels;
using System.Windows;

namespace AccountingComputerEquipment.Client.Views.AdminWindows
{
    /// <summary>
    /// Логика взаимодействия для AddOfficeEquipmentWindow.xaml
    /// </summary>
    public partial class AddOfficeEquipmentWindow : Window
    {
        public AddOfficeEquipmentWindow()
        {
            InitializeComponent();
            AddOfficeEquipmentViewModel addOfficeEquipmentViewModel = new AddOfficeEquipmentViewModel();
            DataContext = addOfficeEquipmentViewModel;
        }
    }
}

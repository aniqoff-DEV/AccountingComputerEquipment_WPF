using AccountingComputerEquipment.Client.ViewModels.AdminViewModels;
using System.Windows;

namespace AccountingComputerEquipment.Client.Views.AdminWindows
{
    /// <summary>
    /// Логика взаимодействия для AccoutingOfficeEquipment.xaml
    /// </summary>
    public partial class AccoutingOfficeEquipmentWindow : Window
    {
        public AccoutingOfficeEquipmentWindow()
        {
            InitializeComponent();
            AccoutingOfficeEquipmentViewModel accoutingViewModel = new AccoutingOfficeEquipmentViewModel();
            DataContext = accoutingViewModel;
        }
    }
}

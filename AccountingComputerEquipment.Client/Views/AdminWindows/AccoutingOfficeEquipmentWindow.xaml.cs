using AccountingComputerEquipment.Client.Models;
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

        private void FilterTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            OfficeEquipmentList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            var user = (OfficeEquipment)obj;

            return user.Name.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }
    }
}

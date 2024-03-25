using AccountingComputerEquipment.Client.Models;
using AccountingComputerEquipment.Client.ViewModels.AdminViewModels;
using System.Windows;

namespace AccountingComputerEquipment.Client.Views.AdminWindows
{
    public partial class AddOfficeEqupmentOnUserWindow : Window
    {
        public AddOfficeEqupmentOnUserWindow(User user, OfficeEquipment? officeEquipment = null)
        {
            InitializeComponent();
            AddOfficeEqupmentOnUserViewModel equpmentOnUserViewModel = new(user, officeEquipment);
            DataContext = equpmentOnUserViewModel;

            LoadForm(officeEquipment);
        }

        private void LoadForm(OfficeEquipment? officeEquipment)
        {
            if (officeEquipment is null)
                return;

            officeEquipmentsBox.Visibility = Visibility.Hidden;
            createButton.IsEnabled = false;
            createButton.Opacity = 0.5;
        }
    }
}

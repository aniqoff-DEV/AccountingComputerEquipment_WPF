using AccountingComputerEquipment.Client.Models;
using AccountingComputerEquipment.Client.ViewModels.AdminViewModels;
using System.Windows;
using System.Windows.Media.Imaging;

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

        private void officeEquipmentsBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var officeEquipment = officeEquipmentsBox.SelectedItem as OfficeEquipment;

            photo.Source = new BitmapImage(new Uri(officeEquipment.Photo));
            textBoxOE.Text = $"{officeEquipment.Name}" +
                $"\n{officeEquipment.Cost}\n{officeEquipment.Description}";
        }
    }
}

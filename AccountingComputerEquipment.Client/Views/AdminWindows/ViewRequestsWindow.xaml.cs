using AccountingComputerEquipment.Client.ViewModels.AdminViewModels;
using System.Windows;

namespace AccountingComputerEquipment.Client.Views.AdminWindows
{
    /// <summary>
    /// Логика взаимодействия для ViewRequestsWindow.xaml
    /// TODO не забыть обработать в этом коде событие по textBox`у
    /// </summary>
    public partial class ViewRequestsWindow : Window
    {
        public ViewRequestsWindow()
        {
            InitializeComponent();
            RequestsViewModel requestsViewModel = new RequestsViewModel();
            DataContext = requestsViewModel;
        }

        private void FilterTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            RequestList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            //var user = (User)obj;

            //return user.FullName.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
            return true;
        }
    }
}

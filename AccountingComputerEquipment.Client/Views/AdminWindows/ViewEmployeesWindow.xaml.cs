using AccountingComputerEquipment.Client.Models;
using AccountingComputerEquipment.Client.Services;
using AccountingComputerEquipment.Client.ViewModels.AdminViewModels;
using System.Windows;

namespace AccountingComputerEquipment.Client.Views.AdminWindows
{
    /// <summary>
    /// Логика взаимодействия для ViewRequestsWindow.xaml
    /// TODO не забыть обработать в этом коде событие по textBox`у и 
    /// передавать значение размера окна (requset - он должен закрываться) при открытии этого
    /// </summary>
    public partial class ViewEmployeesWindow : Window
    {
        public ViewEmployeesWindow()
        {
            InitializeComponent();
            ViewEmployeesViewModel employeesViewModel = new();
            DataContext = employeesViewModel;
        }

        private void FilterTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UserList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            var user = (User)obj;

            return user.FullName.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }
    }
}

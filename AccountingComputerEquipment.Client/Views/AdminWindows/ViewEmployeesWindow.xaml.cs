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
        }

        private void FilterTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}

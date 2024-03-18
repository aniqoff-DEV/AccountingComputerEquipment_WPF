using AccountingComputerEquipment.Client.Data;
using AccountingComputerEquipment.Client.ViewModels;
using System.Windows;

namespace AccountingComputerEquipment.Client.Views
{
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
        }
    }
}
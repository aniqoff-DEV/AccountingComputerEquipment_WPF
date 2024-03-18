using System.Windows.Input;

namespace AccountingComputerEquipment.Client.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action<object> _Excute { get; set; }
        private Predicate<object> _CanExcute { get; set; }

        public RelayCommand(Action<object> excute, Predicate<object> canExcute)
        {
            _Excute = excute;
            _CanExcute = canExcute;
        }

        public bool CanExecute(object? parameter)
        {
            return _CanExcute(parameter!);
        }

        public void Execute(object? parameter)
        {
            _Excute(parameter!);
        }
    }
}

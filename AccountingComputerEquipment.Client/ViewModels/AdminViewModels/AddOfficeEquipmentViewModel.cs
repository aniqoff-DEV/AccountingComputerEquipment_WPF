using AccountingComputerEquipment.Client.Commands;
using AccountingComputerEquipment.Client.Models;
using AccountingComputerEquipment.Client.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AccountingComputerEquipment.Client.ViewModels.AdminViewModels
{
    public class AddOfficeEquipmentViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? Cost { get; set; }
        public string Photo { get; set; } = string.Empty;
        private int? AccessLevelId { get; set; }

        public ObservableCollection<AccessLevel>? AccessLevelIdList { get; set; }
        public AccessLevel? SelectedAccessLevel { get; set; }

        public ICommand CreateOfficeEquipment { get; set; }

        public AddOfficeEquipmentViewModel()
        {
            AccessLevelIdList = AccessLevelService.LoadAccessLevels();
            CreateOfficeEquipment = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            if (!DataValidate()) return;

            var officeEquipmentToCreate = new OfficeEquipment()
            {
                Name = Name,
                Description = Description,
                Photo = Photo,
                Cost = (decimal)Cost!,
                AccessLevelId = (int)AccessLevelId!
            };

            OfficeEquipmentService.CreateOfficeEquipment(officeEquipmentToCreate);

            MessageBox.Show($"{officeEquipmentToCreate.Name} успешно был добавлен!");
            ClearData();
        }

        private bool DataValidate()
        {
            if (string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(Photo) ||
                SelectedAccessLevel is null ||
                Cost is null)
            {
                MessageBox.Show("Неверно заполена форма!");
                return false;
            }
            AccessLevelId = SelectedAccessLevel!.Id;
            return true;
        }

        private void ClearData()
        {
            Name = string.Empty;
            Description = string.Empty;
            Photo = string.Empty;
            Cost = null;
            SelectedAccessLevel = null;
            AccessLevelId = null;
        }
    }
}

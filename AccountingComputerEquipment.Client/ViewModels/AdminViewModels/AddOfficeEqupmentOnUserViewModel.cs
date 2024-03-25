using AccountingComputerEquipment.Client.Commands;
using AccountingComputerEquipment.Client.Models;
using AccountingComputerEquipment.Client.Services;
using AccountingComputerEquipment.Client.Views.AdminWindows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AccountingComputerEquipment.Client.ViewModels.AdminViewModels
{
    public class AddOfficeEqupmentOnUserViewModel
    {
        public ObservableCollection<OfficeEquipment?> OfficeEquipments { get; set; }
        public OfficeEquipment? SelectedOfficeEquipment { get; set; }
        public string Photo { get; set; }
        public string DescriptionOfficeEquipment { get; set; }
        public string DescriptionUser { get; set; }

        public ICommand CreateOfficeEquipmentOnUserCommand { get; set; }
        public ICommand ExitOnWindowCommand { get; set; }

        private User TransferredUser { get; set; }

        public AddOfficeEqupmentOnUserViewModel(User user, OfficeEquipment? officeEquipment = null)
        {
            TransferredUser = user;

            FillingInData(user,officeEquipment);
            CreateOfficeEquipmentOnUserCommand = new RelayCommand(CreateOfficeEquipmentOnUser, CanShowWindow);
            ExitOnWindowCommand = new RelayCommand(ExitWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ExitWindow(object obj)
        {
            var addOEonUserWindow = obj as Window;
            addOEonUserWindow.Close();
        }

        private bool DataValidate()
        {
            if (SelectedOfficeEquipment is null)
            {
                MessageBox.Show("Выберите оргтехнику для сотрудника!");
                return false;
            }
            return true;
        }

        private void CreateOfficeEquipmentOnUser(object obj)
        {
            if (!DataValidate()) 
                return;

            UserService.AddOfficeEquipment(SelectedOfficeEquipment.Id, TransferredUser.Id);

            MessageBox.Show("Операция прошла успешно");

            var addOEonUserWindow = obj as Window;
            addOEonUserWindow.Close();
        }

        private void FillingInData(User user, OfficeEquipment? officeEquipment = null)
        {
            if(officeEquipment is not null)
            {
                Photo = officeEquipment.Photo;
                DescriptionOfficeEquipment = $"{officeEquipment.Name}" +
                    $"\n{officeEquipment.Cost}\n{officeEquipment.Description}";
            }
            else
            {
                OfficeEquipments = OfficeEquipmentService.LoadOfficeEquipmentsByAccessLevelOnUser(user.AccessLevelId)!;
            }

            var accessLevel = AccessLevelService.GetById(user.AccessLevelId);

            DescriptionUser = $"{user.FullName}\nДолжность: {user.JobTitle}\n" +
                $"Контакты для связи:\n{user.TelephoneNumber}\n{user.Email}\nУровень доступа: {accessLevel!.Name}";
        }
    }
}

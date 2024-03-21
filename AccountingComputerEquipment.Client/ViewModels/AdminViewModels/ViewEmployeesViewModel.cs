﻿using AccountingComputerEquipment.Client.Commands;
using AccountingComputerEquipment.Client.Views.AdminWindows;
using System.Windows.Input;
using System.Windows;
using AccountingComputerEquipment.Client.Models;
using System.Collections.ObjectModel;
using AccountingComputerEquipment.Client.Services;

namespace AccountingComputerEquipment.Client.ViewModels.AdminViewModels
{
    public class ViewEmployeesViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public ICommand ShowRequestWindowCommand { get; set; }

        public ViewEmployeesViewModel()
        {
            Users = UserService.LoadEmployees();
            ShowRequestWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private async void ShowWindow(object obj)
        {
            var employessWindow = obj as Window;

            ViewRequestsWindow requestsWindow = new();
            requestsWindow.Show();
            employessWindow.Close();
        }
    }
}

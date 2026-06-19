using System.Collections.Generic;
using System.Windows;
using TestTask.Common;
using TestTask.Model.Entities;

namespace TestTask.View
{
    public class DialogService : IDialogService
    {
        public bool ShowEmployeeEdit(Employee employee)
            => new EmployeeEditDialog(employee).ShowDialog() == true;

        public bool ShowContractorEdit(Contractor contractor, IList<Employee> employees)
            => new ContractorEditDialog(contractor, employees).ShowDialog() == true;

        public bool ShowOrderEdit(Order order, IList<Employee> employees, IList<Contractor> contractors)
            => new OrderEditDialog(order, employees, contractors).ShowDialog() == true;

        public bool Confirm(string message)
            => MessageBox.Show(message, "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question)
               == MessageBoxResult.Yes;

        public void ShowError(string message)
            => MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}

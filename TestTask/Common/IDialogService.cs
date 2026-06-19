using System.Collections.Generic;
using TestTask.Model.Entities;

namespace TestTask.Common
{
    public interface IDialogService
    {
        bool ShowEmployeeEdit(Employee employee);
        bool ShowContractorEdit(Contractor contractor, IList<Employee> employees);
        bool ShowOrderEdit(Order order, IList<Employee> employees, IList<Contractor> contractors);
        bool Confirm(string message);
        void ShowError(string message);
    }
}

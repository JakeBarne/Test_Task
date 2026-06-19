using TestTask.Common;
using TestTask.Infrastructure.Repository;
using TestTask.Model.Entities;

namespace TestTask.ViewModel
{
    public class EmployeesViewModel : CrudViewModel<Employee>
    {
        public EmployeesViewModel(IRepository<Employee> repo, IDialogService dialogs)
            : base(repo, dialogs) { }

        protected override Employee NewEntity()                => new();
        protected override bool ShowDialog(Employee e)         => Dialogs.ShowEmployeeEdit(e);
        protected override string GetDeleteMessage(Employee e) => $"Удалить сотрудника «{e.FullName}»?";
    }
}

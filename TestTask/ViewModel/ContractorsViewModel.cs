using TestTask.Common;
using TestTask.Infrastructure.Repository;
using TestTask.Model.Entities;

namespace TestTask.ViewModel
{
    public class ContractorsViewModel : CrudViewModel<Contractor>
    {
        private readonly IRepository<Employee> _employees;

        public ContractorsViewModel(IRepository<Contractor> repo, IRepository<Employee> employees,
            IDialogService dialogs) : base(repo, dialogs)
        {
            _employees = employees;
        }

        protected override Contractor NewEntity()                => new();
        protected override bool ShowDialog(Contractor c)         => Dialogs.ShowContractorEdit(c, _employees.GetAll());
        protected override string GetDeleteMessage(Contractor c) => $"Удалить контрагента «{c.Name}»?";
    }
}

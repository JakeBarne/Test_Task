using TestTask.Common;
using TestTask.Infrastructure.Repository;
using TestTask.Model.Entities;

namespace TestTask.ViewModel
{
    public class OrdersViewModel : CrudViewModel<Order>
    {
        private readonly IRepository<Employee> _employees;
        private readonly IRepository<Contractor> _contractors;

        public OrdersViewModel(IRepository<Order> repo, IRepository<Employee> employees,
            IRepository<Contractor> contractors, IDialogService dialogs) : base(repo, dialogs)
        {
            _employees   = employees;
            _contractors = contractors;
        }

        protected override Order NewEntity()                => new();
        protected override bool ShowDialog(Order o)         => Dialogs.ShowOrderEdit(o, _employees.GetAll(), _contractors.GetAll());
        protected override string GetDeleteMessage(Order o) => $"Удалить приказ #{o.Id}?";
    }
}

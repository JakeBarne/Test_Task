namespace TestTask.ViewModel
{
    public class MainViewModel
    {
        public EmployeesViewModel EmployeesVm { get; }
        public ContractorsViewModel ContractorsVm { get; }
        public OrdersViewModel OrdersVm { get; }

        public MainViewModel(EmployeesViewModel employeesVm, ContractorsViewModel contractorsVm, OrdersViewModel ordersVm)
        {
            EmployeesVm = employeesVm;
            ContractorsVm = contractorsVm;
            OrdersVm = ordersVm;
        }
    }
}

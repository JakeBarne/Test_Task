using System;
using System.Collections.Generic;
using System.Windows;
using TestTask.Model.Entities;

namespace TestTask.View
{
    public partial class OrderEditDialog : Window
    {
        public Order Order { get; }

        public OrderEditDialog(Order order, IList<Employee> employees, IList<Contractor> contractors)
        {
            InitializeComponent();
            Order = order;
            CmbEmployee.ItemsSource = employees;
            CmbContractor.ItemsSource = contractors;
            DpDate.SelectedDate = order.Date == default ? DateTime.Today : order.Date;
            TxtAmount.Text = order.Amount == 0 ? "" : order.Amount.ToString("F2");
            CmbEmployee.SelectedItem = order.Employee;
            CmbContractor.SelectedItem = order.Contractor;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (DpDate.SelectedDate == null)
            {
                MessageBox.Show("Укажите дату.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!decimal.TryParse(TxtAmount.Text.Replace(',', '.'), System.Globalization.NumberStyles.Number,
                    System.Globalization.CultureInfo.InvariantCulture, out var amount) || amount <= 0)
            {
                MessageBox.Show("Введите корректную сумму.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (CmbEmployee.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (CmbContractor.SelectedItem == null)
            {
                MessageBox.Show("Выберите контрагента.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Order.Date = DpDate.SelectedDate.Value;
            Order.Amount = amount;
            Order.Employee = (Employee)CmbEmployee.SelectedItem;
            Order.Contractor = (Contractor)CmbContractor.SelectedItem;
            DialogResult = true;
        }

        private void CancelClick(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}

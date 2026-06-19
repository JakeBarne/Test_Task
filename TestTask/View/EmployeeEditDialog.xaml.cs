using System;
using System.Collections.Generic;
using System.Windows;
using TestTask.Model.Entities;

namespace TestTask.View
{
    public partial class EmployeeEditDialog : Window
    {
        public Employee Employee { get; }

        private record PositionItem(Position Value, string Display);

        private static readonly IReadOnlyList<PositionItem> PositionItems =
        [
            new(Position.Manager, "Руководитель"),
            new(Position.Worker,  "Работник"),
        ];

        public EmployeeEditDialog(Employee employee)
        {
            InitializeComponent();
            Employee = employee;

            CmbPosition.DisplayMemberPath = "Display";
            CmbPosition.SelectedValuePath = "Value";
            CmbPosition.ItemsSource       = PositionItems;

            TxtFullName.Text           = employee.FullName;
            CmbPosition.SelectedValue  = employee.Position;
            DpDateOfBirth.SelectedDate = employee.DateOfBirth == default
                ? DateTime.Today.AddYears(-25)
                : employee.DateOfBirth;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            var fullName = TxtFullName.Text.Trim();
            if (fullName.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Length < 2)
            {
                MessageBox.Show("Введите фамилию и имя через пробел.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (DpDateOfBirth.SelectedDate == null)
            {
                MessageBox.Show("Укажите дату рождения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Employee.FullName      = fullName;
            Employee.Position      = (Position)CmbPosition.SelectedValue;
            Employee.DateOfBirth   = DpDateOfBirth.SelectedDate.Value;
            DialogResult = true;
        }

        private void CancelClick(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}

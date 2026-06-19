using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using TestTask.Model.Entities;

namespace TestTask.View
{
    public partial class ContractorEditDialog : Window
    {
        private static readonly Regex InnPattern = new(@"^\d{10}$|^\d{12}$", RegexOptions.Compiled);

        public Contractor Contractor { get; }

        public ContractorEditDialog(Contractor contractor, IList<Employee> employees)
        {
            InitializeComponent();
            Contractor = contractor;
            CmbCurator.ItemsSource = employees;
            TxtName.Text = contractor.Name;
            TxtINN.Text = contractor.INN;
            CmbCurator.SelectedItem = contractor.Curator;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtName.Text))
            {
                MessageBox.Show("Введите наименование.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var inn = TxtINN.Text.Trim();
            if (!InnPattern.IsMatch(inn))
            {
                MessageBox.Show("ИНН должен содержать 10 цифр для юр. лиц или 12 цифр для физ. лиц.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Contractor.Name = TxtName.Text.Trim();
            Contractor.INN = inn;
            Contractor.Curator = CmbCurator.SelectedItem as Employee;
            DialogResult = true;
        }

        private void CancelClick(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}

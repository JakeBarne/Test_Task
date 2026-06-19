using System.Windows;
using TestTask.ViewModel;

namespace TestTask.View
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}

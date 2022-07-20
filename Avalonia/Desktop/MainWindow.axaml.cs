using Avalonia.Controls;
using Desktop.Pages;
using Desktop.ViewModel;

namespace Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; }
        
        public MainWindow()
        {
            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;

            InitializeComponent();

            ViewModel.Page = new FreeDrawPage();
        }
    }
}
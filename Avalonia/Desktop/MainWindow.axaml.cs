using System.Threading.Tasks;
using Avalonia.ReactiveUI;
using Desktop.Dialogs;
using Desktop.Pages;
using Desktop.ViewModels;
using ReactiveUI;
using DashboardDialog = Desktop.Dialogs.Dashboard.DashboardDialog;

namespace Desktop
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainWindowViewModel();

            var dashboardHandler = ViewModel!.ShowDashboard.RegisterHandler(DoShowDashboardAsync);
            this.WhenActivated(d => d(dashboardHandler));
        }

        private async Task DoShowDashboardAsync(InteractionContext<DashboardDialogViewModel, PageOpenInfo> interaction)
        {
            var dialog = new DashboardDialog
            {
                DataContext = interaction.Input
            };

            var result = await dialog.ShowDialog<PageOpenInfo>(this);
            interaction.SetOutput(result);
        }
    }
}
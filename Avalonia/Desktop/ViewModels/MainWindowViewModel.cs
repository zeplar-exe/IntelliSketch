using System.Reactive.Linq;
using System.Windows.Input;
using Desktop.Pages;
using ReactiveUI;

namespace Desktop.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    private PageControl? b_page;
    
    public ICommand OpenDashboardCommand { get; }
    public Interaction<DashboardDialogViewModel, PageOpenInfo> ShowDashboard { get; }

    public PageControl? Page
    {
        get => b_page;
        set => this.RaiseAndSetIfChanged(ref b_page, value);
    }

    public MainWindowViewModel()
    {
        ShowDashboard = new Interaction<DashboardDialogViewModel, PageOpenInfo>();
        OpenDashboardCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var dashboard = new DashboardDialogViewModel();
            var result = await ShowDashboard.Handle(dashboard);
        });
    }
}
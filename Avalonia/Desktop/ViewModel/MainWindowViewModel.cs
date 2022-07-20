using Desktop.Pages;
using ReactiveUI;

namespace Desktop.ViewModel;

public class MainWindowViewModel : ReactiveObject
{
    private PageControl? b_page;

    public PageControl? Page
    {
        get => b_page;
        set => this.RaiseAndSetIfChanged(ref b_page, value);
    }
}
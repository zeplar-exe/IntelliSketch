using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Desktop.Dialogs.Dashboard;

public partial class DashboardDialog : Window
{
    public DashboardDialog()
    {
        InitializeComponent();
        #if DEBUG
        this.AttachDevTools();
        #endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
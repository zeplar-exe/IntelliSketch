using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Desktop.Dialogs.Dashboard;

public partial class DashboardItem : UserControl
{
    public string Header { get; set; }
    public string Description { get; set; }
    
    public DashboardItem()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
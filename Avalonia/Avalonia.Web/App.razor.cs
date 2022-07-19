using Avalonia.Web.Blazor;

namespace Avalonia.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        
        WebAppBuilder.Configure<Avalonia.App>()
            .SetupWithSingleViewLifetime();
    }
}
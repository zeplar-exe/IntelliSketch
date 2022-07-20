using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Desktop.Graphics;

namespace Desktop.Controls;

public partial class CanvasElement : UserControl
{
    public MouseDrawInjector MouseDraw { get; }
    
    public CanvasElement()
    {
        InitializeComponent();
        
        MouseDraw = new MouseDrawInjector(this);
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);
        
        context.DrawImage(MouseDraw.Bitmap, new Rect(0, 0, Width, Height));
    }
}
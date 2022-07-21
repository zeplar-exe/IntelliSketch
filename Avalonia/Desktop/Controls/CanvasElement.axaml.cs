using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Desktop.Graphics;

namespace Desktop.Controls;

public partial class CanvasElement : UserControl
{
    private Point PreviousPointerPosition { get; set; }
    private bool PointerPressed { get; set; }
    private WriteableBitmap Bitmap { get; }
    
    public CanvasElement()
    {
        InitializeComponent();

        Bitmap = new WriteableBitmap();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        context.DrawImage(Bitmap, new Rect(0, 0, Width, Height));
    }
    
    private void OnPointerMoved(object? sender, PointerEventArgs e)
    {
        if (!PointerPressed)
            return;
        
        e.Pointer.Capture(Element);
        
        Draw(e.GetPosition(Element));
    }

    private unsafe void Draw(Point point)
    {
        using var buffer = Bitmap.Lock();
        var size = buffer.Size;

        var ptr = buffer.Address;
    }

    private byte[] CreatePixel(PixelFormat format, ArgbColor color)
    {
        return format switch
        {
            PixelFormat.Rgb565 => new[] { color.R, color.G, color.B },
            PixelFormat.Rgba8888 => new[] { color.R, color.G, color.B, color.A },
            PixelFormat.Bgra8888 => new[] { color.B, color.G, color.R, color.A },
            _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
        };
    }
    
    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        PointerPressed = true;
    }
    
    private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        PointerPressed = false;
    }
    
    private void OnPointerLeave(object? sender, PointerEventArgs e)
    {
        PointerPressed = false;
    }
}
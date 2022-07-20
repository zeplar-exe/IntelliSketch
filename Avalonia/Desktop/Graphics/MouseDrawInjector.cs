using System;
using Avalonia;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Desktop.Graphics;

public class MouseDrawInjector
{
    private bool PointerPressed { get; set; }
    private InputElement Element { get; }

    public WriteableBitmap Bitmap { get; }

    public MouseDrawInjector(InputElement element)
    {
        Element = element;
        // Bitmap = new WriteableBitmap();
    }

    public void Hook()
    {
        Element.PointerMoved += OnPointerMoved;
        Element.PointerPressed += OnPointerPressed;
        Element.PointerReleased += OnPointerReleased;
        Element.PointerLeave += OnPointerLeave;
    }

    public void Unhook()
    {
        Element.PointerMoved -= OnPointerMoved;
        Element.PointerPressed -= OnPointerPressed;
        Element.PointerReleased -= OnPointerReleased;
        Element.PointerLeave -= OnPointerLeave;
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
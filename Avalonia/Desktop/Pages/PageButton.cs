using System;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Desktop.Pages;

public class PageButton
{
    public IImage? Image { get; set; }
    public EventHandler<RoutedEventArgs>? OnClick { get; set; }

    public void Invoke(object? sender, RoutedEventArgs args)
    {
        OnClick?.Invoke(sender ?? this, args);
    }
}
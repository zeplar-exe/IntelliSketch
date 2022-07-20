using System.Collections.Generic;
using Avalonia.Controls;

namespace Desktop.Pages;

public class PageControl : UserControl
{
    public IEnumerable<PageButton> Buttons { get; protected set; }
}
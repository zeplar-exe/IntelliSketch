using System.Collections;
using System.Linq;
using Avalonia.Controls;

namespace Desktop.Pages;

public class PageControl : UserControl
{
    public IEnumerable Buttons { get; protected set; } = Enumerable.Empty<object>();
}
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WpfLikeAvaloniaNavigation;

namespace MM264;


public partial class WebFrame2 : UserControl
{
    public WebFrame2()
    {
        InitializeComponent();
        WebFrame.Navigate(new Auth());
    }
}
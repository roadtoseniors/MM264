using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WpfLikeAvaloniaNavigation;

namespace MM264;

public partial class WebMainPage : Page
{
    public WebMainPage()
    {
        InitializeComponent();
        MainFrame.Navigate<WebAuthPage>();
    }
}
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WpfLikeAvaloniaNavigation;

namespace MM264;

public partial class Auth : Page
{
    public Auth()
    {
        InitializeComponent();
    }

    private void Auth_Button_OnClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationService.Navigate(new Main());
    }
}
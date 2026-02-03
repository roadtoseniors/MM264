using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WpfLikeAvaloniaNavigation;

namespace MM264;

public partial class AuthPage : Page
{
    public AuthPage()
    {
        InitializeComponent();
    }

    private void Auth_Button_OnClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationService.Navigate(new MainPage());
    }
}
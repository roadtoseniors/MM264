using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WpfLikeAvaloniaNavigation;

namespace MM264;

public partial class DesktopAuthPage : Page
{
    public DesktopAuthPage()
    {
        InitializeComponent();
    }

    private async void Auth_Button_OnClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (await API.Instance.Auth(Login_Box.Text, Password_Box.Text))
        {
            NavigationService.Navigate(new DesktopMainPage());
        }
    }
}
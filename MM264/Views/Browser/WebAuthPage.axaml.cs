using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Threading.Tasks;
using WpfLikeAvaloniaNavigation;

namespace MM264;

public partial class WebAuthPage : Page
{
    public WebAuthPage()
    {
        InitializeComponent();
    }

    private async void Auth_Button_OnClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //string login = Login_Box.Text;
        //string password = Password_Box.Text;
        if (await API.Instance.Auth(Login_Box.Text, Password_Box.Text))
        {
            NavigationService.Navigate(new WebPageChoXotite());
        }
    }

}
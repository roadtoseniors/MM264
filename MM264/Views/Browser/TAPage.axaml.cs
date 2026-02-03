using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WpfLikeAvaloniaNavigation;

namespace MM264;

public partial class TAPage : Page
{
    public TAPage()
    {
        InitializeComponent();
    }

    private void Back_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationService?.GoBack();
    }
}
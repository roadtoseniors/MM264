using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using WpfLikeAvaloniaNavigation;

namespace MM264;

public partial class GraficPage : Page
{
    public GraficPage()
    {
        InitializeComponent();
    }

    private void Back_Click(object? sender, RoutedEventArgs e)
    {
        NavigationService?.GoBack();
    }
}
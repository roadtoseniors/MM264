using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WpfLikeAvaloniaNavigation;

namespace MM264;

public partial class Main : Page
{
    public Main()
    {
        InitializeComponent();
    }

    private void Vending_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationService.Navigate(new Vending());
    }

    private void Calendar_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationService.Navigate(new Calendar());
    }

    private void Grafic_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationService.Navigate(new Grafic());
    }
}
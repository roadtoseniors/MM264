using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WpfLikeAvaloniaNavigation;

namespace MM264;

public partial class WebPageChoXotite : Page
{
    public WebPageChoXotite()
    {
        InitializeComponent();
    }

    private void TA_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationService?.Navigate(new TAPage());
    }

    private void Calendar_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationService?.Navigate(new CalendarPage());
    }

    private void Grafic_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationService?.Navigate(new GraficPage());
    }
}
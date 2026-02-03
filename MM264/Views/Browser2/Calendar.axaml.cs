using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WpfLikeAvaloniaNavigation;

namespace MM264;

public partial class Calendar : Page
{
    public Calendar()
    {
        InitializeComponent();
        CalendarFrame.Navigate(new Week());
    }

    private void Week_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        CalendarFrame.Navigate(new Week());
    }

    private void Month_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        CalendarFrame.Navigate(new Month());
    }

    private void Yaer_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        CalendarFrame.Navigate(new Year());
    }
}
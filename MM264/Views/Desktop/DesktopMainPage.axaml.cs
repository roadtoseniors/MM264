using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MM264.Entities;
using WpfLikeAvaloniaNavigation;

namespace MM264;

public partial class DesktopMainPage : Page
{
    public User CurrentUser { get; set; } //��������

    //public User CurrentUser - � ��� ����, ��� ���� ��� ���� ��������� ���
    public DesktopMainPage()
    {
        InitializeComponent();
        CurrentUser = API.Instance.AuthUser;
        DataContext = this;
        DesktopFrame.Navigate(new DesktopMainFrame());
    }


    private void VendingMachine_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DesktopFrame.Navigate(new AdminTA());
    }

    //private void ShowButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    //{
    //    ShowPanel.IsVisible = !ShowPanel.IsVisible;
    //}

    //private void DetailShowButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    //{
    //    DetailShowPanel.IsVisible = !DetailShowPanel.IsVisible;
    //}

    //private void AccountingShowButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    //{
    //    AccountingShowPanel.IsVisible = !AccountingShowPanel.IsVisible;
    //}

    //private void AdminShowButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    //{
    //    AdminShowPanel.IsVisible = !AdminShowPanel.IsVisible;
    //}

    //private void UserShow_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    //{
    //    UserShowPanel.IsVisible = !UserShowPanel.IsVisible;
    //}

    //private void TAAdmin_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    //{
    //    //NavigationService.Navigate(new AdminTA());
    //    Frame.Navigate<AdminTA>();
    //}
}
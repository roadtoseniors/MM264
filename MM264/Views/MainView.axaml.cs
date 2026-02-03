using Avalonia.Controls;

namespace MM264.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        MainFrame.Navigate(new DesktopAuthPage());
    }
}
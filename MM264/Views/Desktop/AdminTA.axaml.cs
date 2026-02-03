using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MM264.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfLikeAvaloniaNavigation;

namespace MM264;

public partial class AdminTA : Page
{
    public List<VendingMachine> VendingMachines;

    public AdminTA()
    {
        InitializeComponent();
        Load();
    }

    private async void Load()
    {
        VendingMachines = await API.Instance.GetVendingMachines();
        Load2();
    }

    private void Load2()
    {
        TableVending.ItemsSource = new ObservableCollection<VendingMachine>(VendingMachines);

    }

    private void Create_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationService.Navigate(new CreateVendingFrame());
    }
}
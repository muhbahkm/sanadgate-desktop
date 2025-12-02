using System.Windows;
using SanadGate.Desktop.ViewModels;

namespace SanadGate.Desktop.Views;

public partial class HistoryWindow : Window
{
    private readonly HistoryViewModel _vm;

    public HistoryWindow()
    {
        InitializeComponent();
        _vm = new HistoryViewModel();
        DataContext = _vm;
        TransactionsGrid.ItemsSource = _vm.Transactions;
    }
}

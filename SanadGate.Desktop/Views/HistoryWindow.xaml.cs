using System;
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

    private void OnExportCsvClick(object sender, RoutedEventArgs e)
    {
        var items = _vm.Transactions;
        var dlg = new Microsoft.Win32.SaveFileDialog()
        {
            FileName = "transactions",
            DefaultExt = ".csv",
            Filter = "CSV files (.csv)|*.csv"
        };

        bool? result = dlg.ShowDialog(this);
        if (result == true)
        {
            try
            {
                using var sw = new System.IO.StreamWriter(dlg.FileName);
                sw.WriteLine("Date,Time,Amount,Reference,Cashier");
                foreach (var t in items)
                {
                    var date = t.CreatedAt.ToString("yyyy-MM-dd");
                    var time = t.CreatedAt.ToString("HH:mm:ss");
                    sw.WriteLine($"{date},{time},{t.Amount},{t.InvoiceRef},{t.CashierName}");
                }
                MessageBox.Show(this, "تم تصدير السجل بنجاح.", "تصدير CSV", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "فشل التصدير: " + ex.Message, "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

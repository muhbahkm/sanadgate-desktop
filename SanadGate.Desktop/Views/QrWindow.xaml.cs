using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using SanadGate.Desktop.Models;
using SanadGate.Desktop.Services;

namespace SanadGate.Desktop.Views;

public partial class QrWindow : Window
{
    private readonly QrGeneratorService _qrService = new QrGeneratorService();
    private InvoiceModel? _currentInvoice;

    public QrWindow()
    {
        InitializeComponent();
        this.PreviewKeyDown += QrWindow_PreviewKeyDown;
    }

    private void QrWindow_PreviewKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            this.Close();
            e.Handled = true;
        }

        if (e.Key == Key.Enter)
        {
            // Confirm payment — close and mark dialog result true
            this.DialogResult = true;
            this.Close();
            e.Handled = true;
        }
    }

    public void ShowQr(string payload, InvoiceModel model)
    {
        _currentInvoice = model;
        // Generate QR and assign image
        var bytes = System.Text.Encoding.UTF8.GetBytes(payload);

        // We can reuse the service by building a dictionary
        var data = new System.Collections.Generic.Dictionary<string, object>
        {
            { "payload", payload }
        };

        BitmapImage? img = _qrService.GenerateQrCode(data);
        if (img != null)
            QrImage.Source = img;

        TxtMerchant.Text = $"المتجر: {model.MerchantName}";
        TxtAmount.Text = $"المبلغ: {model.Amount}";
        TxtReference.Text = $"المرجع: {model.ReferenceNumber}";
        TxtCashier.Text = $"الكاشير: {model.CashierName}";
        TxtNotes.Text = string.IsNullOrWhiteSpace(model.Notes) ? "" : $"ملاحظات: {model.Notes}";

        // show as dialog so Enter/Esc behave
        this.ShowDialog();
    }

    private void OnConfirm(object sender, RoutedEventArgs e)
    {
        this.DialogResult = true;
        this.Close();
    }

    private void OnClose(object sender, RoutedEventArgs e)
    {
        this.DialogResult = false;
        this.Close();
    }
}

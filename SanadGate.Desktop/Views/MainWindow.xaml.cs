using System;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using SanadGate.Desktop.ViewModels;
using SanadGate.Desktop.Views;
using SanadGate.Desktop.Models;

namespace SanadGate.Desktop.Views;

public partial class MainWindow : Window
{
    private MainViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        
        _viewModel = new MainViewModel();
        DataContext = _viewModel;
    }

    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        
        // Set window size to reasonable dimensions
        this.Width = 1200;
        this.Height = 700;
        
        // Center window on screen
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
    {
        base.OnKeyDown(e);
        // Alt+Enter => Process Payment (legacy)
        if (e.Key == Key.Return && (Keyboard.Modifiers & ModifierKeys.Alt) != 0)
        {
            _viewModel.ProcessPaymentCommand.Execute(null);
            e.Handled = true;
            return;
        }

        // Enter -> regenerate QR immediately
        if (e.Key == Key.Return && (Keyboard.Modifiers & ModifierKeys.Alt) == 0)
        {
            _viewModel.GenerateQrCode();
            e.Handled = true;
            return;
        }

        // Esc to cancel
        if (e.Key == Key.Escape)
        {
            _viewModel.CancelCommand.Execute(null);
            e.Handled = true;
            return;
        }

        // F2 -> Open full-screen QR window
        if (e.Key == Key.F2)
        {
            OpenQrWindow();
            e.Handled = true;
            return;
        }

        // Ctrl+S -> Settings
        if (e.Key == Key.S && (Keyboard.Modifiers & ModifierKeys.Control) != 0)
        {
            OpenSettingsWindow();
            e.Handled = true;
            return;
        }

        // Ctrl+H -> History
        if (e.Key == Key.H && (Keyboard.Modifiers & ModifierKeys.Control) != 0)
        {
            OpenHistoryWindow();
            e.Handled = true;
            return;
        }
    }

    private void OpenQrWindow()
    {
        // Build payload mirroring the view model
        var data = new System.Collections.Generic.Dictionary<string, object>
        {
            { "amount", decimal.TryParse(_viewModel.TotalAmount, out var am) ? am : 0m },
            { "invoiceRef", _viewModel.InvoiceReference },
            { "merchantName", _viewModel.MerchantName },
            { "merchantAccount", _viewModel.MerchantAccount },
            { "cashier", _viewModel.CashierName },
            { "notes", _viewModel.Notes },
            { "timestamp", System.DateTime.UtcNow.ToString("o") }
        };

        var payload = JsonConvert.SerializeObject(data);

        var invoice = new InvoiceModel
        {
            ReferenceNumber = _viewModel.InvoiceReference,
            Amount = decimal.TryParse(_viewModel.TotalAmount, out var amt) ? amt : 0m,
            CashierName = _viewModel.CashierName,
            MerchantName = _viewModel.MerchantName,
            MerchantAccount = _viewModel.MerchantAccount,
            Notes = _viewModel.Notes
        };

        var qr = new QrWindow();
        qr.Owner = this;
        // ShowQr will display the dialog and block until closed
        qr.ShowQr(payload, invoice);
        // If dialog closed with true (Enter), process payment
        if (qr.DialogResult == true)
            _viewModel.ProcessPaymentCommand.Execute(null);
    }

    private void OpenSettingsWindow()
    {
        var settingsWindow = new SettingsWindow();
        var settingsViewModel = (SettingsViewModel)settingsWindow.DataContext;
        
        settingsViewModel.SettingsSaved += (s, settings) =>
        {
            _viewModel.UpdateSettingsFromWindow(settings);
            settingsWindow.Close();
        };

        settingsWindow.Owner = this;
        settingsWindow.ShowDialog();
    }

    private void OpenHistoryWindow()
    {
        var history = new HistoryWindow();
        history.Owner = this;
        history.ShowDialog();
    }

    private void OnPayClick(object sender, RoutedEventArgs e)
    {
        _viewModel.ProcessPaymentCommand.Execute(null);
    }

    private void OnCancelClick(object sender, RoutedEventArgs e)
    {
        _viewModel.CancelCommand.Execute(null);
    }

    private void OnSettingsClick(object sender, RoutedEventArgs e)
    {
        OpenSettingsWindow();
    }

    private void OnHistoryClick(object sender, RoutedEventArgs e)
    {
        OpenHistoryWindow();
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using SanadGate.Desktop.Models;
using SanadGate.Desktop.Services;

namespace SanadGate.Desktop.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly QrGeneratorService _qrService;
    private readonly SqliteService _sqliteService;
    private readonly SettingsService _settingsService;
    private readonly DispatcherTimer _debounceTimer;

    private string _totalAmount = "";
    private string _invoiceReference = "";
    private string _cashierName = "";
    private string _notes = "";
    private BitmapImage? _qrCodeImage;
    private string _merchantName = "متجري";
    private string _merchantAccount = "000000";
    private string _currency = "ريال يمني";

    public MainViewModel()
    {
        _qrService = new QrGeneratorService();
        _sqliteService = new SqliteService();
        _settingsService = new SettingsService();

        // Load settings
        var settings = _settingsService.GetSettings();
        _merchantName = settings.MerchantName;
        _merchantAccount = settings.MerchantAccount;

        // Debounce timer for QR generation
        _debounceTimer = new DispatcherTimer();
        _debounceTimer.Interval = TimeSpan.FromMilliseconds(200);
        _debounceTimer.Tick += (s, e) =>
        {
            _debounceTimer.Stop();
            GenerateQrCode();
        };

        // Initialize commands
            ProcessPaymentCommand = new RelayCommand(_ => ProcessPayment(), _ => CanProcessPayment());
            CancelCommand = new RelayCommand(_ => Cancel());
            SettingsCommand = new RelayCommand(_ => { /* handled by view */ });
            HistoryCommand = new RelayCommand(_ => { /* handled by view */ });
    }

    // Properties
    public string TotalAmount
    {
        get => _totalAmount;
        set
        {
            if (SetProperty(ref _totalAmount, value))
                OnInputChanged();
        }
    }

    public string InvoiceReference
    {
        get => _invoiceReference;
        set
        {
            if (SetProperty(ref _invoiceReference, value))
                OnInputChanged();
        }
    }

    public string CashierName
    {
        get => _cashierName;
        set
        {
            if (SetProperty(ref _cashierName, value))
                OnInputChanged();
        }
    }

    public string Notes
    {
        get => _notes;
        set
        {
            if (SetProperty(ref _notes, value))
                OnInputChanged();
        }
    }

    public BitmapImage? QrCodeImage
    {
        get => _qrCodeImage;
        set => SetProperty(ref _qrCodeImage, value);
    }

        public ICommand HistoryCommand { get; }

    public string MerchantName
    {
        get => _merchantName;
        set => SetProperty(ref _merchantName, value);
    }

    public string MerchantAccount
    {
        get => _merchantAccount;
        set => SetProperty(ref _merchantAccount, value);
    }

    public string Currency => _currency;

    // Commands
    public ICommand ProcessPaymentCommand { get; }
    public ICommand CancelCommand { get; }
    public ICommand SettingsCommand { get; }

    // Methods
    private void OnInputChanged()
    {
        _debounceTimer.Stop();
        _debounceTimer.Start();
    }

    public void GenerateQrCode()
    {
        if (string.IsNullOrWhiteSpace(_totalAmount) || !decimal.TryParse(_totalAmount, out var amount))
        {
            QrCodeImage = null;
            return;
        }

        var data = new Dictionary<string, object>
        {
            { "amount", amount },
            { "invoiceRef", _invoiceReference },
            { "merchantName", _merchantName },
            { "merchantAccount", _merchantAccount },
            { "cashier", _cashierName },
            { "notes", _notes },
            { "timestamp", DateTime.UtcNow.ToString("o") }
        };

        QrCodeImage = _qrService.GenerateQrCode(data);
    }

    private bool CanProcessPayment()
    {
        return !string.IsNullOrWhiteSpace(_totalAmount) && 
               decimal.TryParse(_totalAmount, out var amount) && 
               amount > 0;
    }

    private void ProcessPayment()
    {
        if (!CanProcessPayment())
            return;

        var transaction = new TransactionRecord
        {
            MerchantName = _merchantName,
            MerchantAccount = _merchantAccount,
            Amount = decimal.Parse(_totalAmount),
            InvoiceRef = _invoiceReference,
            CashierName = _cashierName,
            Notes = _notes,
            Status = "completed",
            CreatedAt = DateTime.UtcNow
        };

        try
        {
                _sqliteService.InsertTransaction(transaction);
            ClearFields();
            // TODO: Show confirmation message
        }
        catch (Exception ex)
        {
            // TODO: Show error message
            System.Diagnostics.Debug.WriteLine($"Error saving transaction: {ex.Message}");
        }
    }

    private void ClearFields()
    {
        TotalAmount = "";
        InvoiceReference = "";
        CashierName = "";
        Notes = "";
        QrCodeImage = null;
    }

    private void Cancel()
    {
        ClearFields();
    }

    private void OpenSettings()
    {
        // This will be handled by the main window
        // The window will handle opening the settings dialog
    }

    public void UpdateSettingsFromWindow(AppSettings settings)
    {
        MerchantName = settings.MerchantName;
        MerchantAccount = settings.MerchantAccount;
        GenerateQrCode();
    }
}

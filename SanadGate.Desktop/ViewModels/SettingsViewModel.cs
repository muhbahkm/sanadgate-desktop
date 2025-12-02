using System;
using System.Windows.Input;
using System.Windows.Media;
using SanadGate.Desktop.Models;
using SanadGate.Desktop.Services;

namespace SanadGate.Desktop.ViewModels;

public class SettingsViewModel : ViewModelBase
{
    private readonly SettingsService _settingsService;
    private string _merchantName = "";
    private string _merchantAccount = "";
    private string _contactNumber = "";
    private string _themeColor = "#2E7D32";
    private bool _enableLargeFont;
    private bool _enableSqliteLogging = true;

    public SettingsViewModel()
    {
        _settingsService = new SettingsService();
        LoadSettings();

        SaveCommand = new RelayCommand(_ => SaveSettings());
        CancelCommand = new RelayCommand(_ => Cancel());
        PickColorCommand = new RelayCommand(_ => PickColor());
    }

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

    public string ContactNumber
    {
        get => _contactNumber;
        set => SetProperty(ref _contactNumber, value);
    }

    public string ThemeColor
    {
        get => _themeColor;
        set => SetProperty(ref _themeColor, value);
    }

    public bool EnableLargeFont
    {
        get => _enableLargeFont;
        set => SetProperty(ref _enableLargeFont, value);
    }

    public bool EnableSqliteLogging
    {
        get => _enableSqliteLogging;
        set => SetProperty(ref _enableSqliteLogging, value);
    }

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }
    public ICommand PickColorCommand { get; }

    public event EventHandler<AppSettings>? SettingsSaved;

    private void LoadSettings()
    {
        var settings = _settingsService.GetSettings();
        MerchantName = settings.MerchantName;
        MerchantAccount = settings.MerchantAccount;
        ContactNumber = settings.ContactNumber;
        ThemeColor = settings.ThemeColor;
        EnableLargeFont = settings.EnableLargeFont;
        EnableSqliteLogging = settings.EnableSqliteLogging;
    }

    private void SaveSettings()
    {
        var settings = new AppSettings
        {
            MerchantName = _merchantName,
            MerchantAccount = _merchantAccount,
            ContactNumber = _contactNumber,
            ThemeColor = _themeColor,
            EnableLargeFont = _enableLargeFont,
            EnableSqliteLogging = _enableSqliteLogging,
            DatabasePath = "sanadgate.db"
        };

        _settingsService.SaveSettings(settings);
        SettingsSaved?.Invoke(this, settings);
    }

    private void Cancel()
    {
        LoadSettings();
    }

    private void PickColor()
    {
        // This will be handled by the settings window
        // For now, we can open a color picker dialog
    }
}

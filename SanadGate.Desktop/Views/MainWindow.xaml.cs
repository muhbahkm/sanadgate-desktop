using System;
using System.Windows;
using System.Windows.Input;
using SanadGate.Desktop.ViewModels;

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

        // Ctrl+S to save
        if (e.Key == System.Windows.Input.Key.Return && 
            (System.Windows.Input.Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Alt) != 0)
        {
            _viewModel.ProcessPaymentCommand.Execute(null);
        }

        // Esc to cancel
        if (e.Key == System.Windows.Input.Key.Escape)
        {
            _viewModel.CancelCommand.Execute(null);
        }

        // F2 for settings
        if (e.Key == System.Windows.Input.Key.F2)
        {
            OpenSettingsWindow();
        }
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
}

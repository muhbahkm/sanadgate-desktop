using System;
using System.Windows;
using SanadGate.Desktop.ViewModels;

namespace SanadGate.Desktop.Views;

public partial class SettingsWindow : Window
{
    public SettingsWindow()
    {
        InitializeComponent();
        DataContext = new SettingsViewModel();
    }
}

using System;
using System.IO;
using System.Text.Json;
using SanadGate.Desktop.Models;

namespace SanadGate.Desktop.Services;

public class SettingsService
{
    private readonly string _settingsPath;
    private AppSettings _settings;

    public SettingsService(string settingsPath = "appsettings.json")
    {
        _settingsPath = settingsPath;
        _settings = LoadSettings();
    }

    public AppSettings GetSettings() => _settings;

    public void SaveSettings(AppSettings settings)
    {
        _settings = settings;
        var json = JsonSerializer.Serialize(_settings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_settingsPath, json);
        try
        {
            // Also persist to sqlite settings table for quick retrieval
            var sqlite = new SqliteService();
            sqlite.SaveSettings("appsettings", json);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Warning: failed to save settings to sqlite: {ex.Message}");
        }
    }

    private AppSettings LoadSettings()
    {
        if (!File.Exists(_settingsPath))
        {
            return new AppSettings();
        }

        try
        {
            var json = File.ReadAllText(_settingsPath);
            return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
        }
        catch
        {
            return new AppSettings();
        }
    }
}

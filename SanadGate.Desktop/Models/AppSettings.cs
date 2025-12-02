using System;

namespace SanadGate.Desktop.Models;

public class AppSettings
{
    public string MerchantName { get; set; } = "متجري";
    public string MerchantAccount { get; set; } = "000000";
    public string ContactNumber { get; set; } = "";
    public string ThemeColor { get; set; } = "#2E7D32"; // أخضر افتراضي
    public bool EnableLargeFont { get; set; } = false;
    public bool EnableSqliteLogging { get; set; } = true;
    public string DatabasePath { get; set; } = "sanadgate.db";
}

using System;

namespace SanadGate.Desktop.Models;

public class TransactionRecord
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string MerchantName { get; set; } = "";
    public string MerchantAccount { get; set; } = "";
    public decimal Amount { get; set; }
    public string InvoiceRef { get; set; } = "";
    public string CashierName { get; set; } = "";
    public string Notes { get; set; } = "";
    public string Status { get; set; } = "completed"; // completed, pending, cancelled
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

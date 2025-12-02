using System;

namespace SanadGate.Desktop.Models;

public class InvoiceModel
{
    public string ReferenceNumber { get; set; } = "";
    public decimal Amount { get; set; }
    public string CashierName { get; set; } = "";
    public string MerchantName { get; set; } = "";
    public string MerchantAccount { get; set; } = "";
    public string Notes { get; set; } = "";
}

// مثال على استخدام SanadGateService في تطبيق خارجي

// لو كنت تريد الوصول إلى الخدمات من تطبيق آخر، يمكنك فعل التالي:

// 1. توليد رمز QR
using SanadGate.Desktop.Services;

var qrService = new QrGeneratorService();
var data = new Dictionary<string, object>
{
    { "amount", 500.50 },
    { "invoiceRef", "INV-12345" },
    { "merchantName", "المتجر الأساسي" },
    { "merchantAccount", "ACC-12345" },
    { "cashier", "أحمد" },
    { "notes": "ملاحظة مهمة" },
    { "timestamp", DateTime.UtcNow.ToString("o") }
};

var qrImage = qrService.GenerateQrCode(data);
// استخدم qrImage في صورة WPF أو احفظها

// 2. حفظ المعاملة
using SanadGate.Desktop.Models;

var sqlite = new SqliteService("sanadgate.db");
var transaction = new TransactionRecord
{
    MerchantName = "المتجر الأساسي",
    MerchantAccount = "ACC-12345",
    Amount = 500.50m,
    InvoiceRef = "INV-12345",
    CashierName = "أحمد",
    Notes = "ملاحظة مهمة",
    Status = "completed",
    CreatedAt = DateTime.UtcNow
};

sqlite.SaveTransaction(transaction);

// 3. استرجاع المعاملات السابقة
var allTransactions = sqlite.GetAllTransactions();
foreach (var t in allTransactions)
{
    Console.WriteLine($"المبلغ: {t.Amount}, التاريخ: {t.CreatedAt}");
}

// 4. إدارة الإعدادات
var settingsService = new SettingsService("appsettings.json");
var settings = settingsService.GetSettings();

// تعديل الإعدادات
settings.MerchantName = "اسم المتجر الجديد";
settings.EnableLargeFont = true;

// حفظ الإعدادات
settingsService.SaveSettings(settings);

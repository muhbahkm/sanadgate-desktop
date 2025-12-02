# SanadGate Desktop - نقطة البيع

تطبيق Windows Desktop لإدارة نقطة البيع مع دعم كامل للغة العربية.

## متطلبات النظام

- Windows 10/11
- .NET 8.0 SDK (للتطوير)
- .NET 8.0 Runtime (للتشغيل)

## البناء

### على Windows مع Visual Studio 2022

1. افتح `SanadGate.Desktop.sln`
2. اضغط `Ctrl+Shift+B` للبناء
3. اضغط `F5` للتشغيل

### من سطر الأوامر

```bash
cd SanadGate.Desktop
dotnet restore
dotnet build -c Release
```

### التشغيل

```bash
dotnet run
```

### النشر

```bash
dotnet publish -c Release -o ./publish
```

## الملفات المهمة

- `SanadGate.Desktop.csproj` - ملف المشروع
- `App.xaml` - تعريف التطبيق
- `Views/MainWindow.xaml` - النافذة الرئيسية
- `Views/SettingsWindow.xaml` - نافذة الإعدادات
- `ViewModels/MainViewModel.cs` - منطق النافذة الرئيسية
- `Services/QrGeneratorService.cs` - توليد QR codes
- `Services/SqliteService.cs` - قاعدة البيانات

## الترتيبات

### إضافة خط IBM Plex Sans Arabic

1. حمّل الخط من: https://github.com/IBM/plex/releases
2. ضع ملفات TTF في: `assets/fonts/`
3. أعد بناء المشروع

### الإعدادات

يتم حفظ الإعدادات في ملف `appsettings.json`:

```json
{
  "merchantName": "متجري",
  "merchantAccount": "000000",
  "contactNumber": "",
  "themeColor": "#2E7D32",
  "enableLargeFont": false,
  "enableSqliteLogging": true,
  "databasePath": "sanadgate.db"
}
```

## المكتبات المستخدمة

- **QRCoder** v1.4.3 - توليد رموز QR
- **System.Data.SQLite** v1.0.118 - قاعدة البيانات المحلية
- **Newtonsoft.Json** v13.0.3 - معالجة JSON

## الإجراءات والاختصارات

- **Alt+Enter**: تم الدفع (حفظ المعاملة)
- **Esc**: إلغاء (مسح الحقول)
- **F2**: فتح الإعدادات

## هيكل البيانات

### جدول Transactions

```sql
CREATE TABLE Transactions (
  Id TEXT PRIMARY KEY,
  MerchantName TEXT,
  MerchantAccount TEXT,
  Amount REAL,
  InvoiceRef TEXT,
  CashierName TEXT,
  Notes TEXT,
  Status TEXT,
  CreatedAt TEXT
);
```

### تنسيق QR Code JSON

```json
{
  "amount": 100.50,
  "invoiceRef": "INV-001",
  "merchantName": "المتجر الأول",
  "merchantAccount": "ACC-001",
  "cashier": "الكاشير",
  "notes": "ملاحظات",
  "timestamp": "2024-01-01T12:00:00Z"
}
```

## استكشاف الأخطاء

### الخط لا يظهر بشكل صحيح

- تأكد من وجود ملفات `.ttf` في مجلد `assets/fonts/`
- أعد بناء المشروع
- امسح مجلد `bin` و `obj` وأعد البناء

### لا تظهر الرموز العربية بشكل صحيح

- تأكد من أن الملف مشفر بـ UTF-8
- تحقق من إعدادات اللغة في Windows

## المساهمة

يرجى اتباع معايير الترميز:
- استخدم async/await للعمليات الطويلة
- اتبع نمط MVVM
- اكتب تعليقات واضحة

## الترخيص

MIT License - انظر LICENSE file للتفاصيل

# SanadGate Desktop

تطبيق نقطة بيع احترافي باللغة العربية لـ Windows باستخدام WPF .NET 8.0

## الميزات

- ✅ واجهة عربية كاملة (من اليمين إلى اليسار)
- ✅ توليد رموز QR تلقائية للدفع
- ✅ قاعدة بيانات SQLite محلية لحفظ المعاملات
- ✅ واجهة بسيطة وحديثة
- ✅ معالجة فورية للدفع بدون اتصال بالإنترنت

## المتطلبات

- Windows 10 أو أحدث
- .NET 8.0 Runtime

## البنية

```
SanadGate.Desktop/
├── Models/                    # نماذج البيانات
│   ├── AppSettings.cs        # إعدادات التطبيق
│   └── TransactionRecord.cs  # سجل المعاملات
├── ViewModels/               # نماذج العرض (MVVM)
│   ├── MainViewModel.cs      # نموذج النافذة الرئيسية
│   ├── SettingsViewModel.cs  # نموذج الإعدادات
│   ├── ViewModelBase.cs      # فئة أساسية للـ ViewModels
│   └── RelayCommand.cs       # أوامر التحكم
├── Services/                 # الخدمات
│   ├── QrGeneratorService.cs # توليد رموز QR
│   ├── SettingsService.cs    # إدارة الإعدادات
│   └── SqliteService.cs      # قاعدة البيانات المحلية
├── Views/                    # واجهات XAML
│   ├── MainWindow.xaml       # النافذة الرئيسية
│   ├── MainWindow.xaml.cs    # منطق النافذة الرئيسية
│   ├── SettingsWindow.xaml   # نافذة الإعدادات
│   └── SettingsWindow.xaml.cs # منطق نافذة الإعدادات
├── assets/fonts/             # ملفات الخطوط
│   └── IBMPlexSansArabic-*.ttf
├── App.xaml                  # تطبيق WPF
├── App.xaml.cs               # منطق التطبيق
├── AssemblyInfo.cs           # معلومات التجميع
└── SanadGate.Desktop.csproj  # ملف المشروع

```

## الميزات الرئيسية

### النافذة الرئيسية
- **لوحة عرض QR**: تعرض رمز QR الذي يتم تحديثه تلقائياً
- **لوحة الإدخال**: حقول إدخال البيانات:
  - إجمالي المبلغ (مطلوب)
  - الرقم المرجعي للفاتورة
  - اسم الكاشير
  - ملاحظات (اختياري)
- **أزرار الإجراء**:
  - تم الدفع (حفظ المعاملة)
  - إلغاء (مسح الحقول)
  - الإعدادات

### نافذة الإعدادات
- اسم المتجر
- رقم حساب التاجر في سندغيت
- رقم التواصل
- لون الواجهة
- تكبير الخط
- تفعيل/تعطيل حفظ السجلات

## البيانات المحفوظة

تُحفظ كل معاملة مع البيانات التالية:
- معرّف فريد (GUID)
- اسم المتجر
- رقم حساب التاجر
- المبلغ
- الرقم المرجعي
- اسم الكاشير
- الملاحظات
- الحالة
- تاريخ ووقت الإنشاء

## تنسيق بيانات QR

يتم ترميز البيانات التالية في رمز QR (JSON):
```json
{
  "amount": 100.50,
  "invoiceRef": "INV-001",
  "merchantName": "المتجر الأول",
  "merchantAccount": "ACC-001",
  "cashier": "الكاشير",
  "notes": "ملاحظات إضافية",
  "timestamp": "2024-01-01T12:00:00Z"
}
```

## المراجع المستخدمة

- **QRCoder**: توليد رموز QR
- **System.Data.SQLite**: قاعدة بيانات محلية
- **Newtonsoft.Json**: معالجة JSON
- **IBM Plex Sans Arabic**: خط عربي احترافي

## التثبيت والتشغيل

### من المصدر
```bash
cd SanadGate.Desktop
dotnet restore
dotnet build -c Release
dotnet run
```

### من الملف القابل للتنفيذ
```bash
dotnet publish -c Release -o ./publish
cd publish
SanadGate.Desktop.exe
```

## لوحات المفاتيح

- **Enter**: تم الدفع
- **Esc**: إلغاء
- **F2**: الإعدادات
- **Alt+Enter**: تم الدفع (بديل)

## الترخيص

هذا المشروع مرخص تحت رخصة MIT.

## الدعم والمساهمة

للإبلاغ عن مشاكل أو المساهمة في التطوير، يرجى فتح issue على GitHub.

---

**ملاحظة**: يتطلب التطبيق وجود خط IBM Plex Sans Arabic في مجلد `assets/fonts/` للعمل بشكل صحيح.

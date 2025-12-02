# SanadGate Desktop - دليل البدء السريع

## الخطوات الأولى

### 1. المتطلبات الأساسية

تأكد من تثبيت:
- Windows 10 أو أحدث
- .NET 8.0 SDK ([تحميل](https://dotnet.microsoft.com/download/dotnet/8.0))

### 2. استنساخ المشروع

```bash
git clone https://github.com/muhbahkm/sanadgate-desktop.git
cd sanadgate-desktop
```

### 3. تثبيت الخطوط

قم بتحميل خط IBM Plex Sans Arabic:

#### الطريقة 1: من GitHub
```bash
cd SanadGate.Desktop/assets/fonts
wget https://github.com/IBM/plex/raw/master/packages/fonts/ttf/IBMPlexSansArabic-Regular.ttf
wget https://github.com/IBM/plex/raw/master/packages/fonts/ttf/IBMPlexSansArabic-Medium.ttf
wget https://github.com/IBM/plex/raw/master/packages/fonts/ttf/IBMPlexSansArabic-Bold.ttf
cd ../../../
```

#### الطريقة 2: من Google Fonts
انتقل إلى https://fonts.google.com/specimen/IBM+Plex+Sans+Arabic وحمل الملفات

### 4. البناء والتشغيل

#### على Windows مع Visual Studio

```bash
# فتح الحل
Start-Process SanadGate.Desktop.sln
```

ثم:
1. اضغط `Ctrl+Shift+B` للبناء
2. اضغط `F5` للتشغيل

#### من سطر الأوامر

```bash
# الاستعادة والبناء
cd SanadGate.Desktop
dotnet restore
dotnet build -c Release

# التشغيل
dotnet run

# أو النشر
dotnet publish -c Release -o ./publish
cd publish
SanadGate.Desktop.exe
```

## الاستخدام الأساسي

### إدخال معاملة جديدة

1. أدخل **إجمالي المبلغ** (مطلوب)
2. أدخل **الرقم المرجعي** للفاتورة (اختياري)
3. أدخل **اسم الكاشير** (اختياري)
4. أضف **ملاحظات** إن لزم (اختياري)
5. اضغط **"تم الدفع"** أو اضغط `Alt+Enter`

سيتم تلقائياً:
- توليد رمز QR يحتوي على جميع البيانات
- حفظ المعاملة في قاعدة البيانات المحلية

### تغيير الإعدادات

1. اضغط **"الإعدادات"** أو `F2`
2. عدّل البيانات المطلوبة:
   - اسم المتجر
   - رقم حساب التاجر
   - رقم التواصل
   - لون الواجهة
3. اضغط **"حفظ الإعدادات"**

### مسح البيانات

- اضغط **"إلغاء"** أو `Esc` لمسح جميع الحقول

## اختصارات لوحة المفاتيح

| المفتاح | الإجراء |
|--------|--------|
| `Alt+Enter` | تم الدفع |
| `Esc` | إلغاء |
| `F2` | الإعدادات |

## استكشاف الأخطاء

### مشكلة: الخط العربي لا يظهر

**الحل**:
1. تأكد من وجود ملفات `.ttf` في `SanadGate.Desktop/assets/fonts/`
2. احذف مجلدات البناء:
   ```bash
   rm -r SanadGate.Desktop/bin SanadGate.Desktop/obj
   ```
3. أعد البناء:
   ```bash
   dotnet clean
   dotnet build
   ```

### مشكلة: لا يمكن فتح قاعدة البيانات

**الحل**:
1. تأكد من أن المجلد قابل للكتابة
2. احذف ملف `sanadgate.db` إن كان موجوداً:
   ```bash
   rm sanadgate.db
   ```
3. أعد تشغيل التطبيق

### مشكلة: رمز QR لا يظهر

**الحل**:
1. تأكد من إدخال المبلغ بصيغة صحيحة (أرقام فقط)
2. يجب أن يكون المبلغ أكبر من صفر
3. اختبر بإدخال رقم بسيط مثل `100`

## الملفات المهمة

| الملف | الوصف |
|------|--------|
| `appsettings.json` | إعدادات التطبيق (ينشأ تلقائياً) |
| `sanadgate.db` | قاعدة البيانات (ينشأ تلقائياً) |
| `SanadGate.Desktop.sln` | ملف الحل |
| `README_AR.md` | الشرح المفصل بالعربية |
| `SETUP.md` | تعليمات البناء والتطوير |

## الدعم التقني

للمساعدة أو الإبلاغ عن مشاكل:
- افتح issue على GitHub
- تضمن وصف المشكلة والخطوات لإعادة إنتاجها
- أرفق لقطات شاشة إن أمكن

## الخطوات التالية

بعد التثبيت الناجح:

1. **اختبر الوظائف الأساسية**:
   - أدخل معاملة تجريبية
   - تحقق من رمز QR
   - افتح الإعدادات وغيّر البيانات

2. **تخصيص للإنتاج**:
   - عدّل `appsettings.json` ببيانات متجرك
   - اختبر الدفع الفعلي
   - تحقق من الإيصالات

3. **النشر**:
   ```bash
   dotnet publish -c Release
   ```
   ثم وزّع المجلد `publish` على أجهزة الكاشيرين

---

**هل تواجه مشكلة؟** اطلع على `SETUP.md` للمزيد من التفاصيل.

**تاريخ آخر تحديث**: 1 ديسمبر 2024

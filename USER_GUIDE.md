# User Guide - SanadGate Desktop

## دليل المستخدم - سند غيت ديسكتوب

---

## English Guide

### Main Window Overview

#### Left Panel - QR Code Display
- Shows the generated QR code (350x350 pixels)
- Displays merchant details:
  - Store Name (اسم المتجر)
  - Account Number (رقم الحساب)
  - Invoice Reference (الرقم المرجعي)
  - Total Amount (إجمالي المبلغ)
  - Currency (العملة)

#### Right Panel - Data Entry
1. **Total Amount** (إجمالي المبلغ) - *Required*
   - Enter numeric value only
   - Example: 500.50
   
2. **Invoice Reference** (الرقم المرجعي للفاتورة) - Optional
   - Unique invoice ID
   - Example: INV-12345

3. **Cashier Name** (اسم الكاشير) - Optional
   - Name of the cashier processing the transaction
   - Example: أحمد

4. **Notes** (ملاحظات) - Optional
   - Additional information
   - Example: شحنة سريعة

#### Action Buttons
| Button | Keyboard | Action |
|--------|----------|--------|
| **تم الدفع** | Alt+Enter | Process payment, save transaction, clear fields |
| **إلغاء** | Esc | Clear all fields |
| **الإعدادات** | F2 | Open settings dialog |

### Settings Window

Click "الإعدادات" or press F2 to open:

1. **Store Name** (اسم المتجر)
   - Display name for your store
   
2. **Merchant Account** (رقم حساب التاجر)
   - Your merchant account number with SanadGate
   
3. **Contact Number** (رقم التواصل)
   - Business phone number
   
4. **Theme Color** (لون الواجهة)
   - Hex color code for UI theme
   - Default: #2E7D32 (Green)
   
5. **Enable Large Font** (تكبير الخط)
   - Toggle for larger text
   
6. **Enable Database Logging** (حفظ السجلات)
   - Toggle to enable/disable transaction logging

### Processing a Payment

1. **Enter Amount**: Type the payment amount in the first field
   - QR code appears automatically
   
2. **Add Details** (Optional):
   - Invoice number
   - Cashier name
   - Additional notes
   
3. **Review QR Code**: Check the generated code on the left
   - All details are encoded in the QR

4. **Process**: Click "تم الدفع" or press Alt+Enter
   - Transaction is saved to database
   - Fields clear automatically
   
5. **Next Transaction**: Start over with new amount

### Data Storage

All transactions are saved to a local SQLite database:
- File: `sanadgate.db` (created automatically)
- Location: Application folder
- Data saved: 
  - Amount
  - Invoice reference
  - Cashier name
  - Notes
  - Timestamp

### Troubleshooting

| Problem | Solution |
|---------|----------|
| QR code not showing | Enter valid amount (number > 0) |
| Settings not saving | Ensure folder has write permissions |
| Font looks wrong | Download IBM Plex Sans Arabic fonts |
| Database error | Delete sanadgate.db and restart |
| Cannot process payment | Check if amount field is filled |

---

## الدليل العربي

### نظرة عامة على النافذة الرئيسية

#### اللوحة اليمنى - عرض رمز QR
- تعرض رمز QR المُنتج (350x350 بكسل)
- تعرض تفاصيل المتجر:
  - اسم المتجر
  - رقم الحساب
  - الرقم المرجعي
  - إجمالي المبلغ
  - العملة (ريال يمني)

#### اللوحة اليسرى - إدخال البيانات
1. **إجمالي المبلغ** - *مطلوب*
   - أدخل قيمة رقمية فقط
   - مثال: 500.50
   
2. **الرقم المرجعي للفاتورة** - اختياري
   - رقم فاتورة فريد
   - مثال: INV-12345

3. **اسم الكاشير** - اختياري
   - اسم الكاشير الذي يعالج المعاملة
   - مثال: أحمد

4. **ملاحظات** - اختياري
   - معلومات إضافية
   - مثال: شحنة سريعة

#### أزرار الإجراءات
| الزر | لوحة المفاتيح | الإجراء |
|------|-------------|--------|
| **تم الدفع** | Alt+Enter | معالجة الدفع، حفظ المعاملة، مسح الحقول |
| **إلغاء** | Esc | مسح جميع الحقول |
| **الإعدادات** | F2 | فتح نافذة الإعدادات |

### نافذة الإعدادات

انقر على "الإعدادات" أو اضغط F2 لفتح:

1. **اسم المتجر**
   - اسم عرض متجرك
   
2. **رقم حساب التاجر**
   - رقم حسابك في سندغيت
   
3. **رقم التواصل**
   - رقم هاتف العمل
   
4. **لون الواجهة**
   - كود اللون السادس عشري
   - الافتراضي: #2E7D32 (أخضر)
   
5. **تكبير الخط**
   - تفعيل/تعطيل النص الأكبر
   
6. **حفظ السجلات**
   - تفعيل/تعطيل حفظ المعاملات

### معالجة الدفع

1. **أدخل المبلغ**: اكتب مبلغ الدفع في الحقل الأول
   - يظهر رمز QR تلقائياً
   
2. **أضف التفاصيل** (اختياري):
   - رقم الفاتورة
   - اسم الكاشير
   - ملاحظات إضافية
   
3. **راجع رمز QR**: تحقق من الرمز المُنتج على اليمين
   - تم ترميز جميع التفاصيل في الرمز

4. **معالجة**: انقر على "تم الدفع" أو اضغط Alt+Enter
   - يتم حفظ المعاملة في قاعدة البيانات
   - تُمسح الحقول تلقائياً
   
5. **معاملة التالية**: ابدأ من جديد برقم جديد

### تخزين البيانات

يتم حفظ جميع المعاملات في قاعدة بيانات SQLite محلية:
- الملف: `sanadgate.db` (ينشأ تلقائياً)
- الموقع: مجلد التطبيق
- البيانات المحفوظة:
  - المبلغ
  - الرقم المرجعي
  - اسم الكاشير
  - الملاحظات
  - الطابع الزمني

### استكشاف الأخطاء

| المشكلة | الحل |
|--------|------|
| رمز QR لا يظهر | أدخل مبلغ صحيح (أكبر من صفر) |
| الإعدادات لا تُحفظ | تأكد من أن المجلد قابل للكتابة |
| الخط يظهر بشكل خاطئ | حمّل خطوط IBM Plex Sans Arabic |
| خطأ في قاعدة البيانات | احذف sanadgate.db وأعد التشغيل |
| لا يمكن معالجة الدفع | تحقق من ملء حقل المبلغ |

---

## Tips & Best Practices

### أفضل الممارسات

1. **Use Consistent Invoice Numbers**
   - Makes record tracking easier
   - استخدم تنسيق موحد: INV-YYYY-MM-DD-001

2. **Record Cashier Names**
   - Helps with accountability
   - يساعد في تتبع المبيعات

3. **Add Notes for Special Cases**
   - Discounts applied
   - Customer information
   - Delivery details

4. **Regular Backups**
   - Backup sanadgate.db regularly
   - احتفظ بنسخة احتياطية من البيانات

5. **Review Settings Monthly**
   - Update store information if needed
   - Verify merchant account number

### Performance Tips

- Clear old transactions periodically
- Keep database file on fast storage
- Use SSD for better performance
- Close other programs for stability

---

## FAQ - الأسئلة الشائعة

### Q: هل يمكن استخدام التطبيق بدون إنترنت؟
**A**: نعم تماماً! التطبيق يعمل 100% محلياً بدون اتصال إنترنت.

### Q: أين يتم حفظ البيانات؟
**A**: في ملف `sanadgate.db` في مجلد التطبيق.

### Q: هل يمكن حذف المعاملات؟
**A**: حالياً لا، لكن يمكن ترك ملاحظة توضيحية.

### Q: كيف أحصل على الملخص الشهري؟
**A**: افتح ملف sanadgate.db باستخدام أي برنامج SQLite.

### Q: هل التطبيق آمن؟
**A**: نعم، البيانات محلية وغير مرسلة لأي مكان.

### Q: ماذا لو نسيت كلمة المرور؟
**A**: التطبيق لا يحتوي على كلمة مرور، يمكنك البدء فوراً.

### Q: هل يدعم أكثر من عملة؟
**A**: الإصدار الحالي يدعم عملة واحدة (قابل للتطوير).

### Q: كيف أحدّث الإعدادات؟
**A**: اضغط F2 أو انقر على "الإعدادات" في أي وقت.

---

## Keyboard Shortcuts Summary

| Shortcut | Function | الدالة |
|----------|----------|--------|
| Alt+Enter | Process Payment | تم الدفع |
| Esc | Clear/Cancel | إلغاء/مسح |
| F2 | Settings | الإعدادات |
| Tab | Next Field | الحقل التالي |
| Shift+Tab | Previous Field | الحقل السابق |

---

## Data Security Notes

### Privacy
- No data is sent to any server
- No internet connection needed
- All data stays on your machine

### Backup
- Regularly backup sanadgate.db
- Store backups securely
- Use external drive for important data

### Recovery
- If database is corrupted, delete it and start fresh
- Old transactions can be recovered from backups
- Settings are stored in appsettings.json

---

## Technical Requirements

### Minimum System
- Windows 10 (64-bit)
- 200 MB free disk space
- 4 GB RAM

### Recommended
- Windows 11 (64-bit)
- 500 MB free disk space
- 8 GB RAM
- SSD storage

### Dependencies
- .NET 8.0 Runtime
- IBM Plex Sans Arabic Font

---

## Contact & Support

For issues or questions:
1. Check QUICKSTART_AR.md
2. Review SETUP.md
3. Open issue on GitHub
4. Check examples in EXAMPLES.md

---

**Last Updated**: December 1, 2024
**Version**: 1.0.0
**Status**: Active

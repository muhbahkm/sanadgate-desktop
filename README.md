# SanadGate Desktop

Professional Point of Sale (POS) application for Windows with full Arabic support.

## Overview

SanadGate Desktop is a modern, fast, and reliable POS application built with WPF .NET 8.0, designed specifically for Arabic-speaking merchants. It provides:

- ✅ QR code generation for payments
- ✅ Local SQLite database for transaction records
- ✅ Full Arabic UI (Right-to-Left)
- ✅ No internet connection required
- ✅ Clean, modern interface
- ✅ Cashier-friendly design

## Features

### Main Window
- **QR Display Panel**: Real-time QR code generation
- **Input Panel**: Easy data entry fields
  - Total Amount (required)
  - Invoice Reference
  - Cashier Name
  - Notes (optional)
- **Action Buttons**:
  - Process Payment (Alt+Enter)
  - Cancel (Esc)
  - Settings (F2)

### Settings Window
- Store Name
- Merchant Account Number
- Contact Number
- UI Color Customization
- Font Size Options
- Database Logging Toggle

### Data Management
- Automatic transaction logging
- Local SQLite database
- JSON settings file
- Export-ready transaction records

## Tech Stack

- **Framework**: .NET 8.0 / WPF
- **Language**: C#
- **Architecture**: MVVM (Simple, no external frameworks)
- **Database**: SQLite
- **UI Font**: IBM Plex Sans Arabic
- **Libraries**:
  - QRCoder v1.4.3
  - System.Data.SQLite v1.0.118
  - Newtonsoft.Json v13.0.3

## Project Structure

```
SanadGate.Desktop/
├── Models/
│   ├── AppSettings.cs
│   └── TransactionRecord.cs
├── ViewModels/
│   ├── ViewModelBase.cs
│   ├── RelayCommand.cs
│   ├── MainViewModel.cs
│   └── SettingsViewModel.cs
├── Services/
│   ├── QrGeneratorService.cs
│   ├── SettingsService.cs
│   └── SqliteService.cs
├── Views/
│   ├── MainWindow.xaml
│   ├── MainWindow.xaml.cs
│   ├── SettingsWindow.xaml
│   └── SettingsWindow.xaml.cs
├── assets/fonts/
├── App.xaml
├── App.xaml.cs
├── SanadGate.Desktop.csproj
└── appsettings.json.example
```

## Getting Started

### Prerequisites

- Windows 10 or later
- .NET 8.0 SDK

### Quick Start

```bash
# Clone the repository
git clone https://github.com/muhbahkm/sanadgate-desktop.git
cd sanadgate-desktop

# Build
cd SanadGate.Desktop
dotnet restore
dotnet build -c Release

# Run
dotnet run
```

### Font Installation

Download IBM Plex Sans Arabic from [Google Fonts](https://fonts.google.com/specimen/IBM+Plex+Sans+Arabic) or [GitHub](https://github.com/IBM/plex) and place TTF files in `SanadGate.Desktop/assets/fonts/`

## Usage

1. Enter the amount (required)
2. Add invoice reference, cashier name, and notes (optional)
3. Press "تم الدفع" (Done/Process Payment) or Alt+Enter
4. QR code is generated and transaction is saved automatically

## Database Schema

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

## QR Code Payload

```json
{
  "amount": 100.50,
  "invoiceRef": "INV-001",
  "merchantName": "Store Name",
  "merchantAccount": "ACC-001",
  "cashier": "Cashier Name",
  "notes": "Additional notes",
  "timestamp": "2024-01-01T12:00:00Z"
}
```

## Configuration

Settings are stored in `appsettings.json`:

```json
{
  "merchantName": "My Store",
  "merchantAccount": "000000",
  "contactNumber": "",
  "themeColor": "#2E7D32",
  "enableLargeFont": false,
  "enableSqliteLogging": true,
  "databasePath": "sanadgate.db"
}
```

## Keyboard Shortcuts

| Key | Action |
|-----|--------|
| Alt+Enter | Process Payment |
| Esc | Cancel |
| F2 | Open Settings |

## Documentation

- [Arabic Documentation (العربية)](README_AR.md)
- [Quick Start Guide (Arabic)](QUICKSTART_AR.md)
- [Setup & Development](SETUP.md)
- [Project Report](PROJECT_REPORT.md)
- [Code Examples](EXAMPLES.md)

## Contributing

Contributions are welcome! Please:
1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

For bug reports and feature requests, please open an issue on GitHub.

## Author

- **Muhammad Bahkm** - Initial work

## Changelog

### Version 1.0.0 (2024-12-01)
- Initial release
- Basic POS functionality
- QR code generation
- Local database support
- Settings management

---

**Note**: This is a specialized POS application designed for Arabic merchants. It operates completely offline with no backend or payment gateway integration.

SanadGate Desktop — A Windows cashiers' application for generating secure QR payment codes and logging offline transactions. Part of the SanadGate payment ecosystem.

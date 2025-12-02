using System.Collections.ObjectModel;
using SanadGate.Desktop.Models;
using SanadGate.Desktop.Services;

namespace SanadGate.Desktop.ViewModels;

public class HistoryViewModel : ViewModelBase
{
    private readonly SqliteService _sqliteService = new SqliteService();

    public ObservableCollection<TransactionRecord> Transactions { get; } = new ObservableCollection<TransactionRecord>();

    public HistoryViewModel()
    {
        LoadTransactions();
    }

    private void LoadTransactions()
    {
        var list = _sqliteService.GetAllTransactions();
        Transactions.Clear();
        foreach (var t in list)
            Transactions.Add(t);
    }
}

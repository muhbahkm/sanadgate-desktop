using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using SanadGate.Desktop.Models;

namespace SanadGate.Desktop.Services;

public class SqliteService
{
    private readonly string _connectionString;

    public SqliteService(string databasePath = "sanadgate.db")
    {
        _connectionString = $"Data Source={databasePath};Version=3;";
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Transactions (
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
        ";
        command.ExecuteNonQuery();
    }

    public void SaveTransaction(TransactionRecord transaction)
    {
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Transactions (Id, MerchantName, MerchantAccount, Amount, InvoiceRef, CashierName, Notes, Status, CreatedAt)
            VALUES (@Id, @MerchantName, @MerchantAccount, @Amount, @InvoiceRef, @CashierName, @Notes, @Status, @CreatedAt)
        ";

        command.Parameters.AddWithValue("@Id", transaction.Id);
        command.Parameters.AddWithValue("@MerchantName", transaction.MerchantName ?? "");
        command.Parameters.AddWithValue("@MerchantAccount", transaction.MerchantAccount ?? "");
        command.Parameters.AddWithValue("@Amount", transaction.Amount);
        command.Parameters.AddWithValue("@InvoiceRef", transaction.InvoiceRef ?? "");
        command.Parameters.AddWithValue("@CashierName", transaction.CashierName ?? "");
        command.Parameters.AddWithValue("@Notes", transaction.Notes ?? "");
        command.Parameters.AddWithValue("@Status", transaction.Status);
        command.Parameters.AddWithValue("@CreatedAt", transaction.CreatedAt.ToString("o"));

        command.ExecuteNonQuery();
    }

    public List<TransactionRecord> GetAllTransactions()
    {
        var transactions = new List<TransactionRecord>();

        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Transactions ORDER BY CreatedAt DESC";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            transactions.Add(new TransactionRecord
            {
                Id = reader["Id"].ToString() ?? "",
                MerchantName = reader["MerchantName"].ToString() ?? "",
                MerchantAccount = reader["MerchantAccount"].ToString() ?? "",
                Amount = Convert.ToDecimal(reader["Amount"]),
                InvoiceRef = reader["InvoiceRef"].ToString() ?? "",
                CashierName = reader["CashierName"].ToString() ?? "",
                Notes = reader["Notes"].ToString() ?? "",
                Status = reader["Status"].ToString() ?? "completed",
                CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString() ?? DateTime.UtcNow.ToString("o"))
            });
        }

        return transactions;
    }
}

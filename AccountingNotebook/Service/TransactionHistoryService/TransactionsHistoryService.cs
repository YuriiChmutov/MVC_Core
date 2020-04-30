﻿using AccountingNotebook.Abstractions;
using AccountingNotebook.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebook.Service.TransactionHistoryService
{
    public class TransactionsHistoryService: ITransactionHistoryService<Transaction>
    {
        private readonly ConcurrentBag<Transaction> _transactions = new ConcurrentBag<Transaction>();

        public Task<Transaction> GetByIdAsync(Guid transactionId, Guid accountId)
        {
            var transaction = _transactions
                .Where(t => (t.ToAccountId == accountId || t.FromAccountId == accountId) && 
                            t.TransactionId == transactionId);
            return Task.FromResult(transaction.FirstOrDefault());
        }

        public Task<IEnumerable<Transaction>> GetAllAsync(Guid accountId)
        {
            var transactions = _transactions
                .Where(t => t.FromAccountId == accountId || t.ToAccountId == accountId);
            return Task.FromResult(transactions.AsEnumerable());
        }

        public Task AddAsync(Transaction transaction)
        {
            _transactions.Add(transaction);
            return Task.CompletedTask;
        }
    }
}
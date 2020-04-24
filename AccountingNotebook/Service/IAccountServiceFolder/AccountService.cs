﻿using System;
using System.Linq;
using AccountingNotebook.Abstractions;
using AccountingNotebook.Models;

namespace AccountingNotebook.Service.IAccountServiceFolder
{
    public class AccountService: IAccountService
    {
        Initializer initializer = new Initializer();
        public Account GetById(Guid id)
        {
            var account = initializer.accounts.FirstOrDefault(x => x.AccountId == id);
            return account;
        }
        public void AddNewAccount(Account account)
        {
            initializer.accounts.Add(account);
        }
        public void DeleteAccount(Guid id)
        {
            var accout = GetById(id);
            initializer.accounts.Remove(accout);
        }
    }
}
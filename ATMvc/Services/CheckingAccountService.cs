using ATMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATMvc.Services
{
    public class CheckingAccountService
    {
        private IApplicationDbContext db;
        public CheckingAccountService(IApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public void CreateCheckingAccount(string firstName, string lastName, string userId, decimal initialBalance) {
            
            var accountNumber = (123456 + db.CheckingAccounts.Count()).ToString().PadLeft(0, '0');
            var checkingAccount = new CheckingAccount
            {
                FirstName = firstName,
                LastName = lastName,
                AccountNumber = accountNumber,
                balance = initialBalance,
                ApplicationUserId = userId
            };
            db.CheckingAccounts.Add(checkingAccount);
            db.saveChanges();
        }

        public void UpdateBalance(int checkingAccountId) {
            var checkingAccount = db.CheckingAccounts.Where(c => c.Id == checkingAccountId).First();
            checkingAccount.balance = db.Transactions.Where(c => c.CheckingAccountId == checkingAccountId).Sum(c=>c.amount);
            db.saveChanges();
        }
    }
}
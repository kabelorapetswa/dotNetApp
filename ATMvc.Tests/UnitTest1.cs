using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATMvc.Controllers;
using System.Web.Mvc;
using ATMvc.Models;

namespace ATMvc.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FooActionReturnsAboutView()
        {
            var homeController = new HomeController();
            var result = homeController.Foo() as ViewResult;
            Assert.AreEqual("About",result.ViewName);
        }
        [TestMethod]
        public void ContactFormSaysThanks() {
            var homeController = new HomeController();
            var result = homeController.Contact("I love your bank.") as ViewResult;
            Assert.IsNotNull(result.ViewBag.TheMessage);
        }

        [TestMethod]
        public void BalanceIsCorrectAfterDeposit() {
            var fakeDb = new FakeApplicationDbContext();
            fakeDb.CheckingAccounts = new FakeDbSet<CheckingAccount>();

            var checkingAccount = new CheckingAccount { Id = 1, AccountNumber = "0000123Test", balance = 0 };
            fakeDb.CheckingAccounts.Add(checkingAccount);
            fakeDb.Transactions = new FakeDbSet<Transaction>();
            var transactionController = new TransactionController(fakeDb);
            transactionController.Deposit(new Transaction { CheckingAccountId = 1, amount = 25 });
            //checkingAccount.balance = 25;
            Assert.AreEqual(25, checkingAccount.balance);

        }

    }
}

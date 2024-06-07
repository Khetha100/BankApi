using BankApi.Controllers;
using BankApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BankApi.Tests
{
    /// <summary>
    /// Unit tests for the BankAccountsController class.
    /// </summary>
    public class BankAccountsControllerTests
    {
        /// <summary>
        /// Test method to verify that GetBankAccountsByHolder returns the correct accounts.
        /// </summary>
        [Fact]
        public async Task GetBankAccountsByHolder_ReturnsAccounts()
        {
            var options = new DbContextOptionsBuilder<BankContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new BankContext(options))
            {
                context.BankAccounts.Add(new BankAccount { Id = 1, AccountHolderId = 1, AccountNumber = "111111", AccountType = "Cheque", AvailableBalance = 5000, Name = "John Doe", Status = "Active" });
                context.BankAccounts.Add(new BankAccount { Id = 2, AccountHolderId = 1, AccountNumber = "222222", AccountType = "Savings", AvailableBalance = 10000, Name = "John Doe", Status = "Active" });
                context.SaveChanges();
            }

            using (var context = new BankContext(options))
            {
                var controller = new BankAccountsController(context);

                var result = await controller.GetBankAccountsByHolder(1);

                var actionResult = Assert.IsType<ActionResult<IEnumerable<BankAccount>>>(result);
                var returnValue = Assert.IsType<List<BankAccount>>(actionResult.Value);
                Assert.Equal(2, returnValue.Count);
            }
        }

        /// <summary>
        /// Test method to verify that GetBankAccount returns the correct account.
        /// </summary>
        [Fact]
        public async Task GetBankAccount_ReturnsAccount()
        {
            var options = new DbContextOptionsBuilder<BankContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new BankContext(options))
            {
                context.BankAccounts.Add(new BankAccount { Id = 1, AccountHolderId = 1, AccountNumber = "111111", AccountType = "Cheque", AvailableBalance = 5000, Name = "John Doe", Status = "Active" });
                context.SaveChanges();
            }

            using (var context = new BankContext(options))
            {
                var controller = new BankAccountsController(context);

                var result = await controller.GetBankAccount("111111");

                var actionResult = Assert.IsType<ActionResult<BankAccount>>(result);
                var returnValue = Assert.IsType<BankAccount>(actionResult.Value);
                Assert.Equal("111111", returnValue.AccountNumber);
            }
        }

        /// <summary>
        /// Test method to verify that GetBankAccount returns NotFound for a non-existent account.
        /// </summary>
        [Fact]
        public async Task GetBankAccount_ReturnsNotFound_ForNonExistentAccount()
        {
            var options = new DbContextOptionsBuilder<BankContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new BankContext(options))
            {
                var controller = new BankAccountsController(context);

                var result = await controller.GetBankAccount("999999");

                Assert.IsType<NotFoundResult>(result.Result);
            }
        }

        /// <summary>
        /// Test method to verify that Withdraw returns Ok for a valid withdrawal.
        /// </summary>
        [Fact]
        public async Task Withdraw_ReturnsOk_ForValidWithdrawal()
        {
            var options = new DbContextOptionsBuilder<BankContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new BankContext(options))
            {
                context.BankAccounts.Add(new BankAccount { Id = 1, AccountNumber = "111111", AccountType = "Cheque", AvailableBalance = 5000, Status = "Active" });
                context.SaveChanges();
            }

            using (var context = new BankContext(options))
            {
                var controller = new BankAccountsController(context);
                var withdrawal = new Withdrawal { BankAccountId = 1, Amount = 2000 };

                var result = await controller.Withdraw(withdrawal);

                Assert.IsType<OkResult>(result);
                Assert.Equal(3000, context.BankAccounts.First().AvailableBalance);
            }
        }

        /// <summary>
        /// Test method to verify that Withdraw returns NotFound for a non-existent account.
        /// </summary>
        [Fact]
        public async Task Withdraw_ReturnsNotFound_ForNonExistentAccount()
        {
            var options = new DbContextOptionsBuilder<BankContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new BankContext(options))
            {
                var controller = new BankAccountsController(context);
                var withdrawal = new Withdrawal { BankAccountId = 999, Amount = 2000 };

                var result = await controller.Withdraw(withdrawal);

                Assert.IsType<NotFoundObjectResult>(result);
            }
        }
    }
}

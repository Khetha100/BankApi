using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApi.Models
{
    /// <summary>
    /// Represents a withdrawal transaction from a bank account.
    /// </summary>
    public class Withdrawal
    {
        /// <summary>
        /// Gets or sets the unique identifier for the withdrawal transaction.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the bank account from which the withdrawal is made.
        /// </summary>
        public int BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets the amount withdrawn from the bank account.
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the withdrawal transaction occurred.
        /// </summary>
        public DateTime Date { get; set; }
    }
}

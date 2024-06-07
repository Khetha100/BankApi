using System;

namespace BankApi.Models
{
    /// <summary>
    /// Represents an audit trail of changes made to a bank account.
    /// </summary>
    public class BankAccountAudit
    {
        /// <summary>
        /// Gets or sets the unique identifier for the bank account audit.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the bank account associated with this audit.
        /// </summary>
        public int BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets the bank account associated with this audit.
        /// </summary>
        public BankAccount? BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the audit occurred.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the changes made during the audit, represented as a string.
        /// </summary>
        public string? Changes { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    /// <summary>
    /// Represents a bank account.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Gets or sets the unique identifier for the bank account.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the account number associated with the bank account.
        /// </summary>
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of the bank account.
        /// </summary>
        public string? AccountType { get; set; }

        /// <summary>
        /// Gets or sets the name associated with the bank account.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the status of the bank account.
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the available balance of the bank account.
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AvailableBalance { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the account holder associated with the bank account.
        /// </summary>
        public int AccountHolderId { get; set; }

        /// <summary>
        /// Gets or sets the account holder associated with the bank account.
        /// </summary>
        public AccountHolder? AccountHolder { get; set; }
    }

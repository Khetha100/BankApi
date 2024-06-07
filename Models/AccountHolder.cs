using System;
using System.Collections.Generic;


    /// <summary>
    /// Represents an account holder.
    /// </summary>
    public class AccountHolder
    {
        /// <summary>
        /// Gets or sets the unique identifier for the account holder.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the account holder.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the account holder.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the account holder.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the identification number of the account holder.
        /// </summary>
        public string? IDNumber { get; set; }

        /// <summary>
        /// Gets or sets the residential address of the account holder.
        /// </summary>
        public string? ResidentialAddress { get; set; }

        /// <summary>
        /// Gets or sets the mobile number of the account holder.
        /// </summary>
        public string? MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the email address of the account holder.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the list of bank accounts associated with the account holder.
        /// </summary>
        public List<BankAccount>? BankAccounts { get; set; }
    }

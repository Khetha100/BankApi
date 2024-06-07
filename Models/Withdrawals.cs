using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApi.Models
{
    public class Withdrawal
{
    public int Id { get; set; }
    public int BankAccountId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
}


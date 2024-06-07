namespace BankApi.Models
{

    public class BankAccountAudit
    {
        public int Id { get; set; }
        public int BankAccountId { get; set; }
        public BankAccount? BankAccount { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Changes { get; set; }
    }
}

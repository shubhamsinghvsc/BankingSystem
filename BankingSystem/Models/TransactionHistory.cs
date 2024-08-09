namespace BankingSystem.Models
{
    public class TransactionHistory
    {
        public string TransactionId { get; set; } = string.Empty;
        public string TransactionType { get; set; }
        public long TransactionAmount { get; set; }
        public string TransactionDate { get; set; }
        public string AccountHolderName { get; set; }
        public long AccountNumber { get; set; }
    }
}

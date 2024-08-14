namespace BankingSystem.Models
{
    public class Users
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsNewUser { get; set; }
        public int Pin { get; set; }
        public long AccountNumber { get; set; }
        public long BankBalance { get; set; }
        public bool IsBlocked { get; set; }
        public List<TransactionHistory> transactionHistories { get; set; }
    }
}

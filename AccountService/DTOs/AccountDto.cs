namespace AccountService.DTOs
{
    public class AccountDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string AccountNumber { get; set; } = null!;
        public string AccountType { get; set; } = null!;
        public decimal Balance { get; set; }
    }
}

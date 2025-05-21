namespace AccountService.DTOs
{
    public class CreateAccountDto
    {
        public string AccountType { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountService.Models
{
    [Table("accounts")]
    public class Account
    {
        [Key]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column("account_number")]
        public string AccountNumber { get; set; } = null!;

        [Column("account_type")]
        public string AccountType { get; set; } = null!;

        [Column("balance")]
        public decimal Balance { get; set; }

        [Column("customer_id")]
        public string CustomerId { get; set; } = null!;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("CustomerId")]
        [InverseProperty("Accounts")]
        public Customer Customer { get; set; } = null!;

        [InverseProperty("FromAccount")]
        public List<Transaction> OutgoingTransactions { get; set; } = new();

        [InverseProperty("ToAccount")]
        public List<Transaction> IncomingTransactions { get; set; } = new();
    }
}

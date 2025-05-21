using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountService.Models
{
    [Table("transactions")]
    public class Transaction
    {
        [Key]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column("from_account_id")]
        public string FromAccountId { get; set; } = null!;

        [Column("to_account_id")]
        public string ToAccountId { get; set; } = null!;

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [ForeignKey("FromAccountId")]
        [InverseProperty("OutgoingTransactions")]
        public Account FromAccount { get; set; } = null!;

        [ForeignKey("ToAccountId")]
        [InverseProperty("IncomingTransactions")]
        public Account ToAccount { get; set; } = null!;
    }
}


using AccountService.Models;

namespace AccountService.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> CreateAsync(Account account);
        Task<Account?> GetByIdAsync(String id);
        Task<IEnumerable<Account>> GetAllAsync();
    }
}

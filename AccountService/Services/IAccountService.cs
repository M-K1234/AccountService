using AccountService.DTOs;
namespace AccountService.Services;

public interface IAccountService
{
    Task<AccountDto> CreateAccountAsync(CreateAccountDto dto);
    Task<AccountDto?> GetAccountAsync(String id);
    Task<IEnumerable<AccountDto>> GetAllAccountsAsync();
    Task<AccountDto?> UpdateAccountAsync(String id, UpdateAccountDto dto);
    Task<bool> DeleteAccountAsync(String id);
}

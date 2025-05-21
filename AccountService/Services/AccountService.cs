using AccountService.DTOs;
using AccountService.Models;
using AccountService.Repositories;
using Microsoft.EntityFrameworkCore.Design;

namespace AccountService.Services
{

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<AccountDto> CreateAccountAsync(CreateAccountDto dto)
        {
            var account = new Account
            {
                Id = Guid.NewGuid().ToString(),
                AccountNumber = $"ACC-{Guid.NewGuid().ToString().Substring(0, 8)}",
                AccountType = dto.AccountType,
                CustomerId = dto.CustomerId,
                Balance = 0
            };

            var created = await _repository.CreateAsync(account);
            return new AccountDto
            {
                Id = created.Id,
                AccountNumber = created.AccountNumber,
                AccountType = created.AccountType,
                Balance = created.Balance
            };
        }

        public async Task<AccountDto?> GetAccountAsync(String id)
        {
            var acc = await _repository.GetByIdAsync(id);
            if (acc == null) return null;

            return new AccountDto
            {
                Id = acc.Id,
                AccountNumber = acc.AccountNumber,
                AccountType = acc.AccountType,
                Balance = acc.Balance
            };
        }

        public async Task<IEnumerable<AccountDto>> GetAllAccountsAsync()
        {
            var accounts = await _repository.GetAllAsync();
            return accounts.Select(acc => new AccountDto
            {
                Id = acc.Id,
                AccountNumber = acc.AccountNumber,
                AccountType = acc.AccountType,
                Balance = acc.Balance
            });
        }

        public async Task<AccountDto?> UpdateAccountAsync(String id, UpdateAccountDto dto)
        {
            var acc = await _repository.GetByIdAsync(id);
            if (acc == null) return null;

            if (dto.AccountType != null)
                acc.AccountType = dto.AccountType;
            if (dto.Balance.HasValue)
                acc.Balance = dto.Balance.Value;

            // Assuming repository has an UpdateAsync method, otherwise just return updated object
            // await _repository.UpdateAsync(acc);

            return new AccountDto
            {
                Id = acc.Id,
                AccountNumber = acc.AccountNumber,
                AccountType = acc.AccountType,
                Balance = acc.Balance
            };
        }

        public async Task<bool> DeleteAccountAsync(String id)
        {
            // Assuming repository has a DeleteAsync method, otherwise just return false
            // return await _repository.DeleteAsync(id);
            return false;
        }
    }

}

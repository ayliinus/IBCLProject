using Context;
using Repository.AccountRepository;

namespace Business.AccountBusiness
{
    public class AccountBusinessService : IAccountBusinessService
    {
        private readonly IAccountRepositoryService _accountRepository;
        private readonly ApplicationDbContext _context;
        public AccountBusinessService(IAccountRepositoryService accountRepository, ApplicationDbContext context)
        {
            _accountRepository = accountRepository;
            _context = context;
        }
    }
}
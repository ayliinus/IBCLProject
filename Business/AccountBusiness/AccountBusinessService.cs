using Context;
using Entity;
using Repository.AccountRepository;
using System.Text.Json;
using ViewModel;

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

        public void AddAccount(AccountVM model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newAccount = new Account
                    {
                        Email = model.Email,
                        Password = model.Password,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Balance = model.Balance,
                        NotificationRate = model.NotificationRate
                    };

                    _accountRepository.Add(newAccount);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool Login(string email, string password)
        {

            var getUser = _accountRepository.GetFirst(u => u.Email == email);
            if (getUser == null)
            {
                return false;
            }
            if (getUser.Password != password)
            {
                return false;
            }
            return true;


        }


    }
}
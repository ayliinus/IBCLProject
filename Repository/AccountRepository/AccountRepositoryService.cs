using Context;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AccountRepository
{
    public class AccountRepositoryService : BaseRepository<Account>, IAccountRepositoryService
    {
        public AccountRepositoryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

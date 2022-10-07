using PMS_UserAPI.Data;
using PMS_UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        
        IGenericRepository<Notes> Notes { get; }
        IGenericRepository<ApplicationUser> ApplicationUsers { get; }

        IAccountRepository accountRepository { get; }

        //IEmailService emailService { get; }
        Task Save();
    }
}

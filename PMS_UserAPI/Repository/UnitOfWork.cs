using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PMS_UserAPI.Data;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PMS_UserAPI.Data.IdentityModel;

namespace PMS_UserAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Notes> _notes;
        private IGenericRepository<ApplicationUser> _applicationUsers;
        private IAccountRepository _accountRepository;
        private IEmailService _emailService;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public UnitOfWork(DatabaseContext context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration,
            RoleManager<ApplicationRole> roleManager,IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _emailService = emailService;

        }
       
        public IGenericRepository<Notes> Notes => _notes ??= new GenericRepository<Notes>(_context);
        public IGenericRepository<ApplicationUser> ApplicationUsers => _applicationUsers ??= new GenericRepository<ApplicationUser>(_context);

        public IAccountRepository accountRepository => _accountRepository ??= new AccountsRepository(_userManager,_signInManager,_configuration,_roleManager,_emailService);

        
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

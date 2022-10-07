using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.IRepository
{
    public interface IEmailService
    {
        Task SendEmail(string to, string subject, string body);
    }
}

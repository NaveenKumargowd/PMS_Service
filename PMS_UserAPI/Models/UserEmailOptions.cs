using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.Models
{
    public class UserEmailOptions
    {
        public UserEmailOptions(string emailtolist, string subject, string body)
        {
            ToEmail = emailtolist;
            Subject = subject;
            Body = body;


        }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        
    }
}

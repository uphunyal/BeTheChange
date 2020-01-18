using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeTheChangeFinal.Services
{
    //Get and set sendgrid keys for email confirmation
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}
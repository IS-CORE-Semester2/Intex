using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//this will be part of sending a confirmation email if we get that working
namespace Intex.Services
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}

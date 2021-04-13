using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Sending a confirmation email 
//not currently in use but oculd be implemented in a later build
namespace Intex.Services
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}

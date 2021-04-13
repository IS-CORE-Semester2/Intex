using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.ViewModels
{
    //show the users that are part of a role through the IsSelected field
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        //username and email are synonymous for us
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}

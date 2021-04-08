using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.ViewModels
{
    public class UserRolesViewModel
    {
        //properties that will be collected and passed
        //UserId is not stored since it is already coming in through the ViewBag
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}

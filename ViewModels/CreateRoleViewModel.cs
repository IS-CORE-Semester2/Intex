using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.ViewModels
{
    //create a role in the DB. We only input RoleName and the DB does the rest
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}

    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;        

namespace FinalProjectENTPROG.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }

    public enum UserTypes
    {
        Admin = 1,
        VaccineUser = 2
    }
}

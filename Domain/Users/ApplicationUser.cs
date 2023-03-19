using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Users
{
    public class ApplicationUser:IdentityUser
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}

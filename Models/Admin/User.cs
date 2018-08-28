using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using WalkingSkeleton.API.Models.Admin;

namespace WalkingSkeleton.API.Models
{
    public class User : IdentityUser<int>
    {
        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
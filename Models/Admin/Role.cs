using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using WalkingSkeleton.API.Models.Admin;

namespace WalkingSkeleton.API.Models
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
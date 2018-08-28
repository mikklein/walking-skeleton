using Microsoft.AspNetCore.Identity;

namespace WalkingSkeleton.API.Models.Admin
{
    public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set; }
        
        public Role Role { get; set; }
    }
}
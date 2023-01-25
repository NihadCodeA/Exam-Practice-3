using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EBusiness.Models
{
    public class Database : IdentityDbContext
    {
        public Database(DbContextOptions options):base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}

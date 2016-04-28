using System.Data.Entity;
using Domain.Entities;

namespace Domain
{
    public class DbDataContext : DbContext
    {
        public DbDataContext()
            : base("DbDataContext")
        { }
        public DbSet<ComputerName> ComputerNames { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<UserName> UserNames { get; set; }
    }
}

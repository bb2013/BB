using System.Data.Entity;
using BB.Presentation.DataContext.InternalUsers;

namespace BB.Presentation.DataContext.DBContext
{
    public class DbInit : DbContext
    {
        public DbInit() : base("BB"){}

        public DbSet<Customer.CustomersDb> Customers { get; set; }
        public DbSet<InternalUsersDb> InternalUsers { get; set; }
    }
}
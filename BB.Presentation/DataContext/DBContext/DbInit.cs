using System.Data.Entity;
using BB.Presentation.Models.Pages;

namespace BB.Presentation.DataContext.DBContext
{
    public class DbInit : DbContext
    {
        public DbInit() : base("BB"){}
        public DbSet<PageNodes> PageNodes { get; set; }
    }
}
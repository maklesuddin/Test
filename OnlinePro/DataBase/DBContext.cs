using Models;
using System.Data.Entity;

namespace DataBase
{
    public class DBContextS:DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}

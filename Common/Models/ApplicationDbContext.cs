using System.Data.Entity;
using System.Diagnostics;

namespace Common.Models
{
    public class ApplicationDbContext : DbContext, IContext
    {

        public ApplicationDbContext() : base("name=DefaultConnection")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        public DbSet<TestClass> TestClass { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}

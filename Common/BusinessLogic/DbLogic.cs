using Common.Models;

namespace Common.BusinessLogic
{
    public class DbLogic : IDbLogic
    {

        private readonly IContext dbContext;
        public DbLogic(IContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void SeedDb()
        {

            var dbSet = dbContext.Set<TestClass>();

            // do your crud or what you want with db set

            dbContext.SaveChanges();

        }

    }
}

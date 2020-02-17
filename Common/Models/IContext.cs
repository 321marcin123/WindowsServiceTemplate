using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Common.Models
{
    public interface IContext : IDisposable
    {
        DbContextConfiguration Configuration { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}

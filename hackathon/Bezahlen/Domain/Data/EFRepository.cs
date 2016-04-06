using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Domain.Data.DB;

namespace Domain.Data
{
  public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    private Hac2112DBEntities1 context;
    private DbSet<TEntity> dbSet;

    public EFRepository(Hac2112DBEntities1 c, DbSet<TEntity> d)
    {
      context = c;
      dbSet = context.Set<TEntity>();
      Data = (IEnumerable<TEntity>) d;
    }

    public IEnumerable<TEntity> Data { get; }

    public async Task AddAsync(TEntity entity)
    {
      dbSet.Add(entity);
      await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
      dbSet.Attach(entity);
      context.Entry(entity).State = EntityState.Modified;
      await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(TEntity entity)
    {
      dbSet.Remove(entity);
      await context.SaveChangesAsync();
    }
  }
}
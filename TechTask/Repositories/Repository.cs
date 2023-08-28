using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TechTask.DataBase;

namespace TechTask.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class  
{
    private DbContext _context;  
    private DbSet<TEntity> _dbSet;  
    
    public Repository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<TEntity>();  
    }
    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.AsNoTracking();
    }

    public async Task<TEntity> GetById(int id)
    {
        TEntity objectFromDb = await _dbSet.FindAsync(id);

        if (objectFromDb is null)
        {
            throw new ArgumentNullException();
        }

        return objectFromDb;
    }

    public async Task<TEntity> Create(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException();
        }
        EntityEntry<TEntity> create = await _dbSet.AddAsync(entity);
        return create.Entity;
    }

    TEntity IRepository<TEntity>.Update(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException();
        }
        EntityEntry<TEntity> update = _dbSet.Update(entity);
        return update.Entity;
    }

    public async Task Delete(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException();
        }
        TEntity entity = await _dbSet.FindAsync(id);
        _dbSet.Remove(entity);
    }

    Task IRepository<TEntity>.Save()
    {
        return _context.SaveChangesAsync();
    }
    
}
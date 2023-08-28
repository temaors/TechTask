namespace TechTask.Repositories;

public interface IRepository<TEntity> where TEntity: class  
{  
    IQueryable<TEntity> GetAll();  
    Task<TEntity> GetById(int id);
    Task<TEntity> Create(TEntity entity);
    TEntity Update(TEntity entity);  
    Task Delete(int id);  
    Task Save();  
}
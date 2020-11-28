using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballSeason.Repositories.GenericRepo
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAllAsQuerable();
        Task<List<TEntity>> GetAll();

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void CreateRange(IEnumerable<TEntity> entities);

        void UpdateRange(IEnumerable<TEntity> entities);
        void DeleteRange(IEnumerable<TEntity> entities);

        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        TEntity FindByIds(params object[] ids);
        Task<TEntity> FindByIdsAsync(params object[] ids);

        TEntity FindById(object id);

        Task<TEntity> FindByIdAsync(object id);
        bool Save();
        Task<bool> SaveAsync();
    }
}

using MS.Customer.Persistence.src.Contexts.Main;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MS.Customer.Persistence.src.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly MainDbContext _mainDbContext;

        public Repository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _mainDbContext.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _mainDbContext.AddAsync(entity);
                await _mainDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _mainDbContext.Update(entity);
                await _mainDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Base
{
    public class BaseRepository<T, I> where T : class
    {
        private readonly ChatServerEntities _dbContext;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(ChatServerEntities dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task Create(T item)
        {
            await _dbSet.AddAsync(item);
        }

        public async Task Delete(I id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item != null)
                _dbSet.Remove(item);
        }

        public virtual async Task<T?> GetByIdAsync(I id, string[]? filter = null)
        {
            if (filter is null)
                return await _dbSet.FindAsync(id);
            else
            {
                var result = CreateFilter(filter);

                //crutch
                var crutch_arr = new List<T>();

                foreach (var res in result)
                    crutch_arr.AddRange(res);

                return await _dbSet.FindAsync(id);
            }
        }

        public virtual IEnumerable<T> GetAll(string[]? filter = null)
        {
            if (filter is null)
                return _dbSet;
            else
            {
                var result = CreateFilter(filter);
                //crutch
                var crutch_arr = new List<T>();

                foreach (var res in result)
                    crutch_arr.AddRange(res);

                return _dbSet;
            }
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }

        public void Update(List<T> items)
        {
            _dbSet.UpdateRange(items);
        }

        private IEnumerable<IQueryable<T>> CreateFilter(string[] filter)
        {
            foreach (var dto in filter)
                yield return _dbSet.Include(dto);
        }
    }
}

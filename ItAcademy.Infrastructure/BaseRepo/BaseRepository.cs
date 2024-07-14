using ItAcademy.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ItAcademy.Infrastructure.BaseRepo
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ItAcademyDbContext _context;
        public BaseRepository(ItAcademyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetCollectionAsync(CancellationToken token, Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? await _context.Set<T>().ToListAsync(token).ConfigureAwait(false) : await _context.Set<T>().Where(expression).ToListAsync(token).ConfigureAwait(false); 
        }

        public IQueryable<T> GetQuery(Expression<Func<T,bool>> expression = null)
        {
            return expression == null ? _context.Set<T>() : _context.Set<T>().Where(expression);
        }
       
        public async Task Create(CancellationToken token, T input)
        {
            await _context.Set<T>().AddAsync(input, token).ConfigureAwait(false);
        }

        public void Update(T input)
        {
            _context.Set<T>().Update(input);
        }
        public void Delete(T input)
        {
            _context.Set<T>().Remove(input);
        }
        public async Task<bool> SaveChangesAsync(CancellationToken token)
        {
            return await _context.SaveChangesAsync(token).ConfigureAwait(false) > 0;
        }

    }
}

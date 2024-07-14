using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItAcademy.Infrastructure.BaseRepo
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetCollectionAsync(CancellationToken token, Expression<Func<T, bool>> expression = null);
        IQueryable<T> GetQuery(Expression<Func<T, bool>> expression = null);
        Task Create(CancellationToken token, T input);
        void Update(T input);
        void Delete(T input);
        Task<bool> SaveChangesAsync(CancellationToken token);

    }
}

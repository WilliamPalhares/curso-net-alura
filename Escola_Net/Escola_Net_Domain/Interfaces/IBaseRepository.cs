using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_Net_Domain.Interfaces
{
    public interface IBaseRepository<T> where T : new()
    {
        Task UpdateAsync(T obj);
        void Update(T obj);
        Task DeleteAsync(T obj);
        void Delete(T obj);
        Task<Int64> InsertAsync(T obj);
        Int64 Insert(T obj);
        Task<IEnumerable<T>> GetListAsync();
        IEnumerable<T> GetList();
        Task<T> GetObjectAsync(Int64 id);
        Task SaveChangesAsync();
        IQueryable<T> queryList();
    }
}

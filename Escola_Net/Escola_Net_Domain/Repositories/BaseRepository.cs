using Escola_Net_Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola_Net_Domain.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly DbSet<T> dbSet;
        protected readonly ApplicationContext applicationContext;
        protected readonly ILogger logger;

        public BaseRepository(ApplicationContext applicationContext, ILogger logger)
        {
            this.applicationContext = applicationContext;
            this.dbSet = applicationContext.Set<T>();
            this.logger = logger;
        }

        public virtual IQueryable<T> queryList()
        {
            return dbSet;
        }

        public virtual async Task<IEnumerable<T>> GetListAsync()
        {
            try
            {
                return await queryList().ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao consultar: {ex.Message}");
                throw ex;
            }
        }

        public virtual IEnumerable<T> GetList()
        {
            Task<IEnumerable<T>> list = GetListAsync();
            list.Wait();
            return list.Result;
        }

        public virtual async Task<T> GetObjectAsync(Int64 Id)
        {
            try
            {
                return await dbSet.FindAsync(Id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao consultar: {ex.Message}");
                throw ex;
            }
        }

        public virtual async Task SaveChangesAsync()
        {
            await this.applicationContext.SaveChangesAsync();
        }

        public virtual async Task<Int64> InsertAsync(T obj)
        {
            try
            {
                dbSet.Add(obj);
                await SaveChangesAsync();
                return obj.Id;
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao Inserir: {ex.Message}");
                throw ex;
            }
        }

        public virtual Int64 Insert(T obj)
        {
            Task<Int64> result = InsertAsync(obj);
            result.Wait();
            return result.Result;
        }

        public virtual async Task UpdateAsync(T obj)
        {
            try
            {
                var entry = dbSet.Update(obj);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao Atualizar: {ex.Message}");
                throw ex;
            }
        }

        public virtual void Update(T obj)
        {
            Task result = UpdateAsync(obj);
            result.Wait();
        }

        public virtual async Task DeleteAsync(T obj)
        {
            try
            {
                dbSet.Attach(obj);
                dbSet.Remove(obj);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao Remover: {ex.Message}");
                throw ex;
            }
        }

        public virtual void Delete(T obj)
        {
            Task result = DeleteAsync(obj);
            result.Wait();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace OperatorPlatform.Data.Abstractions
{
    public interface IGenericRepository<M> : IDisposable where M : class
    {
        Task CommitAsync();
        int Count(Expression<Func<M, bool>> filter = null);
        Task<int> CountAsync(Expression<Func<M, bool>> filter = null);
        void Delete(M entity);
        void Delete(object id);
        Task<GridReader> ExecuteStoredProcedureMultipleValuesAsync(string query, Dictionary<string, object> parameters, string connectionString = null);
        Task<IEnumerable<N>> ExecuteStoredProcedureValuesAsync<N>(string query, Dictionary<string, object> parameters, string connectionString = null);
        bool Exists(Expression<Func<M, bool>> filter = null);
        Task<bool> ExistsAsync(Expression<Func<M, bool>> filter = null);
        IEnumerable<M> Get(Expression<Func<M, bool>> filter = null, Func<IQueryable<M>, IOrderedQueryable<M>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties);
        Task<IEnumerable<M>> GetAsync(Expression<Func<M, bool>> filter = null, Func<IQueryable<M>, IOrderedQueryable<M>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties);
        M GetById(object id);
        Task<M> GetByIdAsync(object id);
        Task<M> GetByIdsAsync(params object[] ids);
        Task<List<M>> GetListAsync(Expression<Func<M, bool>> filter = null, Func<IQueryable<M>, IOrderedQueryable<M>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties);
        IQueryable<M> GetQuery(Expression<Func<M, bool>> filter = null, Func<IQueryable<M>, IOrderedQueryable<M>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties);
        void Insert(M entity);
        Task InsertAsync(M entity);
        void SaveChanges();
        Task SaveChangesAsync();
        void Update(M entity, bool commitChanges = true);
        void UpdateAll(M entity);
        Task UpdateAllAsync(M entity);
        Task UpdateAsync(M entity);
    }
}

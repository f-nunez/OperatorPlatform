using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace OperatorPlatform.Data.Abstractions
{
    public class GenericRepository<M> : IGenericRepository<M> where M : class
    {
        private const string ICollectionPropertyTypeName = "ICollection";
        private const string SystemPropertyTypeName = "System";
        protected string ConnectionString;
        protected DbContext DbContext { get; private set; }
        protected DbSet<M> DbSet;
        protected bool Disposed;

        public GenericRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<M>();
            Disposed = false;
        }

        public IDbConnection GetConnection(string connectionString = null)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                var connection = DbContext.Database.GetDbConnection();
                ConnectionString = connection.ConnectionString;
            }

            return new SqlConnection(ConnectionString);
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public virtual int Count(Expression<Func<M, bool>> filter = null)
        {
            IQueryable<M> query = DbSet;
            if (filter != null)
            {
                query.Where(filter);
            }

            return query.Count();
        }

        public virtual async Task<int> CountAsync(Expression<Func<M, bool>> filter = null)
        {
            IQueryable<M> query = DbSet;
            if (filter != null)
            {
                query.Where(filter);
            }

            return await query.CountAsync();
        }

        public virtual void Delete(M entity)
        {
            var entry = DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            var item = GetById(id);
            Delete(item);
        }

        public async Task<SqlMapper.GridReader> ExecuteStoredProcedureMultipleValuesAsync(string query, Dictionary<string, object> parameters, string connectionString = null)
        {
            if (connectionString == null)
            {
                connectionString = ConnectionString;
            }

            using IDbConnection connection = GetConnection(connectionString);
            connection.Open();
            return await connection.QueryMultipleAsync($"{query}", GetDynamicParameters(parameters), commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<N>> ExecuteStoredProcedureValuesAsync<N>(string query, Dictionary<string, object> parameters, string connectionString = null)
        {
            if (connectionString == null)
            {
                connectionString = ConnectionString;
            }
            using IDbConnection dbConnection = GetConnection(connectionString);
            dbConnection.Open();
            return await dbConnection.QueryAsync<N>($"{query}", GetDynamicParameters(parameters), commandType: CommandType.StoredProcedure);
        }

        public bool Exists(Expression<Func<M, bool>> filter = null)
        {
            return GetQuery(filter).Any();
        }

        public async Task<bool> ExistsAsync(Expression<Func<M, bool>> filter = null)
        {
            return await GetQuery(filter).AnyAsync();
        }

        public IEnumerable<M> Get(Expression<Func<M, bool>> filter = null, Func<IQueryable<M>, IOrderedQueryable<M>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties)
        {
            return GetQuery(filter, orderBy, skip, take, includeProperties).AsNoTracking();
        }

        public virtual async Task<IEnumerable<M>> GetAsync(Expression<Func<M, bool>> filter = null, Func<IQueryable<M>, IOrderedQueryable<M>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties)
        {
            return await GetQuery(filter, orderBy, skip, take, includeProperties).AsNoTracking().ToListAsync();
        }

        public virtual M GetById(object id)
        {
            return DbSet.Find(id);
        }

        public async Task<M> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<M> GetByIdsAsync(params object[] ids)
        {
            return await DbSet.FindAsync(ids);
        }

        public virtual async Task<List<M>> GetListAsync(Expression<Func<M, bool>> filter = null, Func<IQueryable<M>, IOrderedQueryable<M>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties)
        {
            return await GetQuery(filter, orderBy, skip, take, includeProperties).AsNoTracking().ToListAsync();
        }

        public IQueryable<M> GetQuery(Expression<Func<M, bool>> filter = null, Func<IQueryable<M>, IOrderedQueryable<M>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties)
        {
            IQueryable<M> query = DbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter).AsNoTracking();
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty).AsNoTracking();
            }

            if (orderBy != null)
            {
                return orderBy(query).AsNoTracking();
            }

            if (skip.HasValue && take.HasValue)
            {
                query = query.Skip(skip.Value).Take(take.Value);
            }

            return query.AsNoTracking();
        }

        public virtual void Insert(M entity)
        {
            DbContext.Add(entity);
        }

        public async Task InsertAsync(M entity)
        {
            await DbContext.AddAsync(entity);
        }

        public virtual void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public virtual void Update(M entity, bool commitChanges = true)
        {
            var entry = DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                var key = GetPrimaryKeys(entity)[0];
                var currentEntry = GetById(key);
                if (currentEntry != null)
                {
                    var attachedEntry = DbContext.Entry(currentEntry);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    DbSet.Attach(entity);
                    DbContext.Entry(entity).State = EntityState.Modified;
                }
            }
            else if (entry.State == EntityState.Unchanged)
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }

            if (commitChanges && entry.State == EntityState.Modified)
            {
                DbContext.SaveChanges();
            }
        }

        public virtual void UpdateAll(M entity)
        {
            List<PropertyInfo> prop = entity.GetType()
                .GetProperties()
                .Where(p => !p.PropertyType.FullName.Contains(SystemPropertyTypeName) || p.PropertyType.Name.Contains(ICollectionPropertyTypeName))
                .ToList();
            foreach (PropertyInfo item in prop)
            {
                MethodInfo v = item.GetMethod;
            }
            EntityEntry<M> entry = DbContext.Entry(entity);
            object[] keys = GetPropertiesValues(entity);
            if (entry.State == EntityState.Detached)
            {
                object key = GetPrimaryKeys(entity)[0];
                M currentEntry = GetById(key);
                if (currentEntry != null)
                {
                    EntityEntry<M> attachedEntry = DbContext.Entry(currentEntry);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    DbSet.Attach(entity);
                    DbContext.Entry(entity).State = EntityState.Modified;
                }
            }
            else if (entry.State == EntityState.Unchanged)
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual async Task UpdateAllAsync(M entity)
        {
            List<PropertyInfo> prop = entity.GetType()
                .GetProperties()
                .Where(p => !p.PropertyType.FullName.Contains(SystemPropertyTypeName) || p.PropertyType.Name.Contains(ICollectionPropertyTypeName))
                .ToList();
            foreach (PropertyInfo item in prop)
            {
                MethodInfo v = item.GetMethod;
            }
            EntityEntry<M> entry = DbContext.Entry(entity);
            object[] keys = GetPropertiesValues(entity);
            if (entry.State == EntityState.Detached)
            {
                object key = GetPrimaryKeys(entity)[0];
                M currentEntry = await GetByIdAsync(key);
                if (currentEntry != null)
                {
                    EntityEntry<M> attachedEntry = DbContext.Entry(currentEntry);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    DbSet.Attach(entity);
                    DbContext.Entry(entity).State = EntityState.Modified;
                }
            }
            else if (entry.State == EntityState.Unchanged)
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public async Task UpdateAsync(M entity)
        {
            var entry = DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                var key = GetPrimaryKeys(entity);
                var currentEntry = await GetByIdsAsync(key);
                if (currentEntry != null)
                {
                    var attachedEntry = DbContext.Entry(currentEntry);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    DbSet.Attach(entity);
                    DbContext.Entry(entity).State = EntityState.Modified;
                }
            }
            else if (entry.State == EntityState.Unchanged)
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Helpers
        private string[] GetKeyNames()
        {
            return DbContext.Model.FindEntityType(typeof(M)).FindPrimaryKey().Properties.Select(x => x.Name).ToArray();
        }

        private string[] GetProperties()
        {
            return DbContext.Model.FindEntityType(typeof(M)).GetProperties().Select(x => x.Name).ToArray();
        }

        private object[] GetPropertiesValues(M entity)
        {
            var keyNames = GetProperties();
            Type type = typeof(M);
            var keys = new object[keyNames.Length];
            for (int i = 0; i < keyNames.Length; i++)
            {
                keys[i] = type.GetProperty(keyNames[i]).GetValue(entity, null);
            }

            return keys;
        }

        private object[] GetPrimaryKeys(M entity)
        {
            var keyNames = GetKeyNames();
            Type type = typeof(M);
            var keys = new object[keyNames.Length];
            for (int i = 0; i < keyNames.Length; i++)
            {
                keys[i] = type.GetProperty(keyNames[i]).GetValue(entity, null);
            }

            return keys;
        }

        protected void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                DbContext.Dispose();
            }
            Disposed = true;
        }

        protected DynamicParameters GetDynamicParameters(Dictionary<string, object> parameters)
        {
            var sqlParameters = new DynamicParameters();
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                if (pair.Value is DataTable table)
                {
                    sqlParameters.Add(pair.Key, table.AsTableValuedParameter());
                }
                else
                {
                    sqlParameters.Add(pair.Key, pair.Value);
                }
            }

            return sqlParameters;
        }
        #endregion
    }
}

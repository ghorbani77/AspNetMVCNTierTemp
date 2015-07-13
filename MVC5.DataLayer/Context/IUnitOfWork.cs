using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RefactorThis.GraphDiff;
using RefactorThis.GraphDiff.Internal.Graph;
namespace MVC5.DataLayer.Context
{
    public interface IUnitOfWork : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class;
        void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class;
         void MarkAsAdded<TEntity>(TEntity entity) where TEntity : class;
        IList<T> GetRows<T>(string sql, params object[] parameters) where T : class;
        int SaveAllChanges(bool invalidateCacheDependencies = true);
        Task<int> SaveAllChangesAsync(bool invalidateCacheDependencies = true);
        void AutoDetectChangesEnabled(bool flag = true);
        IEnumerable<TEntity> AddThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void ForceDatabaseInitialize();
        void EnableFiltering(string name);
        void EnableFiltering(string name,string parameter,object value);
        void DisableFiltering(string name);
        void BulkInsertData<T>(IList<T> data);

     
        T Update<T>( T entity,
            Expression<Func<IUpdateConfiguration<T>, object>> mapping) where T : class,new();

      
    }
}

       

       
        
     
      
   
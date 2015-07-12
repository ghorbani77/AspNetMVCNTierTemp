using System.Data.Entity.Infrastructure.Interception;
using EntityFramework.BulkInsert.Extensions;
using EntityFramework.Filters;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC5.DomainClasses.Configurations;
using MVC5.DomainClasses.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using MVC5.Utility;

namespace MVC5.DataLayer.Context
{
    public class ApplicationDbContext :
           IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>,
           IUnitOfWork
    {
     
        #region Constructor


        public ApplicationDbContext()
            : base("DefaultConnection")
        {
           // Configuration.LazyLoadingEnabled = false;

        }
        #endregion

        #region IUnitOfWork

     
        public new System.Data.Entity.IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IList<T> GetRows<T>(string sql, params object[] parameters) where T : class
        {
            throw new NotImplementedException();
        }

        public int SaveAllChanges(bool invalidateCacheDependencies = true)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAllChangesAsync(bool invalidateCacheDependencies = true)
        {
            throw new NotImplementedException();
        }

        public void AutoDetectChangesEnabled(bool flag = true)
        {
            Configuration.AutoDetectChangesEnabled = flag;
        }

        public IEnumerable<TEntity> AddThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            throw new NotImplementedException();
        }

      
        public void ForceDatabaseInitialize()
        {
            base.Database.Initialize(force: true);
        }

     

        public void EnableFiltering(string name)
        {
            this.EnableFilter(name);
        }

        public void EnableFiltering(string name, string parameter, object value)
        {
            this.EnableFilter(name).SetParameter(parameter, value);
        }

        public void DisableFiltering(string name)
        {
            this.DisableFilter(name);
        }

        public void BulkInsertData<T>(IList<T> data)
        {
            this.BulkInsert(data);
        }
        #endregion

        #region Override OnModelCreating

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DbInterception.Add(new FilterInterceptor());
            DbInterception.Add(new YeKeInterceptor());

            modelBuilder.Configurations.Add(new ApplicationRoleGroupConfig());
            modelBuilder.Configurations.Add(new ApplicationUserGroupConfig());
            modelBuilder.Configurations.Add(new ApplicationGroupConfig());

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogins");
        }
        #endregion

        #region IDbSets

        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { get; set; }
        public DbSet<ApplicationGroup> ApplicationGroups { get; set; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { get; set; }
        #endregion
      
    }
}

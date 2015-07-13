using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using EFSecondLevelCache;
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
using System.Data.Objects;

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

        private string[] GetChangedEntityNames()
        {
            return ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added ||
                            x.State == EntityState.Modified ||
                            x.State == EntityState.Deleted)
                .Select(x => ObjectContext.GetObjectType(x.Entity.GetType()).FullName)
                .Distinct()
                .ToArray();
        }
        public new System.Data.Entity.IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State=EntityState.Modified;
        }

        public void MarkAsAdded<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Added;
        }
        public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Deleted;
        }

        public IList<T> GetRows<T>(string sql, params object[] parameters) where T : class
        {
            return Database.SqlQuery<T>(sql, parameters).ToList();
        }
        public override int SaveChanges()
        {
            return SaveAllChanges();
        }

        public int SaveAllChanges(bool invalidateCacheDependencies = true)
        {
            var result = base.SaveChanges();
            if (!invalidateCacheDependencies) return result;
            var changedEntityNames = GetChangedEntityNames();
            new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
            return result;
        }
       
        public override Task<int> SaveChangesAsync()
        {
            return SaveAllChangesAsync();
        }
        public Task<int> SaveAllChangesAsync(bool invalidateCacheDependencies = true)
        {
            var result = base.SaveChangesAsync();
            if (!invalidateCacheDependencies) return result;

            var changedEntityNames = GetChangedEntityNames();
            new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
            return result;
        }

        public void AutoDetectChangesEnabled(bool flag = true)
        {
            Configuration.AutoDetectChangesEnabled = flag;
        }

        public IEnumerable<TEntity> AddThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            return ((DbSet<TEntity>) Set<TEntity>()).AddRange(entities);
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

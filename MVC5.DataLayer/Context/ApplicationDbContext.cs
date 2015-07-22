using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using EFSecondLevelCache;
using EntityFramework.BulkInsert.Extensions;
using EntityFramework.Filters;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC5.DomainClasses.Configurations;
using MVC5.DomainClasses.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using MVC5.Utility;
using System.Data.Objects;
using RefactorThis.GraphDiff;

namespace MVC5.DataLayer.Context
{
    public class ApplicationDbContext : IdentityDbContext
        <ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>,
        IUnitOfWork
    {

        #region Constructor


        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            //this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            //for bulk insert
            //this.Configuration.AutoDetectChangesEnabled = false;


        }

        #endregion

        #region IUnitOfWork

        public T Update<T>(T entity, System.Linq.Expressions.Expression<Func<IUpdateConfiguration<T>, object>> mapping)
            where T : class, new()
        {
            
            return this.UpdateGraph(entity, mapping);
           
        }

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
            Entry(entity).State = EntityState.Modified;
        }
        public void MarkAsDetached<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Detached;
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
            return null;
        }

      

        public IEnumerable<TEntity> AddThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            return ((DbSet<TEntity>)Set<TEntity>()).AddRange(entities);
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

        public bool ValidateOnSaveEnabled
        {
            get { return Configuration.ValidateOnSaveEnabled; }
            set {Configuration.ValidateOnSaveEnabled = value; }
        }

        public bool ProxyCreationEnabled
        {
            get { return Configuration.ProxyCreationEnabled; }
            set { Configuration.ProxyCreationEnabled = value; }
        }

        bool IUnitOfWork.AutoDetectChangesEnabled
        {
            get { return Configuration.AutoDetectChangesEnabled; }
            set { Configuration.AutoDetectChangesEnabled = value; }
        }

        public bool ForceNoTracking { get; set; }
        #endregion

        #region Override OnModelCreating

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Config(modelBuilder);
            DbInterception.Add(new FilterInterceptor());
            DbInterception.Add(new YeKeInterceptor());
            modelBuilder.Configurations.AddFromAssembly(typeof(SettingConfig).GetTypeInfo().Assembly);
            LoadEntities(typeof(ApplicationUser).GetTypeInfo().Assembly, modelBuilder, "MVC5.DomainClasses.Entities");
        }

        #endregion

        #region AutoRegisterEntityType

        public void LoadEntities(Assembly asm, DbModelBuilder modelBuilder, string nameSpace)
        {
            var entityTypes = asm.GetTypes()
                .Where(type => type.BaseType != null &&
                               type.Namespace == nameSpace &&
                               type.BaseType == null)
                .ToList();

            var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");
            entityTypes.ForEach(type => entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[] { }));
        }
        #endregion

        #region AspNetIdentityConfig

        private static void Config(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users")
                .Filter("IsDeleted_User", a => a.Condition(u => u.IsDeleted))
                .Filter("IsBanned_User", a => a.Condition(u => u.IsBanned))
                .Filter("IsSystemAccount", a => a.Condition(u => u.IsSystemAccount))
                .Filter("ChangeProfilePicture", a => a.Condition(u => u.CanChangeProfilePicture))
                .Filter("ModifyFirstAndLastName", a => a.Condition(u => u.CanModifyFirsAndLastName))
                .Filter("CanUploadFile", a => a.Condition(u => u.CanUploadFile));



            modelBuilder.Entity<ApplicationRole>()
                .ToTable("Roles")
                .Filter("IsSystemRole", a => a.Condition(r => r.IsSystemRole));

            modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogins");
        }

        #endregion

        #region IDbSets

        public DbSet<Setting> Settings { get; set; }
        public DbSet<ApplicationPermission> ApplicationPermissions { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<ActivityLogType> ActivityLogTypes { get; set; }

        #endregion



    }
}

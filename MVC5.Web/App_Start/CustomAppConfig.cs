using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using CaptchaMvc.Infrastructure;
using ElmahEFLogger.CustomElmahLogger;
using MVC5.Common.Helpers;
using MVC5.Common.Helpers.Extentions;
using MVC5.Common.Helpers.Json;
using MVC5.DataLayer.Context;
using MVC5.DataLayer.Migrations;
using MVC5.IocConfig;
using System.Linq;
using System.Web.Mvc;

namespace MVC5.Web
{
    public static class CustomAppConfig
    {
        public static void Config()
        {
            // disable response header for protection  attak
            MvcHandler.DisableMvcResponseHeader = true;

            // change captcha provider for using cookie
            CaptchaUtils.CaptchaManager.StorageProvider = new CookieStorageProvider();

            //Set current Controller factory as StructureMapControllerFactory
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

            //set current Filter factory as StructureMapFitlerProvider
            var filterProider = FilterProviders.Providers.Single(p => p is FilterAttributeFilterProvider);
            FilterProviders.Providers.Remove(filterProider);
            FilterProviders.Providers.Add(ProjectObjectFactory.Container.GetInstance<StructureMapFilterProvider>());

            // Database.SetInitializer<ApplicationDbContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            ProjectObjectFactory.Container.GetInstance<IUnitOfWork>().ForceDatabaseInitialize();

            var defaultJsonFactory = ValueProviderFactories.Factories
                .OfType<JsonValueProviderFactory>().FirstOrDefault();
            var index = ValueProviderFactories.Factories.IndexOf(defaultJsonFactory);
            ValueProviderFactories.Factories.Remove(defaultJsonFactory);
            ValueProviderFactories.Factories.Insert(index, new JsonNetValueProviderFactory());


            //ad interception for logg EF errors
            DbInterception.Add(new ElmahEfInterceptor());


        }
    }
}
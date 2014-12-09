using System.Collections.Generic;
using System.Linq;
using Searchinator.Service.Core;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Searchinator.Service.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Searchinator.Service.App_Start.NinjectWebCommon), "Stop")]

namespace Searchinator.Service.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            IList<IBaseSearchRule> baseSearchRules =
                kernel.GetAll<IBaseSearchRule>().ToList();

            IList<IGeneralInfoSearchRule> generalInfoSearchRules =
                kernel.GetAll<IGeneralInfoSearchRule>().ToList();
            
            kernel.Bind<ISearch>()
                .To<Search>()
                .WithConstructorArgument(
                    Search.CTOR_SEARCH_RULES_ARG_NAME, 
                    k=>k.Kernel.GetAll<IBaseSearchRule>());

            kernel.Bind<IGeneralInfoSectionSearch>()
                .To<GeneralInfoSectionSearch>()
                .WithConstructorArgument(
                    GeneralInfoSectionSearch.CTOR_GENERAL_INFO_SEARCH_RULES_ARG_NAME,
                    k=>k.Kernel.GetAll<IGeneralInfoSectionSearch>());

           

          
        }        
    }
}

using Enterprise.Framework.BusinessLogics.User;
using Enterprise.Framework.BusinessLogics.User.Abstract;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.DataLayers.Extend.Abstract;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.Repository.UserRepository;
using Enterprise.Workflows.Helpers.Converters;
using Enterprise.Workflows.Helpers.Converters.Abstract;
using Enterprise.Workflows.Invoker.User;
using Enterprise.Workflows.Invoker.User.Abstract;
using Microsoft.Practices.Unity;
using System.Configuration;
using System.Web.Http;
using Unity.WebApi;

namespace Enterprise.Workflows.Client
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            #region dbcontext
            container.RegisterType<IUserContext, UserContext>(new HierarchicalLifetimeManager(), new InjectionFactory(x => new UserContext(ConfigurationManager.ConnectionStrings["UserContext"].ConnectionString)));
            container.RegisterType<IProductContext, ProductContext>(new HierarchicalLifetimeManager(), new InjectionFactory(x => new UserContext(ConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString)));
            container.RegisterType<IHelperContext, HelperContext>(new HierarchicalLifetimeManager(), new InjectionFactory(x => new UserContext(ConfigurationManager.ConnectionStrings["HelperContext"].ConnectionString)));
            container.RegisterType<ITransactionContext, TransactionContext>(new HierarchicalLifetimeManager(), new InjectionFactory(x => new UserContext(ConfigurationManager.ConnectionStrings["TransactionContext"].ConnectionString)));
            #endregion

            #region business logic
            container.RegisterType<IUserLoginBusinessLogic, UserLoginBusinessLogic>();
            #endregion

            #region invoker
            container.RegisterType<IUserWorkflowInvoker, UserRegistrationWorkflowInvoker>();
            #endregion

            #region repository
            container.RegisterType<ITblUserLoginRepository, TblUserLoginRepository>();
            #endregion

            #region converter
            container.RegisterType<ICategoryConverter, CategoryConverter>();
            container.RegisterType<IHotProductConverter, HotProductConverter>();
            container.RegisterType<IInsertProductConverter, InsertProductConverter>();
            container.RegisterType<IRecommendedProductConverter, RecommendedProductConverter>();
            container.RegisterType<IUserRegistrationConverter, UserRegistrationConverter>();
            #endregion
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
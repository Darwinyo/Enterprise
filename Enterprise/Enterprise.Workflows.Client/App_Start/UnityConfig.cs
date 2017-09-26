using Enterprise.Framework.BusinessLogics.Periode;
using Enterprise.Framework.BusinessLogics.Periode.Abstract;
using Enterprise.Framework.BusinessLogics.Product;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Framework.BusinessLogics.User;
using Enterprise.Framework.BusinessLogics.User.Abstract;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.DataLayers.Extend.Abstract;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.Repository.HelperRepository;
using Enterprise.Framework.Repository.ProductRepository;
using Enterprise.Framework.Repository.UserRepository;
using Enterprise.Workflows.Helpers.Converters;
using Enterprise.Workflows.Helpers.Converters.Abstract;
using Enterprise.Workflows.Invoker.Abstract;
using Enterprise.Workflows.Invoker.Category;
using Enterprise.Workflows.Invoker.Product;
using Enterprise.Workflows.Invoker.User;
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
            container.RegisterType<IProductContext, ProductContext>(new HierarchicalLifetimeManager(), new InjectionFactory(x => new ProductContext(ConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString)));
            container.RegisterType<IHelperContext, HelperContext>(new HierarchicalLifetimeManager(), new InjectionFactory(x => new HelperContext(ConfigurationManager.ConnectionStrings["HelperContext"].ConnectionString)));
            container.RegisterType<ITransactionContext, TransactionContext>(new HierarchicalLifetimeManager(), new InjectionFactory(x => new TransactionContext(ConfigurationManager.ConnectionStrings["TransactionContext"].ConnectionString)));
            #endregion

            #region business logic
            container.RegisterType<IUserLoginBusinessLogic, UserLoginBusinessLogic>();
            container.RegisterType<IPeriodeBusinessLogic, PeriodeBusinessLogic>();
            container.RegisterType<ICategoryBusinessLogic, CategoryBusinessLogic>();
            container.RegisterType<IHotProductBusinessLogic, HotProductBusinessLogic>();
            container.RegisterType<IProductBusinessLogic, ProductBusinessLogic>();
            container.RegisterType<IRecommendedProductBusinessLogic, RecommendedProductBusinessLogic>();
            #endregion

            #region invoker
            container.RegisterType<IUserRegistrationWorkflowInvoker, UserRegistrationWorkflowInvoker>();
            container.RegisterType<IHotProductWorkflowInvoker, HotProductWorkflowInvoker>();
            container.RegisterType<IInsertProductWorkflowInvoker, InsertProductWorkflowInvoker>();
            container.RegisterType<IRecommendedProductWorkflowInvoker, RecommendedProductWorkflowInvoker>();
            container.RegisterType<ICategoryWorkflowInvoker, CategoryWorkflowInvoker>();
            #endregion

            #region repository
            container.RegisterType<ITblUserLoginRepository, TblUserLoginRepository>();
            container.RegisterType<ITblProductRepository, TblProductRepository>();
            container.RegisterType<ITblCategoryRepository, TblCategoryRepository>();
            container.RegisterType<ITblCityRepository, TblCityRepository>();
            container.RegisterType<ITblPeriodeRepository, TblPeriodeRepository>();
            container.RegisterType<ITblProductHotRepository, TblProductHotRepository>();
            container.RegisterType<ITblProductImageRepository, TblProductImageRepository>();
            container.RegisterType<ITblProductRecommendedRepository, TblProductRecommendedRepository>();
            container.RegisterType<ITblProductSpecsRepository, TblProductSpecsRepository>();
            container.RegisterType<ITblProductVariationsRepository, TblProductVariationsRepository>();
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
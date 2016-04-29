using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using DbLogic.Repositories.Implementations;
using DbLogic.Repositories.Interfaces;
using Domain;
using Ninject;

namespace WebApiApp
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBinding();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBinding()
        {
            _ninjectKernel.Bind<IComputerRepository>().To<ComputerRepository>();
            _ninjectKernel.Bind<IManufacturerRepository>().To<ManufacturerRepository>();
            _ninjectKernel.Bind<IUserRepository>().To<UserRepository>();
            
            _ninjectKernel.Bind<DbDataContext>()
                          .ToSelf()
                          .WithConstructorArgument("connectionString",
                                                   ConfigurationManager.ConnectionStrings[0].ConnectionString);
        }

        private readonly IKernel _ninjectKernel;
    }
}
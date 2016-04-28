using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        // извлекаем экземпляр контроллера для заданного контекста запроса и типа контроллера   
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }

        // опрделим все привязки   
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
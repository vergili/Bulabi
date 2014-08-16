using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Configuration;

using bulabi.Domain.Entities;
using bulabi.Domain.Abstract;

using bulabi.Domain.Concrete;
using bulabi.WebUI.Infrastructure.Abstract;
using bulabi.WebUI.Infrastructure.Concrete;

namespace bulabi.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {

            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
            ninjectKernel.Bind<IVideoRepository>().To<EFVideoRepository>();

            //EmailSettings emailSettings = new EmailSettings
            //{
            //    WriteAsFile = bool.Parse(ConfigurationManager
            //        .AppSettings["Email.WriteAsFile"] ?? "false")
            //};

            //ninjectKernel.Bind<IOrderProcessor>()
            //    .To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);

            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();


            /* // this is  not taking from database   
            // Mock implementation of the IProductRepository Interface
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product> {
            new Product { Name = "Football", Country = "Turkey" },
            new Product { Name = "Surf board", Country = "Almanya" },
            new Product { Name = "Running shoes", Country = "Amerika" }
            }.AsQueryable());
            ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object); */
        }
    }
}
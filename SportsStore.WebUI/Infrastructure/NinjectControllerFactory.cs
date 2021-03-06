﻿using System;
using System.Web.Mvc; 
using System.Web.Routing;
using System.Linq;
using System.Collections.Generic; 

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;

using Ninject; 
using Moq;
namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext,
            Type controllerType)
        {

            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            //// Имитированная реализация интерфейса IProductRepository 
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
           
            //mock.Setup(m => m.Products).Returns(new List<Product> { 
            //    new Product { Name = "Football", Price = 25 }, 
            //    new Product { Name = "Surf board", Price = 179 }, 
            //    new Product { Name = "Running shoes", Price = 95 } 
            //    }.AsQueryable());

            //ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);

            //указывает Ninject, что необходимо создавать экземпляры класса EfProductRepository для обсуживания
            //запросов к интерфейсу IProductRepository
			ninjectKernel.Bind<IUserRepository>().To<EFUserRepository>();
			ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}
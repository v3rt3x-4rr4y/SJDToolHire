using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using SJDToolHire.Domain.Abstract;
using SJDToolHire.Domain.Entities;
using SJDToolHire.Domain.Concrete;

namespace SJDToolHire.WebUI.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;
        
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings() 
        {

            //Mock<IToolRepository> mock = new Mock<IToolRepository>();
            //mock.Setup(m => m.Tools).Returns(new List<Tool>
            //{
            //    new Tool { Name = "Jigsaw", Rate = 22, Description = "", Power = "230v", Category = "Saws", Weight = "3.4kg", ImageUrl = "~/Content/Images/jigsaw.jpg"},
            //    new Tool { Name = "350mm Angle Grinder", Rate = 38, Description = "", Power = "230v", Category = "Grinders", Weight = "10.9kg", ImageUrl = "~/Content/Images/angle-grinder.jpg" },
            //    new Tool { Name = "MIG Welder", Rate = 56, Description = "", Power = "230v", Category = "Welders", Weight = "18.0kg", ImageUrl = "~/Content/Images/mig-welder.jpg" }
            //});
            //kernel.Bind<IToolRepository>().ToConstant(mock.Object);

            kernel.Bind<IToolRepository>().To<EFToolRepository>();

        }
   }
}
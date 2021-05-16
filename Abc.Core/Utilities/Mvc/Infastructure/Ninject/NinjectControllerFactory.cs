using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Abc.Core.Utilities.Mvc.Infastructure.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        IKernel _kernel;

        // kernel is a container name for ninject.


        // modules as a parameter , when I create a factory class, I'll be able to give modules like BusinessModule in Business then create instance for them.
        public NinjectControllerFactory(params INinjectModule[] modules)  
        {
            _kernel = new StandardKernel(modules);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);

            // what does this method do?
            // when you make a request to a controller in MVC, MVC creates an instance of that controller.
            // Since we replaced default parameterless creator method with the one requires IProductService, MVC doesn't know what to do.
            // In here, we tell MVC to have _kernel to resolve controller type.

            // for example, when ProductController receives a request, kernel will see that it asks for a IProductService.
            // then kernel goes to BusinessModule under BusinessLayer which we adressed it to in ctor of this NinjectControllerFactory class, 
            // then kernel will know that when IProductService is requested, he should return an instance of ProductManager.
            // basically, thats how IOC works for MVC.
        }

        // to tell MVC to use this controller factory over default one, under the Global.asax file add following code.
        // ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
    }
}

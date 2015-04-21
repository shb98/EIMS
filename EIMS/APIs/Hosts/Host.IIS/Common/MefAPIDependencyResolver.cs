using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Web.Http.Dependencies;
using Core.Common.Extensions;

namespace Host.IIS.Common
{
    public class MefAPIDependencyResolver : IDependencyResolver
    {
        public MefAPIDependencyResolver(CompositionContainer container)
        {
            _Container = container;
        }

        CompositionContainer _Container;

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return _Container.GetExportedValueByType(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _Container.GetExportedValuesByType(serviceType);
        }

        public void Dispose()
        {
        }
    }
}

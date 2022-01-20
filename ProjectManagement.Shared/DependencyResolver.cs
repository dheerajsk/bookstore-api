using Microsoft.EntityFrameworkCore;
using System;

namespace ProjectManagement.Shared
{
    public class DependencyResolver : DbContext
    {
        private static DependencyResolver Resolver;
        private readonly IServiceProvider ServiceProvider;

        public static DependencyResolver Current
        {
            get
            {
                if (Resolver == null)
                    throw new Exception("Dpeendency Resolver not initialized");
                return Resolver;
            }
        }

        private DependencyResolver(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public static void Init(IServiceProvider serviceProvider)
        {
            Resolver = new DependencyResolver(serviceProvider);
        }

        public object GetService(Type serviceType)
        {
            return ServiceProvider.GetService(serviceType);

        }

        public T GetService<T>()
        {
            return (T)ServiceProvider.GetService(typeof(T));
        }
    }
}

using EncryptationDavidRivas.DAL.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptationDavidRivas.DAL.Bootstrap
{
    public static class Bootstrapper
    {
        public static void Bootstrapp(Container container)
        {
            container.Register<IUserRepository, UserRepository>(Lifestyle.Singleton);
        }
    }
}

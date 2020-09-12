using EncryptationDavidRivas.DAL.Repositories;
using SimpleInjector;

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

using EncryptationDavidRivas.BL.Services;
using SimpleInjector;

namespace EncryptationDavidRivas.BL.Bootstrap
{
    public static class Bootstrapper
    {
        public static void Bootstrapp(Container container)
        {
            container.Register<IEncryptionDecryptionService, EncryptionDecryptionService>(Lifestyle.Singleton);
            container.Register<IEncryptionService, EncryptionService>(Lifestyle.Singleton);
            container.Register<IDecryptionService, DecryptionService>(Lifestyle.Singleton);
        }
    }
}

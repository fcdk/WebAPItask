using DataLayer.Repositories;
using DataLayer.RepositoryInterfaces;
using Ninject;

namespace SDSK.API
{
    public static class NinjectBindServices
    {
        public static void BindServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAttachementRepository)).To(typeof(AttachementFakeRepository)).InSingletonScope();
            kernel.Bind(typeof(IJiraItemRepository)).To(typeof(JiraItemFakeRepository)).InSingletonScope();
            kernel.Bind(typeof(IMailRepository)).To(typeof(MailFakeRepository)).InSingletonScope();            
        }
    }
}

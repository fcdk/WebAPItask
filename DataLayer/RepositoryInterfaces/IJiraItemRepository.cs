using Epam.Sdesk.Model;

namespace DataLayer.RepositoryInterfaces
{
    public interface IJiraItemRepository
    {
        JiraItem GetById(long id);
    }
}

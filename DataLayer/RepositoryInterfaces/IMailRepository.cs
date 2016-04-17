using System.Collections.Generic;
using Epam.Sdesk.Model;

namespace DataLayer.RepositoryInterfaces
{
    public interface IMailRepository
    {
        bool Add(Mail mail);
        IEnumerable<Mail> GetAll();
        Mail GetById(long id);
        bool Update(long id, Mail mail);
        bool Delete(long id);
    }
}

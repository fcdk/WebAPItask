using System.Collections.Generic;
using Epam.Sdesk.Model;

namespace DataLayer.RepositoryInterfaces
{
    public interface IAttachementRepository
    {
        IEnumerable<Attachement> GetAttachementsByMailId(int mailId);
        Attachement GetAttachementsByMailIdAndAttachementId(int mailId, int attachementId);
        Attachement GetAttachementsByMailIdAndAttachementIdAndFileExtention(int mailId, int attachementId, string fileExtention);
        Attachement GetAttachementsByMailIdAndAttachementIdAndStatusId(int mailId, int attachementId, int statusId);
        Attachement GetAttachementsByMailIdAndAttachementIdAndFileExtentionAndStatusId(int mailId, int attachementId, string fileExtention, int? statusId);
        bool Update(int mailId, int attachementId, Attachement attachement);
        bool Add(Attachement attachement);
        bool Delete(Attachement attachement);
    }
}

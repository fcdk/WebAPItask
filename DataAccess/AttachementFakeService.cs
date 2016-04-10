using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using Epam.Sdesk.Model;

namespace Epam.Sdesk.DataAccess
{
    public class AttachementFakeService
    {
        private readonly ICollection<Attachement> _mails = new List<Attachement>
        {
            new Attachement
            {
                Id = 1,
                MailId = 1,
                FileExtention = "rar",
                StatusId = 1
            },
            new Attachement
            {
                Id = 2,
                MailId = 1,
                FileExtention = "jpg",
                StatusId = 2
            },
            new Attachement
            {
                Id = 3,
                MailId = 2,
                FileExtention = "zip",
                StatusId = 1
            }
        };

        public IEnumerable<Attachement> GetAttachementsByMailId(int mailId)
        {
            return _mails.Where(x => x.MailId == mailId);
        }

        public Attachement GetAttachementsByMailIdAndAttachementId(int mailId, int attachementId)
        {
            return _mails.FirstOrDefault(x => x.MailId == mailId && x.Id == attachementId);
        }

        public Attachement GetAttachementsByMailIdAndAttachementIdAndFileExtention(int mailId, int attachementId, string fileExtention)
        {
            return _mails.FirstOrDefault(x => x.MailId == mailId && x.Id == attachementId && x.FileExtention == fileExtention);
        }

        public Attachement GetAttachementsByMailIdAndAttachementIdAndFileExtentionAndStatusId(int mailId, int attachementId, string fileExtention, int statusId)
        {
            return _mails.FirstOrDefault(x => x.MailId == mailId && x.Id == attachementId && x.FileExtention == fileExtention && x.StatusId == statusId);
        }

    }
}

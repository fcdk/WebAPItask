using System.Collections.Generic;
using System.Linq;
using Epam.Sdesk.Model;

namespace DataLayer
{
    public class AttachementFakeRepository
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

        public Attachement GetAttachementsByMailIdAndAttachementIdAndStatusId(int mailId, int attachementId, int statusId)
        {
            return _mails.FirstOrDefault(x => x.MailId == mailId && x.Id == attachementId && x.StatusId == statusId);
        }

        public Attachement GetAttachementsByMailIdAndAttachementIdAndFileExtentionAndStatusId(int mailId, int attachementId, string fileExtention, int? statusId)
        {
            if (fileExtention != null && statusId != null)
                return _mails.FirstOrDefault(x => x.MailId == mailId && x.Id == attachementId && x.FileExtention == fileExtention && x.StatusId == statusId);
            if (fileExtention != null && statusId == null)
                return GetAttachementsByMailIdAndAttachementIdAndFileExtention(mailId, attachementId, fileExtention);
            if (fileExtention == null && statusId != null)
                return GetAttachementsByMailIdAndAttachementIdAndStatusId(mailId, attachementId, (int)statusId);
            return GetAttachementsByMailIdAndAttachementId(mailId, attachementId);
        }

        public bool Update(int mailId, int attachementId, Attachement attachement)
        {
            if (mailId != attachement.MailId || attachementId != attachement.Id)
                return false;

            var attachementToUpdate = _mails.FirstOrDefault(x => x.MailId == mailId && x.Id == attachementId);
            if (attachementToUpdate == null)
                return false;

            _mails.Remove(attachementToUpdate);
            _mails.Add(attachement);
            return true;
        }

        public bool Add(Attachement attachement)
        {
            _mails.Add(attachement);
            return true;
        }

        public bool Delete(Attachement attachement)
        {
            return _mails.Remove(attachement);
        }

    }
}

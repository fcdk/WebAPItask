using System.Collections.Generic;
using System.Linq;
using Epam.Sdesk.Model;

namespace Epam.Sdesk.DataAccess
{
    public class MailFakeRepository
    {
        private readonly ICollection<Mail> _mails = new List<Mail>
        {
            new Mail
            {
                Id = 1,
                Sender = "lol@lol.com"
            },
            new Mail
            {
                Id = 2,
                Sender = "ahah@ahaha.com"
            }
        };

        public bool Add(Mail mail)
        {
            _mails.Add(mail);
            return true;
        }

        public IEnumerable<Mail> GetAll()
        {
            return _mails;
        }

        public Mail GetById(long id)
        {
            return _mails.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(long id, Mail mail)
        {
            if (id != mail.Id)
                return false;

            var mailToUpdate = _mails.FirstOrDefault(x => x.Id == id);
            if (mailToUpdate == null)
                return false;

            _mails.Remove(mailToUpdate);
            _mails.Add(mail);            
            return true;
        }

        public bool Delete(long id)
        {
            var mailToDelete = _mails.FirstOrDefault(x => x.Id == id);
            if (mailToDelete == null)
                return false;
            _mails.Remove(mailToDelete);
            return true;
        }

    }
}

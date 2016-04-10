using System.Collections.Generic;
using System.Web.Http;
using Epam.Sdesk.DataAccess;
using Epam.Sdesk.Model;

namespace SDSK.API.Controllers
{
    public class MailsController : ApiController
    {
        private readonly MailFakeService _mailService = new MailFakeService();

        // GET api/mails
        public IEnumerable<Mail> GetAll()
        {
            return _mailService.GetAll();
        }

        // GET /api/mails/{id}
        public Mail Get(long id)
        {
            return _mailService.GetById(id);
        }

        // PUT /api/mails/{id}
        public bool Put(long id, Mail mail)
        {
            return _mailService.Update(id, mail);
        }

        // POST /api/mails
        public bool Post(Mail mail)
        {
            return _mailService.Add(mail);
        }

        // DELETE /api/mails/{id}
        public bool Delete(long id)
        {
            return _mailService.Delete(id);
        }

    }
}

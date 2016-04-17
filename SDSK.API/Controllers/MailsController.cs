using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer.RepositoryInterfaces;
using Epam.Sdesk.Model;

namespace SDSK.API.Controllers
{
    public class MailsController : ApiController
    {
        private readonly IMailRepository _mailRepository;

        public MailsController(IMailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }

        // GET api/mails
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _mailRepository.GetAll());
        }

        // GET /api/mails/{id}
        public HttpResponseMessage Get(long id)
        {
            var mail = _mailRepository.GetById(id);
            if (mail == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, mail);
        }

        // PUT /api/mails/{id}
        public HttpResponseMessage Put(long id, Mail mail)
        {
            bool isSuccessfulUpdate = _mailRepository.Update(id, mail);
            if (!isSuccessfulUpdate)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST /api/mails
        public HttpResponseMessage Post(Mail mail)
        {
            bool isSuccessfulAdd = _mailRepository.Add(mail);
            if (!isSuccessfulAdd)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE /api/mails/{id}
        public HttpResponseMessage Delete(long id)
        {
            bool isSuccessfulDelete = _mailRepository.Delete(id);
            if (!isSuccessfulDelete)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}


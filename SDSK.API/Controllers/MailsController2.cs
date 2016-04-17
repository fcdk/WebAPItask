using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer.RepositoryInterfaces;
using Epam.Sdesk.Model;
using SDSK.API.Attributes;

namespace SDSK.API.Controllers
{
    public class Mails2Controller : ApiController
    {
        private readonly IMailRepository _mailRepository;
        private readonly IAttachementRepository _attachementRepository;

        public Mails2Controller(IMailRepository mailRepository, IAttachementRepository attachementRepository)
        {
            _mailRepository = mailRepository;
            _attachementRepository = attachementRepository;
        }

        // GET /api/mails
        [ApiVersionRoute("api/mails")]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _mailRepository.GetAll());
        }

        // GET /api/mails/{id}
        [ApiVersionRoute("api/mails/{id}")]
        public HttpResponseMessage Get(long id)
        {
            var mail = _mailRepository.GetById(id);
            if (mail == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, mail);
        }

        // PUT /api/mails/{id}
        [ApiVersionRoute("api/mails/{id}")]
        public HttpResponseMessage Put(long id, Mail mail)
        {
            bool isSuccessfulUpdate = _mailRepository.Update(id, mail);
            if (!isSuccessfulUpdate)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST /api/mails
        [ApiVersionRoute("api/mails")]
        public HttpResponseMessage Post(Mail mail)
        {
            bool isSuccessfulAdd = _mailRepository.Add(mail);
            if (!isSuccessfulAdd)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE /api/mails/{id}
        [ApiVersionRoute("api/mails/{id}")]
        public HttpResponseMessage Delete(long id)
        {
            bool isSuccessfulDelete = _mailRepository.Delete(id);
            if (!isSuccessfulDelete)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // GET api/mails/{id}/attachements
        [ApiVersionRoute("api/mails/{id}/attachements")]
        public HttpResponseMessage GetByMailId(int id)
        {
            var attachements = _attachementRepository.GetAttachementsByMailId(id);
            if (attachements.Count() == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, attachements);
        }

        // GET api/mails/{id}/attachements/{attId}?extention={ext}&status={status}
        [ApiVersionRoute("api/mails/{id}/attachements/{attId}")]
        public HttpResponseMessage GetByMailIdAndAttachementId(int id, int attId, string extention = null, int? status = null)
        {
            var attachement = _attachementRepository.GetAttachementsByMailIdAndAttachementIdAndFileExtentionAndStatusId(id, attId, extention, status);
            if (attachement == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, attachement);
        }

        // PUT api/mails/{id}/attachements/{attId}
        [ApiVersionRoute("api/mails/{id}/attachements/{attId}")]
        public HttpResponseMessage Put(int id, int attId, Attachement attachement)
        {
            bool isSuccessfulUpdate = _attachementRepository.Update(id, attId, attachement);
            if (!isSuccessfulUpdate)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/mails/{id}/attachements
        [ApiVersionRoute("api/mails/{id}/attachements")]
        public HttpResponseMessage Post(int id, Attachement attachement)
        {
            if (id != attachement.MailId)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            if (_attachementRepository.Add(attachement))
                return Request.CreateResponse(HttpStatusCode.OK);
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        // DELETE api/mails/{id}/attachements/{attId}
        [ApiVersionRoute("api/mails/{id}/attachements/{attId}")]
        public HttpResponseMessage Delete(int id, int attId)
        {
            var attachementToDelete = _attachementRepository.GetAttachementsByMailIdAndAttachementId(id, attId);
            if (attachementToDelete == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            if (_attachementRepository.Delete(attachementToDelete))
                return Request.CreateResponse(HttpStatusCode.OK);
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

    }
}

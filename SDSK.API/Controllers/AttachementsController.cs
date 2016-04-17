using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer.RepositoryInterfaces;
using Epam.Sdesk.Model;

namespace SDSK.API.Controllers
{
    public class AttachementsController : ApiController
    {
        private readonly IAttachementRepository _attachementRepository;

        public AttachementsController(IAttachementRepository attachementRepository)
        {
            _attachementRepository = attachementRepository;
        }

        // GET api/mails/{id}/attachements
        [Route("api/mails/{id}/attachements")]
        public HttpResponseMessage GetByMailId(int id)
        {
            var attachements = _attachementRepository.GetAttachementsByMailId(id);
            if(attachements.Count() == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, attachements);
        }

        // GET api/mails/{id}/attachements/{attId}?extention={ext}&status={status}
        [Route("api/mails/{id}/attachements/{attId}")]
        public HttpResponseMessage GetByMailIdAndAttachementId(int id, int attId, string extention = null, int? status = null)
        {
            var attachement = _attachementRepository.GetAttachementsByMailIdAndAttachementIdAndFileExtentionAndStatusId(id, attId, extention, status);
            if (attachement == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, attachement);
        }

        // PUT api/mails/{id}/attachements/{attId}
        [Route("api/mails/{id}/attachements/{attId}")]
        public HttpResponseMessage Put(int id, int attId, Attachement attachement)
        {
            bool isSuccessfulUpdate = _attachementRepository.Update(id, attId, attachement);
            if (!isSuccessfulUpdate)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/mails/{id}/attachements
        [Route("api/mails/{id}/attachements")]
        public HttpResponseMessage Post(int id, Attachement attachement)
        {
            if (id != attachement.MailId)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            if(_attachementRepository.Add(attachement))
                return Request.CreateResponse(HttpStatusCode.OK);
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        // DELETE api/mails/{id}/attachements/{attId}
        [Route("api/mails/{id}/attachements/{attId}")]
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
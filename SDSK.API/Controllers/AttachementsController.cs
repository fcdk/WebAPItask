using System.Collections.Generic;
using System.Web.Http;
using Epam.Sdesk.DataAccess;
using Epam.Sdesk.Model;

namespace SDSK.API.Controllers
{
    public class AttachementsController : ApiController
    {
        private readonly AttachementFakeRepository _attachementRepository = new AttachementFakeRepository();

        // GET api/mails/{id}/attachements
        [Route("api/mails/{id}/attachements")]
        public IEnumerable<Attachement> GetByMailId(int id)
        {
            return _attachementRepository.GetAttachementsByMailId(id);
        }

        // GET api/mails/{id}/attachements/{attId}?extention={ext}&status={status}
        [Route("api/mails/{id}/attachements/{attId}")]
        public Attachement GetByMailIdAndAttachementId(int id, int attId, string extention = null, int? status = null)
        {
            return _attachementRepository.GetAttachementsByMailIdAndAttachementIdAndFileExtentionAndStatusId(id, attId, extention, status);
        }

        // PUT api/mails/{id}/attachements/{attId}
        [Route("api/mails/{id}/attachements/{attId}")]
        public bool Put(int id, int attId, Attachement attachement)
        {
            return _attachementRepository.Update(id, attId, attachement);
        }

        // POST api/mails/{id}/attachements
        [Route("api/mails/{id}/attachements")]
        public bool Post(int id, Attachement attachement)
        {
            if (id != attachement.MailId)
                return false;
            return _attachementRepository.Add(attachement);
        }

        // DELETE api/mails/{id}/attachements/{attId}
        [Route("api/mails/{id}/attachements/{attId}")]
        public bool Delete(int id, int attId)
        {
            var attachementToDelete = _attachementRepository.GetAttachementsByMailIdAndAttachementId(id, attId);
            if (attachementToDelete == null)
                return false;
            return _attachementRepository.Delete(attachementToDelete);
        }

    }
}
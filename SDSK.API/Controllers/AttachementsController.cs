using System.Collections.Generic;
using System.Web.Http;
using Epam.Sdesk.DataAccess;
using Epam.Sdesk.Model;

namespace SDSK.API.Controllers
{
    public class AttachementsController : ApiController
    {
        private readonly AttachementFakeService _attachementService = new AttachementFakeService();

        // GET api/mails/{id}/attachements
        [Route("api/mails/{id}/attachements")]
        public IEnumerable<Attachement> GetByMailId(int id)
        {
            return _attachementService.GetAttachementsByMailId(id);
        }

        // GET api/mails/{id}/attachements/{attId}
        [Route("api/mails/{id}/attachements/{attId}")]
        public Attachement GetByMailIdAndAttachementId(int id, int attId, string extention = null, int? status = null)
        {
            return _attachementService.GetAttachementsByMailIdAndAttachementId(id, attId);
        }

        //// GET api/mails/{id}/attachements/{attId}?extention={ext}
        //[Route("api/mails/{id}/attachements/{attId}/extention={ext}")]
        //public Attachement GetByMailIdAndAttachementIdAndFileExtention(int id, int attId, string ext)
        //{
        //    return _attachementService.GetAttachementsByMailIdAndAttachementIdAndFileExtention(id, attId, ext);
        //}

        //// GET api/mails/{id}/attachements/{attId}?extention={ext}?status={status}
        //[Route("api/mails/{id}/attachements/{attId}/extention={ext}/status={status}")]
        //public Attachement GetByMailIdAndAttachementIdAndFileExtentionAndStatusId(int id, int attId, string ext, int status)
        //{
        //    return _attachementService.GetAttachementsByMailIdAndAttachementIdAndFileExtentionAndStatusId(id, attId, ext, status);
        //}

    }
}

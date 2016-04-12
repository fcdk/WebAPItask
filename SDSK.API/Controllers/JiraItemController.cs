using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;

namespace SDSK.API.Controllers
{
    public class JiraItemController : ApiController
    {
        private readonly JiraItemFakeRepository _jiraItemRepository = new JiraItemFakeRepository();

        // GET api/jiraitems/{id}
        [Route("api/jiraitems/{id?}")]
        public HttpResponseMessage Get(long id = 1)
        {
            var jiraItem = _jiraItemRepository.GetById(id);
            if(jiraItem == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, jiraItem);
        }

    }
}

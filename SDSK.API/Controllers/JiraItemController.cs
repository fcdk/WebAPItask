using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using DataLayer;
using SDSK.API.Regexes;

namespace SDSK.API.Controllers
{
    public class JiraItemController : ApiController
    {
        private readonly JiraItemFakeRepository _jiraItemRepository = new JiraItemFakeRepository();
        private readonly Regex _jiraRegex = new JiraIdRegex().Get();

        //// GET api/jiraitems/{id}
        //[Route("api/jiraitems/{id?}")]
        //public HttpResponseMessage Get(long id = 1)
        //{
        //    var jiraItem = _jiraItemRepository.GetById(id);
        //    if(jiraItem == null)
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    return Request.CreateResponse(HttpStatusCode.OK, jiraItem);
        //}

        // GET api/jiraitems/{id:jiraid}
        [Route("api/jiraitems/{id:jiraid}")]
        public HttpResponseMessage Get(string id)
        {
            var match = _jiraRegex.Match(id);
            if (!match.Success)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            long jiraId;
            if (match.Groups.Count != 2 || !long.TryParse(match.Groups[1].Value, out jiraId))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var jiraItem = _jiraItemRepository.GetById(jiraId);
            if (jiraItem == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, jiraItem);
        }

    }
}

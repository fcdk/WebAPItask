using System.Web.Http;
using Epam.Sdesk.DataAccess;
using Epam.Sdesk.Model;

namespace SDSK.API.Controllers
{
    public class JiraItemController : ApiController
    {
        private readonly JiraItemFakeRepository _jiraItemRepository = new JiraItemFakeRepository();

        // GET api/jiraitems/{id}
        [Route("api/jiraitems/{id}")]
        public JiraItem Get(long id)
        {
            return _jiraItemRepository.GetById(id);
        }

        //GET api/jiraitems (must return the same as for GET api/jiraitems/1)
        [Route("api/jiraitems")]
        public JiraItem Get()
        {
            return Get(1);
        }

    }
}

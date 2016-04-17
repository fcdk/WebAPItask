using System.Collections.Generic;
using System.Linq;
using DataLayer.RepositoryInterfaces;
using Epam.Sdesk.Model;

namespace DataLayer.Repositories
{
    public class JiraItemFakeRepository : IJiraItemRepository
    {
        private readonly ICollection<JiraItem> _jiraItems = new List<JiraItem>
        {
            new JiraItem
            {
                JiraItemId = 1
            },
            new JiraItem
            {
                JiraItemId = 2
            }
        };

        public JiraItem GetById(long id)
        {
            return _jiraItems.FirstOrDefault(x => x.JiraItemId == id);
        }

    }
}

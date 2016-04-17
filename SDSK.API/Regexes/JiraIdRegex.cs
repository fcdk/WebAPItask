using System.Text.RegularExpressions;

namespace SDSK.API.Regexes
{
    public class JiraIdRegex
    {
        public Regex Get()
        {
            return new Regex(@"^Jira-(\d+)$");
        }
    }
}

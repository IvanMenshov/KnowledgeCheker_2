using System.Web;
using System.Web.Mvc;
using KnowledgeChecker.Filters;

namespace KnowledgeChecker
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogFilter());
        }
    }
}

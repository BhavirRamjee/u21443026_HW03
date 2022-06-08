using System.Web;
using System.Web.Mvc;

namespace u21443026_HW03FINALFINAL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

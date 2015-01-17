using System.Web;
using System.Web.Mvc;

namespace _05cTokenBasedAuthentication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

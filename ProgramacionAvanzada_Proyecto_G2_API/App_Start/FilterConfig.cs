using System.Web;
using System.Web.Mvc;

namespace ProgramacionAvanzada_Proyecto_G2_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

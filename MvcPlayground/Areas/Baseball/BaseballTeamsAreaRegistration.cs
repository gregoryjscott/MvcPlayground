using System.Web.Mvc;

namespace MvcPlayground.Areas.Baseball
{
    public class BaseballTeamsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BaseballTeams";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BaseballTeams_default",
                "BaseballTeams/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

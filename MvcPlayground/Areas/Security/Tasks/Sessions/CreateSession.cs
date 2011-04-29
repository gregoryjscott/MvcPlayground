using MvcPlayground.Areas.Security.Models;
using MvcPlayground.Areas.Security.Models.Sessions;
using Simpler;

namespace MvcPlayground.Areas.Security.Tasks.Sessions
{
    public class CreateSession : Task
    {
        // Inputs
        public SessionDetail SessionDetail { get; set; }

        public override void Execute()
        {
            var membershipService = new AccountMembershipService();
            if (membershipService.ValidateUser(SessionDetail.UserName, SessionDetail.Password))
            {
                var formsService = new FormsAuthenticationService();
                formsService.SignIn(SessionDetail.UserName, false);
            }
        }
    }
}
using System;
using MvcTemplate.Areas.Security.Models;
using MvcTemplate.Areas.Security.Models.Sessions;
using MvcTemplate.Models;
using Simpler;

namespace MvcTemplate.Areas.Security.Tasks.Sessions
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
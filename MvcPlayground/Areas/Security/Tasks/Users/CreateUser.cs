using System.Web.Security;
using MvcPlayground.Areas.Security.Models;
using MvcPlayground.Areas.Security.Models.Users;
using Simpler;

namespace MvcPlayground.Areas.Security.Tasks.Users
{
    public class CreateUser : Task
    {
        // Inputs
        public UserDetail UserDetail { get; set; }

        // Outputs
        public MembershipCreateStatus MembershipCreateStatus { get; set; }

        public override void Execute()
        {
            var membershipService = new AccountMembershipService();
            MembershipCreateStatus = membershipService.CreateUser(UserDetail.UserName, UserDetail.Password, UserDetail.Email);
        }
    }
}
using System.Web.Security;
using MvcTemplate.Areas.Security.Models;
using MvcTemplate.Areas.Security.Models.Users;
using MvcTemplate.Models;
using Simpler;

namespace MvcTemplate.Areas.Security.Tasks.Users
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
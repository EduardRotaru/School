using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using School.Models;
using School.Models.Base;
using School.Models.SchoolModels;
using System;

namespace School.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("")]
    public class AccountController : ApiController
    {
        [Route("api/user/register")]
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(AccountDetailsResponse model) 
        {
            model.Role++;

            IdentityResult result = new IdentityResult();
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);

            var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
 

            if (model.Role == Roles.Teacher)
            {
                user.Teacher = new TeacherModel
                {
                    TeacherCode = model.TeacherCode,
                    Subject_ID = model.Subject.ID
                };
            }
            else
            {
                user.Student = new StudentModel
                {
                    StudentCode = model.StudentCode
                };
            }

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };
            result = manager.Create(user, model.Password);
            if (result.Succeeded)
                manager.AddToRoles(user.Id, model.Role.ToString()); 
            return result;
        }

        [HttpGet]
        [Route("api/GetUserClaims")]
        public AccountDetailsResponse GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountDetailsResponse model = new AccountDetailsResponse()
            {
                ID = Convert.ToInt32(identityClaims.FindFirst("ID").Value),
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value,
            };

            return model;
        }
    }
}

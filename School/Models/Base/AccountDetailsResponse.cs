using System;
using School.Models.SchoolModels;

namespace School.Models.Base
{
    public class AccountDetailsResponse
    {
        public int ID { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BirthDate { get; set; }

        public string LoggedOn { get; set; }
        public Roles Role { get; set; }

        public string TeacherCode { get; set; }
        public string StudentCode { get; set; }
        public SubjectModel Subject { get; set; }
    }
}
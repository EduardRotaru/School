using School.Models;
using School.Models.SchoolModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace School.Controllers.SchoolControllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("")]
    public class TeacherController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<ApplicationUser> GetTeachers()
        {
            var list = _context.Users.Include(s => s.Teacher.Subject).ToList();

            var result = new List<ApplicationUser>();

            foreach (var user in list)
            {
                if (user.Roles.Any(r => int.Parse(r.RoleId) - 1 == (int)Roles.Teacher))
                {
                    result.Add(user);
                }
            }

            return result;
        }

        [ResponseType(typeof(TeacherModel))]
        public IHttpActionResult GetTeacher(int id)
        {
            return Ok(_context.Teacher.Include(s => s.Subject).FirstOrDefault(t => t.ID == id));
        }

        [HttpPost]
        [ResponseType(typeof(TeacherModel))]
        public IHttpActionResult Post(TeacherModel teacher)
        {
            if (!ModelState.IsValid || teacher == null)
                return BadRequest(ModelState);

            _context.Subjects.Attach(teacher.Subject);
            _context.Teacher.Add(teacher);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult PutTeacher(string id, ApplicationUser user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (user.Id != id)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            var t = _context.Users.FirstOrDefault(u => u.Id == id);

            if (t != null)
            {
                t.FirstName = user.FirstName;
                t.LastName = user.LastName;

                _context.Entry(t).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult Delete(string id)
        {
            var s = _context.Users.FirstOrDefault(u => u.Id == id);
            var tch = _context.Teacher.FirstOrDefault(t => t.ID == s.Teacher.ID);

            if (s != null)
            {
                _context.Users.Remove(s);
                _context.Teacher.Remove(tch);
                _context.SaveChanges();
            }

            return Ok(tch);
        }

        private TeacherModel FindTeacher(int id)
        {
            return _context.Teacher.Find(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
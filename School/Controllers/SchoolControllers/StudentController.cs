using School.Models;
using School.Models.SchoolModels;
using System;
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
    public class StudentController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<ApplicationUser> GetStudents()
        {
            var list = _context.Users.Include(s => s.Student).Where(s => s.Student != null).ToList();

            var result = new List<ApplicationUser>();

            foreach (var user in list)
            {
                if(user.Roles.Any(r => int.Parse(r.RoleId) - 1 == (int)Roles.Student))
                {
                    result.Add(user);
                }
            }

            return result;
        }

        [ResponseType(typeof(StudentModel))]
        public IHttpActionResult GetStudent(int id)
        {
            return Ok(FindStudent(id));
        }

        [HttpPost]
        [ResponseType(typeof(StudentModel))]
        public IHttpActionResult Post(StudentModel student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Student.Add(student);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult PutStudent(string id, ApplicationUser student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (student.Id != id)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            var s = _context.Users.FirstOrDefault(u => u.Id == id);

            if (s != null)
            {
                s.FirstName = student.FirstName;
                s.LastName = student.LastName;

                _context.Entry(s).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [ResponseType(typeof(StudentModel))]
        public IHttpActionResult Delete(string id)
        {
            var s = _context.Users.FirstOrDefault(u => u.Id == id);
            var std = _context.Student.Find(s.Student.ID);

            if (s != null)
            {
                _context.Users.Remove(s);
                _context.Student.Remove(std);
                _context.SaveChanges();
            }

            return Ok(s);
        }

        private StudentModel FindStudent(int id)
        {
            return _context.Student.Find(id);
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
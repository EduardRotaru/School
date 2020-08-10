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
    public class SubjectController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<SubjectModel> GetSubjects()
        {
            return _context.Subjects.ToList();
        }

        [HttpPost]
        [ResponseType(typeof(TeacherModel))]
        public IHttpActionResult Post(SubjectModel subject)
        {
            if (!ModelState.IsValid || subject == null)
                return BadRequest(ModelState);

            _context.Subjects.Add(subject);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [ResponseType(typeof(SubjectModel))]
        public IHttpActionResult Put(int id, SubjectModel subject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (subject.ID != id)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            var s = _context.Subjects.FirstOrDefault(u => u.ID == id);

            if (s != null)
            {
                s.Name = subject.Name;
                s.Description = subject.Description;

                _context.Entry(s).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [ResponseType(typeof(SubjectModel))]
        public IHttpActionResult Delete(int id)
        {
            var s = _context.Subjects.FirstOrDefault(u => u.ID == id);

            if (s != null)
            {
                _context.Subjects.Remove(s);
                _context.SaveChanges();
            }

            return Ok(s);
        }

        private SubjectModel FindSubject(int id)
        {
            return _context.Subjects.Find(id);
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
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
    [RoutePrefix("api/grades")]
    public class GradesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<GradesModel> GetGradess()
        {
            return _context.Grades;
        }

        [ResponseType(typeof(GradesModel))]
        [Route("GetGradesByTeacher/{teacherId}/{studentId}")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<GradesModel> GetGradesByTeacher(int teacherId, int studentId)
        {
           return _context.Grades.Include(s => s.Subject).Where(s => s.Student_ID == studentId && s.Teacher_ID == teacherId).ToList();
        }

        [ResponseType(typeof(GradesModel))]
        [Route("GetGradesByStudent/{studentId}")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<GradesModel> GetGradesByStudent(int studentId)
        {
           return  _context.Grades.Include(s => s.Subject).Where(s => s.Student_ID == studentId).ToList();
        }

        [ResponseType(typeof(GradesModel))]
        public IHttpActionResult GetGrade(int id)
        {
            return Ok(FindGrades(id));
        }

        [HttpPost]
        [ResponseType(typeof(GradesModel))]
        public IHttpActionResult Post(GradesModel grades)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var grade = new GradesModel()
            {
                Student_ID = grades.Student.ID,
                Teacher_ID = grades.Teacher.ID,
                Subject_ID = grades.Subject.ID,
                Grade = grades.Grade,
                Evaluation = grades.Evaluation,
                Date = DateTime.Now.ToShortDateString(),
                Commentary = grades.Commentary
            };

            _context.Grades.Add(grade);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [ResponseType(typeof(GradesModel))]
        public IHttpActionResult PutGrades(int id, GradesModel grades)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (grades.ID != id)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            var g = FindGrades(id);

            if (g != null)
            {
                g.Grade = grades.Grade;

                _context.Entry(g).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        private GradesModel FindGrades(int id)
        {
            return _context.Grades.Find(id);
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
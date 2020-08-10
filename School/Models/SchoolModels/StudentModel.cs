using System.Collections.Generic;

namespace School.Models.SchoolModels
{
    public class StudentModel
    {
        public int ID { get; set; }

        public string StudentCode { get; set; }

        public IEnumerable<GradesModel> Grades { get; set; }
    }
}
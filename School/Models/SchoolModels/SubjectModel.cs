using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models.SchoolModels
{
    public class SubjectModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public ICollection<TeacherModel> Teachers { get; set; }
    }
}
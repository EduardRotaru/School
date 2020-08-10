using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models.SchoolModels
{
    public class TeacherModel
    {
        public int ID { get; set; }

        public string BirthDate { get; set; }
        public string LoggedOn { get; set; }
        public Roles Role { get; set; }

        public string TeacherCode { get; set; }

        [ForeignKey("Subject_ID")]
        public SubjectModel Subject { get; set; }
        public int? Subject_ID { get; set; }
    }
}
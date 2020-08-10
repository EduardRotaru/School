using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models.SchoolModels
{
    public class GradesModel
    {
        public int ID { get; set; }
        public byte Grade { get; set; }
        public string Evaluation { get; set; }
        public string Commentary { get; set; }
        public string Date { get; set; }

        [ForeignKey("Teacher_ID")]
        public TeacherModel Teacher { get; set; }
        public int Teacher_ID { get; set; }

        [ForeignKey("Student_ID")]
        public StudentModel Student { get; set; }
        public int Student_ID { get; set; }

        [ForeignKey("Subject_ID")]
        public SubjectModel Subject { get; set; }
        public int? Subject_ID { get; set; }
    }
}
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using School.Models.SchoolModels;

namespace School.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual TeacherModel Teacher { get; set; }
        public virtual StudentModel Student { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("SchoolDbContext", throwIfV1Schema: false)
        {
        }

        public DbSet<TeacherModel> Teacher { get; set; }
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<GradesModel> Grades { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TeacherModel>().ToTable("Teachers");
            modelBuilder.Entity<StudentModel>().ToTable("Students");
            modelBuilder.Entity<SubjectModel>().ToTable("Subjects");
            modelBuilder.Entity<GradesModel>().ToTable("Grades");

            //modelBuilder.Entity<SubjectModel>()
            // .HasMany<TeacherModel>(c => c.Teachers)
            // .WithOptional(x => x.Subject)
            // .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Teacher>()
            //    .HasRequired(k => k.Subject)
            //    .WithOptional(k => k.Teacher);

            base.OnModelCreating(modelBuilder);
        }
    }
}
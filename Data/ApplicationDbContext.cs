using E_Learning___Summer_Courses_.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Learning___Summer_Courses_.Data
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}

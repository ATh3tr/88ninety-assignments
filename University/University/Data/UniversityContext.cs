using Microsoft.EntityFrameworkCore;
using University.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
namespace University.Data;

public class UniversityContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Grade> Grades { get; set; } = null!;
    public DbSet<Syllabus> Syllabuses { get; set; } = null!;
    public DbSet<Assignment> Assignments { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationship with ON DELETE NO ACTION
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Teacher)
            .WithMany(u => u.Courses)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Restrict); // Maps to NO ACTION in SQL Server
        // Configure relationship with ON DELETE NO ACTION
        modelBuilder.Entity<Grade>()
            .HasOne(c => c.Student)
            .WithMany(u => u.Grades)
            .HasForeignKey(c => c.StudentId)
            .OnDelete(DeleteBehavior.Restrict); // Maps to NO ACTION in SQL Server
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0TTJB4N\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Application Name=""SQL Server Management Studio"";Command Timeout=0");
    }

}
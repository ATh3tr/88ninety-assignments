using Microsoft.EntityFrameworkCore;

namespace University.Models
{
    [Index(nameof(Email), Name = "IX_EMAIL", IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Role { get; set; } = null!;
        public String Email { get; set; } = null!;
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public User() { }
        public User(string name, string role, string email)
        {
            Name = name;
            Role = role;
            Email = email;
        }
    }
}

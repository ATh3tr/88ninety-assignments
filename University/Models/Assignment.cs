using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public double Weight { get; set; }
        public int Maxgrade { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public Assignment() { }
        public Assignment(String title, double weight, int maxgrade, int courseId)
        {
            Title = title;
            Weight = weight;
            Maxgrade = maxgrade;
            CourseId = courseId;
        }
    }
}

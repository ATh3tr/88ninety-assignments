using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? TeacherId { get; set; }
        public int? SyllabusId { get; set; }
        public User? Teacher { get; set; }
        public Syllabus? Syllabus { get; set; }
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
        public Course() { }
        public Course(string name, int? teacherId, int? syllabusId)
        {
            Name = name;
            TeacherId = teacherId;
            SyllabusId = syllabusId;
        }
    }
}

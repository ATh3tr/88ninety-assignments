using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int? grade { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public Assignment Assignment { get; set; } = null!;
        public User Student { get; set; } = null!;
        public Grade() { }
        public Grade(int _grade, int assignmentId, int studentId)
        {
            grade = _grade;
            AssignmentId = assignmentId;
            StudentId = studentId;
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int UserId { get; set; }
        public int AssignmentId { get; set; }
        public User User { get; set; } = null!;
        public Assignment Assignment { get; set; } = null!;
        public Comment() { }
        public Comment(String content, int userId, int assignmentId)
        {
            Content = content;
            UserId = userId;
            AssignmentId = assignmentId;
        }
    }
}

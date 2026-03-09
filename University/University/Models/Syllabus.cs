using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Syllabus
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        // not sure if this should be one-to-one instead
        public Course? Course { get; set; } 
        public Syllabus() { }
        public Syllabus(String content)
        {
            Content = content;
        }
    }
}

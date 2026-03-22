using System.ComponentModel.DataAnnotations;

namespace UniversityCore.Forms
{
    public class UpdateStudentForm
    {
        [MinLength(2)]
        public string Name { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}

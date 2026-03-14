using Microsoft.AspNetCore.Mvc;
using UniversityCore.Services;
using UniversityCore.DTOs;
using UniversityCore.Forms;

namespace UniversityData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentservice;
        public StudentsController(IStudentService studentservice)
        {
            _studentservice = studentservice;
        }
        [HttpGet]
        public async Task<ActionResult<List<StudentResponseDTO>>> GetStudents()
        {
            return await _studentservice.GetAllStudentsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponseDTO>> GetStudent(int id)
        {
            return await _studentservice.GetStudentByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponseDTO>> AddStudent(CreateStudentForm student)
        {
            var createdstudent = await _studentservice.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = createdstudent.Id }, createdstudent);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            await _studentservice.DeleteStudentAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id, UpdateStudentForm student)
        {
            await _studentservice.UpdateStudentAsync(id, student);
            return NoContent();
        }
    }
}

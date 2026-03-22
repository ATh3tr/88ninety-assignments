using Microsoft.AspNetCore.Mvc;
using UniverSityApi.Filters;
using UniversityCore.DTOs;
using UniversityCore.Forms;
using UniversityCore.Services;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ApiExceptionFilter))]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentservice;
        private readonly ILogger<StudentsController> _logger;
        public StudentsController(IStudentService studentservice, ILogger<StudentsController> logger)
        {
            _studentservice = studentservice;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<StudentResponseDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<StudentResponseDTO>>> GetStudents()
        {
            _logger.LogInformation("Queried All Students");
            return await _studentservice.GetAllStudentsAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentResponseDTO?>> GetStudent(int id)
        {
            _logger.LogInformation($"Queried Student with id {id}");
            return await _studentservice.GetStudentByIdAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(StudentResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StudentResponseDTO>> AddStudent(CreateStudentForm student)
        {
            var createdstudent = await _studentservice.AddStudentAsync(student);
            // if control reaches here, creation completed without exceptions
            _logger.LogInformation("Student Created");
            return CreatedAtAction(nameof(GetStudent), new { id = createdstudent.Id }, createdstudent);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            await _studentservice.DeleteStudentAsync(id);
            // if control reaches here, deletion completed without exceptions
            _logger.LogInformation($"Student with id {id} Deleted");
            return NoContent();
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateStudent(int id, UpdateStudentForm student)
        {
            await _studentservice.UpdateStudentAsync(id, student);
            // if control reaches here, update completed without exceptions
            _logger.LogInformation($"Updated Student with id {id}");
            return NoContent();
        }
    }
}
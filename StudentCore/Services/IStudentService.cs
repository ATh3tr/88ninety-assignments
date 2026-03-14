using UniversityCore.Forms;
using UniversityCore.DTOs;

namespace UniversityCore.Services;


public interface IStudentService
{
    Task<List<StudentResponseDTO>> GetAllStudentsAsync();
    Task<StudentResponseDTO?> GetStudentByIdAsync(int id);
    Task<StudentResponseDTO> AddStudentAsync(CreateStudentForm student);
    Task UpdateStudentAsync(int id, UpdateStudentForm student);
    Task DeleteStudentAsync(int id);
}

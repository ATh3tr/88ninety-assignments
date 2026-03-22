using Microsoft.Extensions.Logging;
using UniversityCore.DTOs;
using UniversityCore.Exceptions;
using UniversityCore.Forms;
using UniversityCore.Validators;
using UniversityData.Models;
using UniversityData.Repositories;

namespace UniversityCore.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repo;
    private readonly ILogger<StudentService> _logger;
    public StudentService(IStudentRepository repo, ILogger<StudentService> logger)
    {
        _repo = repo;
        _logger = logger;
    }
    public async Task<List<StudentResponseDTO>> GetAllStudentsAsync()
    {
        var res = await _repo.GetAll();
        return res.Select(s => new StudentResponseDTO
        {
            Id = s.Id,
            Name = s.Name,
            Email = s.Email
        }).ToList();
    }
    public async Task<StudentResponseDTO?> GetStudentByIdAsync(int id)
    {
        var result = await _repo.GetById(id);
        if (result is null)
        {
            _logger.LogError("Queried non-existing student");
            throw new NotFoundException("Student not found");
        }
        return new StudentResponseDTO
        {
            Id = result.Id,
            Name = result.Name,
            Email = result.Email
        };
    }
    public async Task<StudentResponseDTO> AddStudentAsync(CreateStudentForm student)
    {
        if (student == null)
        {
            _logger.LogError("Form not found in a create student attempt");
            throw new ArgumentNullException(nameof(student));
        }
        var res = FormValidator.Validate(student);
        if (!res.IsValid)
        {
            _logger.LogError("Business Error in create student attempt, " + res.Errors);
            throw new BusinessException(res.Errors);
        }    
        var newStudent = new Student
        {
            Name = student.Name,
            Email = student.Email
        };
        await _repo.Add(newStudent);
        return new StudentResponseDTO
        {
            Id = newStudent.Id,
            Name = newStudent.Name,
            Email = newStudent.Email
        };
    }
    public async Task DeleteStudentAsync(int id)
    {
        bool res = await _repo.Delete(id);
        if (!res)
        {
            _logger.LogError("Attempt to delete non-existing student");
            throw new NotFoundException("Student not found");
        }
    }
    public async Task UpdateStudentAsync(int id, UpdateStudentForm student)
    {
        if (student == null)
        {
            _logger.LogError("Form not found in an update student attempt");
            throw new ArgumentNullException(nameof(student));
        }
        var res = FormValidator.Validate(student);
        if (!res.IsValid)
        {
            _logger.LogWarning("Update form validation failed");
            throw new BusinessException(res.Errors);
        }
        var existingstudent = await _repo.GetById(id);
        if (existingstudent is null)
        {
            _logger.LogError("Student not found in an update attempt");
            throw new NotFoundException("Student not found");
        }
        // Only update fields that are not null in the form
        // This allows for partial updates, where the client can choose to update only certain fields of the student record
        if (student.Name != null)
            existingstudent.Name = student.Name;
        if(student.Email != null)
            existingstudent.Email = student.Email;
        await _repo.Update(existingstudent);
    }
}

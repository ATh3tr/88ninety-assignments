using UniversityData.Models;
using UniversityCore.DTOs;
using UniversityData.Repositories;
using UniversityCore.Forms;

namespace UniversityCore.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repo;
    public StudentService(IStudentRepository repo)
    {
        _repo = repo;
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
        if(result is null)
            throw new Exception("Student not found");
        return new StudentResponseDTO
        {
            Id = result.Id,
            Name = result.Name,
            Email = result.Email
        };
    }
    public async Task<StudentResponseDTO> AddStudentAsync(CreateStudentForm student)
    {
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
        if(!res)
            throw new Exception("Student not found");
    }

    public async Task UpdateStudentAsync(int id, UpdateStudentForm student)
    {
        Student pass = new Student
        {
            Id = id,
            Name = student.Name,
            Email = student.Email
        };
        bool res = await _repo.Update(pass);
        if(!res)
            throw new Exception("Student not found");
    }
}

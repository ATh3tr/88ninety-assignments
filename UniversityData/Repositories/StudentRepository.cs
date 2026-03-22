using Microsoft.EntityFrameworkCore;
using UniversityData.Context;
using UniversityData.Models;

namespace UniversityData.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UniversityDbContext _context;
        public StudentRepository(UniversityDbContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetById(int id)
        {
            return await _context.Students.FindAsync(id);
            
        }
        public async Task Add(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var existingstudent = await _context.Students.FindAsync(id);
            if (existingstudent is null)
                return false;
            _context.Students.Remove(existingstudent);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}

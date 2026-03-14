using UniversityData.Models;

namespace UniversityData.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<Student?> GetById(int id);
        Task Add(Student student);
        Task<bool> Update(Student student);
        Task<bool> Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using testmyapi.Models;

namespace testmyapi.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(int id, Student student);
        Task<Student> DeleteStudentAsync(int id);
    }
}

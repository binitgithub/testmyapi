using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testmyapi.Data;
using testmyapi.Models;

namespace testmyapi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            await _studentDbContext.Students.AddAsync(student);
            await _studentDbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudentAsync(int id)
        {
            var deleteStudent = await _studentDbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (deleteStudent == null)
            {
                return null;
            }

            _studentDbContext.Students.Remove(deleteStudent);
            await _studentDbContext.SaveChangesAsync();
            return deleteStudent;
        }

        public Task<List<Student>> GetAllStudentsAsync() // Changed method name to plural
        {
            return _studentDbContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentDbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            var updateStudent = await _studentDbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (updateStudent == null)
            {
                return null;
            }

            // Update the properties of the student
            updateStudent.FirstName = student.FirstName;
            updateStudent.LastName = student.LastName;
            updateStudent.Age = student.Age;
            updateStudent.Email = student.Email;
            updateStudent.PhoneNumber = student.PhoneNumber;
            updateStudent.EnrollmentDate = student.EnrollmentDate;

            // Add any other properties to update as needed

            await _studentDbContext.SaveChangesAsync();
            return updateStudent;
        }
    }
}

using SMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Service.Contracts
{
    public interface IStudentService
    {
        Task<List<StudentEntity>> GetAllStudentsAsync();
        Task<StudentEntity> GetStudentByIdAsync(int id);
        Task<bool> CreateStudentAsync(StudentEntity student);
        Task<bool> UpdateStudentAsync(StudentEntity student);
        Task<bool> DeleteStudentAsync(int id);
    }
}

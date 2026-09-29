using Microsoft.EntityFrameworkCore;
using SMS.DataAccess;
using SMS.Models.Entities;
using SMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateStudentAsync(StudentEntity student)
        {
            try
            {
                _dbContext.Students.Add(student);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating student: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            try
            {
                var student = await _dbContext.Students.FindAsync(id);
                if (student == null)
                {
                    return false;
                }
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting student: {ex.Message}");
                return false;
            }
        }

        public async Task<List<StudentEntity>> GetAllStudentsAsync()
        {
            var students = await _dbContext.Students.ToListAsync();
            return students; 
        }

        public async Task<StudentEntity> GetStudentByIdAsync(int id)
        {
            var student = await _dbContext.FindAsync<StudentEntity>(id);
            return student;
        }

        public async Task<bool> UpdateStudentAsync(StudentEntity student)
        {
            try
            {
                student.ModifiedBy = "random";
                student.ModifiedAt = DateTime.Now;
                _dbContext.Students.Update(student);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating student: {ex.Message}");
                return false;
            }

            return true;
        }
    }
}

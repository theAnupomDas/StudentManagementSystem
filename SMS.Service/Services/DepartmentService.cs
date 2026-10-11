using Microsoft.EntityFrameworkCore;
using SMS.DataAccess;
using SMS.Models.Entities;
using SMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateDepartmentAsync(Department department)
        {
            try
            {
                _dbContext.Departments.Add(department);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating Department: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            try
            {
                var departments = await _dbContext.Departments.ToListAsync();
                return departments;
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving Departments: {ex.Message}");
                return new List<Department>();
            }
        }
        public async Task<bool> UpdateDepartmentAsync(Department department)
        {
            try
            {
                _dbContext.Departments.Update(department);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Department: {ex.Message}");
                return false;
            }
        }

        public async Task<Department> GetDepartmentAsync(int id)
        {
            try
            {
                var department = await _dbContext.Departments.FindAsync(id);
                return department;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving Department: {ex.Message}");
                return null;
            }
        }

        
    }
}

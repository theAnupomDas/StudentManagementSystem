using SMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Service.Contracts
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartmentsAsync();

        Task<bool> CreateDepartmentAsync(Department department);
        Task<bool> UpdateDepartmentAsync(Department department);
        Task<Department>  GetDepartmentAsync(int id);

    }
}

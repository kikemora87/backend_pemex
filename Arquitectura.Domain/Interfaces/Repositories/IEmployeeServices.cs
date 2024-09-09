using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arquitectura.Domain.POCOs;
using Arquitectura.Domain.DTOs;

namespace Arquitectura.Domain.Interfaces.Repositories
{
    public interface IEmployeeServices
    {
        Task<bool> CreateEmployee(Empleado employee);
        Task<Empleado> GetEmployee(int id);
        Task<List<Empleado>> GetEmployeeList(PaginacionDTO paginacionDTO);
        Task<Empleado> UpdateEmployee(Empleado employee);
        Task<bool> DeleteEmployee(int key);
    }
}

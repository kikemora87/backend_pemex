using Arquitectura.Domain.Interfaces.Repositories;
using Arquitectura.Domain.POCOs;
using Arquitectura.Domain.DTOs;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.Infraestructura.Repositories
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly IDbServices _dbService;

        public EmployeeService(IDbServices dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateEmployee(Empleado employee)
        {
            var result =
                await _dbService.EditData(
                    "INSERT INTO public.empleados (numeroempleado,nombre,apellido,genero,fechanacimiento,telefono,correo,rfc,domicilio,ciudad,estado,pais,filecv,activo) VALUES (@numeroEmpleado,@nombre,@apellido,@genero,@fechaNacimiento,@telefono,@correo,@rfc,@domicilio,@ciudad,@estado,@pais,@filecv, true)",
                    employee);
            return true;
        }

        public async Task<List<Empleado>> GetEmployeeList()  //PaginacionDTO paginacionDTO
        {
            /*string Ordenamiento = "DESC";
            string Filtro = "";
            int page = 0;
            if (paginacionDTO.Orden != "")
                Ordenamiento = paginacionDTO.Orden;
            if (paginacionDTO.Pagina > 1)
            {
                page = (paginacionDTO.Pagina - 1) * paginacionDTO.RecordsPorPagina;
            }
            if (paginacionDTO.ValorFiltro is String)
            {
                Filtro = paginacionDTO.CampoFiltro + " ILIKE '%" + paginacionDTO.ValorFiltro + "%'";
            }
            else
            {
                Filtro = paginacionDTO.CampoFiltro + "=" + paginacionDTO.ValorFiltro;
            }
            var employeeList = await _dbService.GetAll<Empleado>(@"SELECT * 
                                                                    FROM public.empleados 
                                                                    WHERE " + Filtro + " AND activo=true " +
                                                                    "ORDER BY idempleado " + Ordenamiento + " " +
                                                                    "LIMIT " + paginacionDTO.RecordsPorPagina + " OFFSET " + page,
                                                                    new { });
            return employeeList;*/
            var employeeList = await _dbService.GetAll<Empleado>(@"SELECT * FROM public.empleados WHERE activo=true",
                                                                   new { });
            return employeeList;

        }


        public async Task<Empleado> GetEmployee(int id)
        {
            var employeeList = await _dbService.GetAsync<Empleado>("SELECT * FROM public.empleados where idempleado=@id", new { id });
            return employeeList;
        }

        public async Task<bool> UpdateEmployee(Empleado employee)
        {
            var updateEmployee =
                await _dbService.EditData(
                    "Update public.empleados SET numeroempleado=@numeroempleado, nombre=@nombre, apellido=@apellido, genero=@genero, fechanacimiento=@fechanacimiento, telefono=@telefono, correo=@correo, rfc=@rfc, domicilio=@domicilio, ciudad=@ciudad, estado=@estado, pais=@pais, filecv=@filecv WHERE idempleado=@idempleado",
                    employee);
            return true;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            //var deleteEmployee = await _dbService.EditData("DELETE FROM public.empleados WHERE idempleado=@Id", new { id });
            var deleteEmployee = await _dbService.EditData("UPDATE public.empleados SET activo=false WHERE idempleado=@Id", new { id });
            return true;
        }
    }
}

using Arquitectura.Aplication.Handlers.Todo.Commands.Create;
using Arquitectura.Aplication.Handlers.Todo.Commands.Update;
using Arquitectura.Domain.DTOs;
using Arquitectura.Domain.POCOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Arquitectura.Aplication.Mapping
{
    public class EmpleadoProfile : Profile
    {
        public EmpleadoProfile()
        {
            CreateMap<Empleado, AllEmpleados>()
                .ForMember(x => x.idEmpleado, x => x.MapFrom(prop => prop.idEmpleado))
                .ForMember(x => x.numeroEmpleado, x => x.MapFrom(prop => prop.numeroEmpleado))
                .ForMember(x => x.nombre, x => x.MapFrom(prop => prop.nombre))
                .ForMember(x => x.apellido, x => x.MapFrom(prop => prop.apellido))
                .ForMember(x => x.genero, x => x.MapFrom(prop => prop.genero))
                .ForMember(x => x.fechaNacimiento, x => x.MapFrom(prop => prop.fechaNacimiento))
                .ForMember(x => x.telefono, x => x.MapFrom(prop => prop.telefono))
                .ForMember(x => x.correo, x => x.MapFrom(prop => prop.correo))
                .ForMember(x => x.rfc, x => x.MapFrom(prop => prop.rfc))
                .ForMember(x => x.domicilio, x => x.MapFrom(prop => prop.domicilio))
                .ForMember(x => x.ciudad, x => x.MapFrom(prop => prop.ciudad))
                .ForMember(x => x.estado, x => x.MapFrom(prop => prop.estado))
                .ForMember(x => x.pais, x => x.MapFrom(prop => prop.pais))
                .ForMember(x => x.filecv, x => x.MapFrom(prop => prop.filecv))
                .ReverseMap();

            CreateMap<Empleado, UpdateCommand>()
                .ForMember(x => x.idEmpleado, x => x.MapFrom(prop => prop.idEmpleado))
                .ForMember(x => x.numeroEmpleado, x => x.MapFrom(prop => prop.numeroEmpleado))
                .ForMember(x => x.nombre, x => x.MapFrom(prop => prop.nombre))
                .ForMember(x => x.apellido, x => x.MapFrom(prop => prop.apellido))
                .ForMember(x => x.genero, x => x.MapFrom(prop => prop.genero))
                .ForMember(x => x.fechaNacimiento, x => x.MapFrom(prop => prop.fechaNacimiento))
                .ForMember(x => x.telefono, x => x.MapFrom(prop => prop.telefono))
                .ForMember(x => x.correo, x => x.MapFrom(prop => prop.correo))
                .ForMember(x => x.rfc, x => x.MapFrom(prop => prop.rfc))
                .ForMember(x => x.domicilio, x => x.MapFrom(prop => prop.domicilio))
                .ForMember(x => x.ciudad, x => x.MapFrom(prop => prop.ciudad))
                .ForMember(x => x.estado, x => x.MapFrom(prop => prop.estado))
                .ForMember(x => x.pais, x => x.MapFrom(prop => prop.pais))
                .ReverseMap();

            CreateMap<Empleado, CreateCommand>()
                .ForMember(x => x.numeroEmpleado, x => x.MapFrom(prop => prop.numeroEmpleado))
                .ForMember(x => x.nombre, x => x.MapFrom(prop => prop.nombre))
                .ForMember(x => x.apellido, x => x.MapFrom(prop => prop.apellido))
                .ForMember(x => x.genero, x => x.MapFrom(prop => prop.genero))
                .ForMember(x => x.fechaNacimiento, x => x.MapFrom(prop => prop.fechaNacimiento))
                .ForMember(x => x.telefono, x => x.MapFrom(prop => prop.telefono))
                .ForMember(x => x.correo, x => x.MapFrom(prop => prop.correo))
                .ForMember(x => x.rfc, x => x.MapFrom(prop => prop.rfc))
                .ForMember(x => x.domicilio, x => x.MapFrom(prop => prop.domicilio))
                .ForMember(x => x.ciudad, x => x.MapFrom(prop => prop.ciudad))
                .ForMember(x => x.estado, x => x.MapFrom(prop => prop.estado))
                .ForMember(x => x.pais, x => x.MapFrom(prop => prop.pais))
               .ReverseMap();
        }

        private string GetString(IFormFile file)
        {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "File", file.FileName);

            using FileStream memoryStream = new FileStream(directory, FileMode.Create);

            file.CopyTo(memoryStream);

            return directory;
        }
    }
}

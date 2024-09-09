using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Arquitectura.Domain.DTOs;
using Arquitectura.Domain.POCOs;
using AutoMapper;

namespace Arquitectura.Aplication.Mapping
{
    internal class EmpleadoProfile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoDTO>()
                .ForMember(x => x.Id, x => x.MapFrom(prop => prop.Id))
                .ForMember(x => x.Nombre, x => x.MapFrom(prop => prop.Name))
                .ForMember(x => x.Descripcion, x => x.MapFrom(prop => prop.Description))
                .ForMember(x => x.FechaCreacion, x => x.MapFrom(prop => prop.CreatedAt))
                .ReverseMap();

            CreateMap<Todo, UpdateCommand>()
                .ForMember(x => x.Nombre, x => x.MapFrom(prop => prop.Name))
                .ForMember(x => x.Descripcion, x => x.MapFrom(prop => prop.Description))
                .ReverseMap();

            CreateMap<Todo, CreateCommand>()
               .ForMember(x => x.Nombre, x => x.MapFrom(prop => prop.Name))
               .ForMember(x => x.Descripcion, x => x.MapFrom(prop => prop.Description))
               .ReverseMap();

            CreateMap<UpdatePdfCommand, Todo>()
              .ForMember(x => x.Id, x => x.MapFrom(prop => prop.Id))
              .ForMember(x => x.Pdf, x => x.MapFrom(prop => GetString(prop.File)))
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

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arquitectura.Domain.DTOs;
using MediatR;

namespace Arquitectura.Aplication.Handlers.Todo.Commands.Create
{
    public class CreateCommand : IRequest<ResponseDTO<int>>
    {
        [Required(ErrorMessage = "El campo numeroEmpleado es requerido")]
        public string numeroEmpleado { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo apellido es requerido")]
        public string apellido { get; set; }
        [Required(ErrorMessage = "El campo genero es requerido")]
        public string genero { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        [Required(ErrorMessage = "El campo rfc es requerido")]
        public string rfc { get; set; }
        public string domicilio { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        [Required(ErrorMessage = "El Archivo es requerido")]
        public IFormFile File { get; set; }

    }
}

using Arquitectura.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.Aplication.Handlers.Todo.Commands.Update
{
    public class UpdateCommand: IRequest<ResponseDTO<int>>
    {
        [Required(ErrorMessage = "El campo idEmpleado es requerido")]
        public string idEmpleado { get; set; }
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
        public IFormFile? File { get; set; }
    }
}

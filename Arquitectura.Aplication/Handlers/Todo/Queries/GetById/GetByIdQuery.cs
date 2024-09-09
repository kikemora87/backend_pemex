using Arquitectura.Domain.DTOs;
using Arquitectura.Domain.POCOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.Aplication.Handlers.Todo.Queries.GetById
{
    public class GetByIdQuery : IRequest<ResponseDTO<Empleado>>
    {
        public int Id { get; set; }
    }
}

using Arquitectura.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.Aplication.Handlers.Todo.Commands.Delete
{
    public class DeleteCommand : IRequest<ResponseDTO<int>>
    {
        public int Id { get; set; }
    }
}

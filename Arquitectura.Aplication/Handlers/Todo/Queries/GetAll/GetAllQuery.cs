using Arquitectura.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.Aplication.Handlers.Todo.Queries.GetAll
{
    public class GetAllQuery : IRequest<ResponseDTO<List<AllEmpleados>>>
    {

    }
}

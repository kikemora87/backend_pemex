using Arquitectura.Aplication.Handlers.Todo.Queries.GetAll;
using Arquitectura.Domain.DTOs;
using Arquitectura.Domain.Interfaces.Repositories;
using Arquitectura.Domain.POCOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.Aplication.Handlers.Todo.Queries.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, ResponseDTO<Empleado>>
    {
        private readonly ILogger<GetAllHandler> _logger;
        private readonly IEmployeeServices _repository;
        private readonly IMapper _mapper;

        public GetByIdHandler(IEmployeeServices repository, IMapper mapper, ILogger<GetAllHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseDTO<Empleado>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var todo = await _repository.GetEmployee(request.Id);

                if (todo == null)
                    return new ResponseDTO<Empleado>
                    {
                        Success = false,
                        ErrorMessage = "No se encuentra en los registros",
                        Status = StatusCodes.Status404NotFound
                    };

                return new ResponseDTO<Empleado>
                {
                    Data = _mapper.Map<Empleado>(todo)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<Empleado>
                {
                    Success = false,
                    ErrorMessage = "Error interno en el servidor",
                    Status = StatusCodes.Status500InternalServerError
                };

                _logger.LogError("Error interno de TodoAllHandler", ex.Message);
            }
        }
    }
}

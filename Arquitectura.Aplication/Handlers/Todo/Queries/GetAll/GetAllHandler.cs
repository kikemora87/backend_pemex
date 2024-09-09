using Arquitectura.Domain.DTOs;
using Arquitectura.Domain.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.Aplication.Handlers.Todo.Queries.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, ResponseDTO<List<AllEmpleados>>>
    {
        private readonly ILogger<GetAllHandler> _logger;
        private readonly IEmployeeServices _repository;
        private readonly IMapper _mapper;

        public GetAllHandler(IEmployeeServices repository, IMapper mapper, ILogger<GetAllHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseDTO<List<AllEmpleados>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var todos = await _repository.GetEmployeeList();

                if (todos.Count <= 0)
                    return new ResponseDTO<List<AllEmpleados>>
                    {
                        Status = StatusCodes.Status204NoContent,
                        Success = false
                    };

                return new ResponseDTO<List<AllEmpleados>>
                {
                    Data = _mapper.Map<List<AllEmpleados>>(todos.OrderByDescending(x => x.idEmpleado)),
                    Status = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<AllEmpleados>>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Success = false,
                    ErrorMessage = "Error interno en el servidor"
                };

                _logger.LogError("Error interno de TodoAllHandler", ex.Message);
            }
        }
    }
}

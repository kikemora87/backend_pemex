using Arquitectura.Aplication.Handlers.Todo.Queries.GetAll;
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

namespace Arquitectura.Aplication.Handlers.Todo.Commands.Update
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, ResponseDTO<int>>
    {
        private readonly ILogger<GetAllHandler> _logger;
        private readonly IEmployeeServices _repository;
        private readonly IMapper _mapper;

        public UpdateHandler(IEmployeeServices repository, IMapper mapper, ILogger<GetAllHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseDTO<int>> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<Arquitectura.Domain.POCOs.Empleado>(request);

                var todo = await _repository.UpdateEmployee(entity);

                return new ResponseDTO<int>()
                {
                    Success = todo
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<int>()
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

using Arquitectura.Domain.DTOs;
using Arquitectura.Domain.Interfaces.Repositories;
using Arquitectura.Domain.POCOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Arquitectura.Aplication.Handlers.Todo.Commands.Delete
{
    public class DeleteHandler : IRequestHandler<DeleteCommand, ResponseDTO<int>>
    {
        private readonly ILogger<GetAllHandler> _logger;
        private readonly IEmployeeServices _repository;
        private readonly IMapper _mapper;

        public DeleteHandler(IEmployeeServices repository, IMapper mapper, ILogger<GetAllHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseDTO<Guid>> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repository.GetEmployee(request.Id);

                if (entity == null)
                    return new ResponseDTO<Guid>()
                    {
                        Success = false,
                        ErrorMessage = "El registro no se ha encontrado",
                        Status = StatusCodes.Status404NotFound
                    };


                bool todo = await _repository.DeleteEmployee(request.Id);

                return new ResponseDTO<Guid>()
                {
                    Success = false,
                    ErrorMessage = "Error interno en el servidor",
                    Status = StatusCodes.Status500InternalServerError
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<Guid>()
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

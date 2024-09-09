using Arquitectura.Domain.DTOs;
using Arquitectura.Domain.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Arquitectura.Aplication.Handlers.Todo.Commands.Create
{
    public class CreateHandler : IRequestHandler<CreateCommand, ResponseDTO<int>>
    {
        private readonly IEmployeeServices _repository;
        private readonly IMapper _mapper;

        public CreateHandler(IEmployeeServices repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<int>> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<Arquitectura.Domain.POCOs.Empleado>(request);

                var todo = await _repository.CreateEmployee(entity);

                return new ResponseDTO<int>()
                {
                    Success = todo,
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
            }
        }
    }
}

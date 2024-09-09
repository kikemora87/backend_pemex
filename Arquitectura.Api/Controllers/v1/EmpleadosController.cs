using Arquitectura.Aplication.Handlers.Todo.Commands.Create;
using Arquitectura.Aplication.Handlers.Todo.Commands.Delete;
using Arquitectura.Aplication.Handlers.Todo.Commands.Update;
using Arquitectura.Aplication.Handlers.Todo.Queries.GetById;
using Arquitectura.Aplication.Handlers.Todo.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arquitectura.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmpleadosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var res = await _mediator.Send(new GetAllQuery());

            return StatusCode(res.Status, res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _mediator.Send(new GetByIdQuery() { Id = id });

            return StatusCode(res.Status, res);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CreateCommand req)
        {
            return Ok(await _mediator.Send(req));
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromForm] UpdateCommand req)
        {
            return Ok(await _mediator.Send(req));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCommand { Id = id }));
        }

        public ProblemDetails FormatoError(string type, string details)
        {
            ProblemDetails errors = new ProblemDetails()
            {
                Title = type,
                Detail = details,
                Status = 400,
            };

            return errors;
        }
    }
}

using Arquitectura.Aplication.Handlers.Todo.Commands.Create;
using Arquitectura.Aplication.Handlers.Todo.Commands.Delete;
using Arquitectura.Aplication.Handlers.Todo.Commands.Update;
using Arquitectura.Aplication.Handlers.Todo.Queries.GetById;
using Arquitectura.Aplication.Handlers.Todo.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arquitectura.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : Controller
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
        public async Task<ActionResult> Post([FromBody] CreateCommand req)
        {
            return Ok(await _mediator.Send(req));
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] UpdateCommand req)
        {
            return Ok(await _mediator.Send(req));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCommand { Id = id }));
        }

        public ProblemDetails FormatoError(String type, String details)
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

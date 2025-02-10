using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;

namespace Questao5.Controllers
{
    [ApiController]
    [Route("api/movimentacao")] 
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovimentacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> MovimentarConta([FromBody] MovimentarContaCommand command)
        {
            var result = await _mediator.Send(command);

            return result switch
            {
                OkObjectResult okResult => Ok(okResult.Value), 
                BadRequestObjectResult badRequestResult => BadRequest(badRequestResult.Value), 
                _ => StatusCode(500, "Erro inesperado.") 
            };
        }
    }
}
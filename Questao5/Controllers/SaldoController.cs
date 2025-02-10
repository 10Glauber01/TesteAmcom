using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Queries.Requests;

namespace Questao5.Controllers
{
    [ApiController]
    [Route("api/saldo")] 
    public class SaldoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SaldoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{idContaCorrente}")]
        public async Task<IActionResult> ConsultarSaldo(Guid idContaCorrente)
        {
            var result = await _mediator.Send(new ConsultarSaldoQuery(idContaCorrente));

            return result switch
            {
                OkObjectResult okResult => Ok(okResult.Value), // Retorna o resultado com status 200
                BadRequestObjectResult badRequestResult => BadRequest(badRequestResult.Value), // Retorna status 400 em caso de erro
                _ => StatusCode(500, "Erro inesperado.") // Caso não tenha resultado esperado, retorna erro 500
            };
        }
    }
}

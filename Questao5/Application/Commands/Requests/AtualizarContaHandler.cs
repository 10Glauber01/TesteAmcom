using MediatR;
using System.Data;
using Dapper;

namespace Questao5.Application.Commands.Requests
{
    public record AtualizarContaCommand(Guid IdContaCorrente, string Nome, string Numero) : IRequest<IResult>;
}

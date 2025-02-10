using Dapper;
using MediatR;
using System.Data;

namespace Questao5.Application.Commands.Requests
{
    public record MovimentarContaCommand(Guid IdContaCorrente, decimal Valor, string TipoMovimento, Guid IdRequisicao) : IRequest<IResult>;
}

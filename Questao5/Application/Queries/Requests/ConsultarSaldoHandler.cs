using Dapper;
using MediatR;
using System.Data;

namespace Questao5.Application.Queries.Requests
{
    public record ConsultarSaldoQuery(Guid IdContaCorrente) : IRequest<IResult>;

    public class ConsultarSaldoHandler : IRequestHandler<ConsultarSaldoQuery, IResult>
    {
        private readonly IDbConnection _db;

        public ConsultarSaldoHandler(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IResult> Handle(ConsultarSaldoQuery request, CancellationToken cancellationToken)
        {
            var sql = "SELECT numero, nome, (COALESCE((SELECT SUM(valor) FROM movimento WHERE idcontacorrente = @Id AND tipomovimento = 'C'), 0) - COALESCE((SELECT SUM(valor) FROM movimento WHERE idcontacorrente = @Id AND tipomovimento = 'D'), 0)) AS Saldo FROM contacorrente WHERE idcontacorrente = @Id";
            var resultado = await _db.QueryFirstOrDefaultAsync(sql, new { Id = request.IdContaCorrente });

            if (resultado == null)
                return Results.BadRequest(new { Tipo = "INVALID_ACCOUNT", Mensagem = "Conta não encontrada." });

            return Results.Ok(new { resultado.numero, resultado.nome, DataHora = DateTime.UtcNow, resultado.Saldo });
        }
    }
}

using System.Globalization;

namespace Questao1
{
    public class ContaBancaria : IContaBancaria
    {
        public int Numero { get; }
        public string Titular { get; private set; }
        private double Saldo;
        private const double TaxaSaque = 3.5;

        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            this.Numero = numero;
            this.Titular = titular;
            this.Saldo = depositoInicial;
        }

        public void Depositar(double quantia)
        {
            Saldo += quantia;
        }

        public void Sacar(double quantia)
        {
            Saldo -= (quantia + TaxaSaque);
        }

        public void AlterarTitular(string novoTitular)
        {
            Titular = novoTitular;
        }

        public string ObterSaldo()
        {
            var saldo = Saldo.ToString("F2", CultureInfo.InvariantCulture);
            return saldo;

        }
    }
}

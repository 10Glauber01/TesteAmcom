namespace Questao1
{
    public interface IContaBancaria
    {
        int Numero { get;}
        string Titular { get; }

        void Depositar(double quantia);
        void Sacar(double quantia);
        void AlterarTitular(string novoTitular);
        string ObterSaldo();
    }
}

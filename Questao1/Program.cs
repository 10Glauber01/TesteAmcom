using System;
using System.Globalization;

namespace Questao1 {
    class Program {

        private const double ZERO = 0;

        static void Main(string[] args) {

            IContaBancaria conta;

            string input;
            string saldoStr = "";

            Console.Write("Entre o número da conta: ");
            /*
             Em todas as entradas de dados necessário validar se o tipo informado é o esperado?
             Decidi por não implementar para não fugir muito do escopo solicitado. 
            */
            int numero = int.Parse(Console.ReadLine()); 
            Console.Write("Entre o titular da conta: ");
            string titular = Console.ReadLine();
            Console.Write("Haverá depósito inicial (s/n)? ");
            char resp = char.Parse(Console.ReadLine());
            if (resp == 's' || resp == 'S') {
                Console.Write("Entre o valor de depósito inicial: ");
                input = Console.ReadLine();
                double depositoInicial = double.Parse(input is not null? input : "0" , CultureInfo.InvariantCulture);
                conta = new ContaBancaria(numero, titular, depositoInicial);
            }
            else {
                conta = new ContaBancaria(numero, titular, ZERO);
            }
            saldoStr = conta.ObterSaldo();

            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine($"\nConta {conta.Numero}, Titular: {conta.Titular}, Saldo: $ {saldoStr}");

            Console.WriteLine();
            Console.Write("Entre um valor para depósito: ");
            input = Console.ReadLine();
            double quantia = double.Parse(input is not null ? input : "0", CultureInfo.InvariantCulture);
            conta.Depositar(quantia);
            saldoStr = conta.ObterSaldo();
            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine($"\nConta {conta.Numero}, Titular: {conta.Titular}, Saldo: $ {saldoStr}");

            Console.WriteLine();
            Console.Write("Entre um valor para saque: ");
            input = Console.ReadLine();
            quantia = double.Parse(input is not null ? input : "0", CultureInfo.InvariantCulture);
            conta.Sacar(quantia);
            saldoStr = conta.ObterSaldo();
            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine($"\nConta {conta.Numero}, Titular: {conta.Titular}, Saldo: $ {saldoStr}");

            /* Output expected:
            Exemplo 1:

            Entre o número da conta: 5447
            Entre o titular da conta: Milton Gonçalves
            Haverá depósito inicial(s / n) ? s
            Entre o valor de depósito inicial: 350.00

            Dados da conta:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 350.00

            Entre um valor para depósito: 200
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 550.00

            Entre um valor para saque: 199
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 347.50

            Exemplo 2:
            Entre o número da conta: 5139
            Entre o titular da conta: Elza Soares
            Haverá depósito inicial(s / n) ? n

            Dados da conta:
            Conta 5139, Titular: Elza Soares, Saldo: $ 0.00

            Entre um valor para depósito: 300.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ 300.00

            Entre um valor para saque: 298.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ -1.50
            */
        }
    }
}

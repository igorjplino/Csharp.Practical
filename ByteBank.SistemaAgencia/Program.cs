using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using System;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista<int> idades = new Lista<int>();

            idades.AdicionarVarios(5, 10, 15, 20, 25, 30, 35);

            for (int i = 0; i < idades.Tamanho; i++)
            {
                Console.WriteLine($"Idade no indice {i} = {idades[i]}");
            }

            Console.WriteLine($"Remover");

            idades.Remover(5);
            idades.Remover(15);
            idades.Remover(25);
            idades.Remover(35);

            for (int i = 0; i < idades.Tamanho; i++)
            {
                Console.WriteLine($"Idade no indice {i} = {idades[i]}");
            }

            Console.WriteLine(idades[4]);

            Console.ReadLine();
        }

        static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaDoGui = new ContaCorrente(11111, 1111111);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679754)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679754)
            );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }
        }

        public static void ExtrairValorCambio()
        {
            string url = "www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";

            ExtratorDeArgumentosURL extrator = new ExtratorDeArgumentosURL(url);

            Console.WriteLine(extrator.GetValor("moedaOrigem")); // real
            Console.WriteLine(extrator.GetValor("moedaDestino")); // dolar
            Console.WriteLine(extrator.GetValor("valor")); // 1500
        }
    }
}

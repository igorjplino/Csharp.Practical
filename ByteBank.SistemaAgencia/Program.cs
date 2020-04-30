using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using System;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var lista = new ListaDeContaCorrente(5);

            var conta = new ContaCorrente(000, 999999);

            lista.Adicionar(new ContaCorrente(321, 321321));
            lista.Adicionar(new ContaCorrente(321, 321321));
            lista.Adicionar(new ContaCorrente(321, 321321));
            lista.Adicionar(new ContaCorrente(321, 321321));
            lista.Adicionar(conta);
            lista.Adicionar(new ContaCorrente(321, 321321));
            lista.Adicionar(new ContaCorrente(321, 321321));

            lista.EscreverListaNaTela();

            lista.Remover(conta);
            Console.WriteLine("Após remover");

            lista.EscreverListaNaTela();

            Console.ReadLine();
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

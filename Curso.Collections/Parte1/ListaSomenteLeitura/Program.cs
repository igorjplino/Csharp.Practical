using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaSomenteLeitura
{
    class Program
    {
        static void Main(string[] args)
        {
            var curso = new Curso("Estudando CSharp", "Igor Jorge");

            curso.AdicionarAula(new Aula("Lista somente leitura", 30));
            
            Imprimir(curso.Aulas);
        }

        private static void Imprimir(IList<Aula> aulas)
        {
            Console.Clear();
            foreach (var aula in aulas)
            {
                Console.WriteLine(aula);
            }

            Console.ReadLine();
        }
    }
}

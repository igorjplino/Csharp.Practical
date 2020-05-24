using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaSomenteLeitura
{
    class Aluno
    {
        public Aluno(string nome, int matricula)
        {
            Nome = nome;
            Matricula = matricula;
        }

        public string Nome { get; set; }
        public int Matricula { get; set; }

        public override string ToString()
        {
            return $"[Nome: {Nome} | Matrícula: {Matricula}]";
        }
    }
}

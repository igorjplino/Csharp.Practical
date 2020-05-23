using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaSomenteLeitura
{
    class Curso
    {
        private IList<Aula> _aulas;

        public Curso(string nome, string instrutor)
        {
            Nome = nome;
            Instrutor = instrutor;

            _aulas = new List<Aula>();
        }

        /// <summary>
        /// Adicionar aula no curso
        /// </summary>
        /// <param name="aula">Aula a ser adicionada</param>
        /// <exception cref="ArgumentNullException">Exceção lançada quando o argumento <paramref name="aula"/> é nulo.</exception>
        /// <exception cref="ArgumentException">Exceção lançada quando a Aula já existe no Curso.</exception>
        internal void AdicionarAula(Aula aula)
        {
            if (aula == null)
            {
                throw new ArgumentNullException(nameof(aula), "Não é permitido adicionar uma aula Nula");
            }

            if (_aulas.Any(o => o.Titulo.Equals(aula.Titulo, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Aula '{aula.Titulo}' já existente no curso", nameof(aula));
            }

            _aulas.Add(aula);
        }

        public string Nome { get; set; }
        public string Instrutor { get; set; }
        public IList<Aula> Aulas 
        {
            get
            {
                return new ReadOnlyCollection<Aula>(_aulas);
            }
        }
    }
}

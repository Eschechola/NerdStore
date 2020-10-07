using NerdStore.Core.DomainObjects;
using System.Collections;
using System.Collections.Generic;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        #region Properties

        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        protected Categoria() { }

        public ICollection<Produto> Produtos { get; set; }

        #endregion


        #region Constructors

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        #endregion


        #region Methods (Comportaments)

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome a categoria não pode estar vazio.");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0.");
        }

        #endregion
    }
}

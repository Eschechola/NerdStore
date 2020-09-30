using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        #region Properties

        public string Nome { get; private set; }
        public int Codigo { get; private set; }

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

        #endregion
    }
}

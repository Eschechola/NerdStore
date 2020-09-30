using System;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {

        #region Properties

        public Guid CategoriaId { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }

        public Categoria Categoria { get; private set; }

        #endregion


        #region Constructors

        public Produto(
            string nome,
            string descricao,
            bool ativo,
            decimal valor,
            Guid categoriaId,
            DateTime dataCadastro,
            string imagem
        )
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            CategoriaId = categoriaId;
            DataCadastro = dataCadastro;
            Imagem = imagem;
        }

        #endregion


        #region Methods (Comportaments)

        //ADs Rocks Setters


        //ao invés de utilizar produto.Ativar = false, chama o método Desativar
        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;


        //ao invés de utilizar produto.Categoria = xyz, chama o método AlterarCategoria
        public void AlterarCategoria(Categoria categoria)
        {
            CategoriaId = categoria.Id;
            Categoria = categoria;
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            //caso seja informado um número negativo
            if (quantidade < 0)
                quantidade *= -1;
            else
                QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {

        }

        #endregion
    }
}

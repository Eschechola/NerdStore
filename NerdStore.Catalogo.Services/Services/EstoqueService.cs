using NerdStore.Catalogo.Services.Interfaces;
using NerStore.Catalogo.Infra.Data.Interfaces;
using System;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Services.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;

        public EstoqueService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null)
                return false;

            if (produto.PossuiEstoque(quantidade) == false)
                return false;

            produto.DebitarEstoque(quantidade);

            _produtoRepository.Atualizar(produto);
            
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null)
                return false;

            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

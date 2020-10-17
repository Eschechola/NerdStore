using NerdStore.Core.Messages;
using System.Threading.Tasks;

namespace NerStore.Catalogo.Infra.Data.Mediatr
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}

using System;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Core.Data
{
    public interface IBaseRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}

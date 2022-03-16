using ProvaCaminhao.Configuration;
using ProvaCaminhao.Data.Repository;
using System;


namespace ProvaCaminhao.Configuration
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
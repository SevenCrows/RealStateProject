namespace RealState.Application.Repositories
{
    using System;
    using System.Threading.Tasks;
    using RealState.Domain.Model;

    public interface IOwnerReadRepository
    {
        Task<Owner> Get(Guid id);
    }

    public interface IOwnerWriteRepository
    {
        Task Add(Owner owner);
        Task Update(Owner owner);
    }
}
